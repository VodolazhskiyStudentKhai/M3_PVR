using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Transactions;
using static openGLProject.OpenGL;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;

namespace openGLProject
{
    public class Fog
    {
        private float fogDensity;
        private float farFogDistance;
        private static int ArraySize = 7;
        private float[] distances = new float[ArraySize];
        private float[] densities = new float[ArraySize];

        private static readonly float[] DensityCoefficients = { 1.0f, 0.875f, 0.75f, 0.5f, 0.25f, 0.125f, 0.0625f };
        private static readonly float[] DistanceCoefficients = { 1.0f, 0.75f, 0.5f, 0.25f, 0.125f, 0.06f, 0.0f };

        private int first_el = 0;

        public Fog(float density, float farDistance)
        {
            fogDensity = density; // Плотность ближнего слоя
            farFogDistance = farDistance;                // Расстояние до дальнего слоя
            RecalculateDencities();
            RecalculateDistances();
        }

        public void SetDensity(float density)
        {
            fogDensity = density;
            RecalculateDencities();
        }

        public void SetFarFogDistance(float distance)
        {
            farFogDistance = Math.Max(distance, 0.0f); // Убедимся, что расстояние не отрицательное
            RecalculateDistances();

        }
        private void RecalculateDencities()
        {
            for (int i = 0; i < ArraySize; i++) {
                float d = Math.Clamp(fogDensity * DensityCoefficients[i], 0.0f, 1.0f);
                densities[i] = d;
                if(d == 1.0f) {
                    first_el = i;
                }
            }
        }
        private void RecalculateDistances()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                distances[i] = farFogDistance * DistanceCoefficients[i];
            }
        }
        public void Render(Params Par)
        {
            for (int i = first_el; i < ArraySize; i++) {
                RenderFogLayer(distances[i], densities[i], Par);
            }
        }

        private void RenderFogLayer(float zOffset, float density, Params Par)
        {
            if (density < 0.05)
                return;

            glMatrixMode(GL_PROJECTION);
            glPushMatrix();
            glLoadIdentity();

            if (Par.perspective)
            {
                // Устанавливаем перспективную проекцию
                gluPerspective(75, 1.0, (zOffset == 0.0) ? 0.0:0.1, zOffset*10); // Поле зрения, соотношение сторон, ближняя и дальняя плоскости
            }
            else
            {
                // Устанавливаем ортогональную проекцию
                glOrtho(-1, 1, -1, 1, -10, 10); // Убедимся, что дальний слой остается в пределах видимости
            }

            glMatrixMode(GL_MODELVIEW);
            glPushMatrix();
            glLoadIdentity();

            // Смещение слоя вдоль оси Z
            if (Par.perspective)
            {
                glTranslatef(0.0f, 0.0f, -zOffset); // Смещение в перспективной проекции
            }
            else
            {
                glTranslatef(0.0f, 0.0f, -zOffset); // Смещение в ортогональной проекции
            }

            // Настраиваем альфа-режим для эффекта прозрачности
            glEnable(GL_BLEND);
            glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

            // Устанавливаем цвет с учетом плотности тумана
            glColor4f(0.7f, 0.7f, 0.7f, Math.Clamp(density, 0.0f, 1.0f));

            // Рисуем прямоугольник
            glBegin(GL_QUADS);
            if (Par.perspective)
            {
                glVertex3f(-zOffset, -zOffset, 0.0f); // Левый нижний угол
                glVertex3f(zOffset, -zOffset, 0.0f);  // Правый нижний угол
                glVertex3f(zOffset, zOffset, 0.0f);   // Правый верхний угол
                glVertex3f(-zOffset, zOffset, 0.0f);  // Левый верхний угол
            }
            else
            {
                glVertex3f(-1.0f, -1.0f, 0.0f); // Левый нижний угол
                glVertex3f(1.0f, -1.0f, 0.0f);  // Правый нижний угол
                glVertex3f(1.0f, 1.0f, 0.0f);   // Правый верхний угол
                glVertex3f(-1.0f, 1.0f, 0.0f);  // Левый верхний угол
            }
            glEnd();

            // Восстанавливаем матрицы
            glPopMatrix();
            glMatrixMode(GL_PROJECTION);
            glPopMatrix();

            // Отключаем альфа-режим
            glDisable(GL_BLEND);
        }

    }
}

