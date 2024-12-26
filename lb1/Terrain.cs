using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
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
    public class Terrain
    {
        private float[,] heightMap;
        private int gridSize; // Размер сетки
        private float maxHeight = 5.0f; // Максимальная высота
        private float voidFactor = 0f; // Пустота (отсутствие точек)
        private float detailLevel = 1.0f;   // Уровень детализации (шаг сетки)
        private bool gradient = true;

        public Terrain(int gr_size)
        {
            this.gridSize = gr_size;

            var rand = new Random();
            heightMap = new float[gridSize, gridSize];

            for (int x = 0; x < gridSize; x++)
            {
                for (int z = 0; z < gridSize; z++)
                {
                    heightMap[x, z] = (float)rand.NextDouble() * maxHeight;
                }
            }

            // Сглаживание
            for (int x = 1; x < gridSize - 1; x++)
            {
                for (int z = 1; z < gridSize - 1; z++)
                {
                    heightMap[x, z] = (heightMap[x - 1, z] + heightMap[x + 1, z] +
                                       heightMap[x, z - 1] + heightMap[x, z + 1]) / 4.0f;
                }
            }
        }

        public void CreateTerrainDisplay()
        {
            float step = Math.Max(1.0f, detailLevel); // Шаг сетки, дробное значение
            for (float x = 0; x < gridSize - step; x += step)
            {
                for (float z = 0; z < gridSize - step; z += step)
                {
                    RenderSmoothedQuad(x, z, step);
                }
            }
        }

        private void RenderSmoothedQuad(float x, float z, float step)
        {
            // Интерполяция высот с дробным шагом
            float h00 = heightMap[(int)x, (int)z];
            float h10 = heightMap[Math.Min((int)(x + step), gridSize - 1), (int)z];
            float h01 = heightMap[(int)x, Math.Min((int)(z + step), gridSize - 1)];
            float h11 = heightMap[Math.Min((int)(x + step), gridSize - 1), Math.Min((int)(z + step), gridSize - 1)];

            // Проверка, если высота меньше voidFactor, пропускаем рендеринг
            if (h00 < voidFactor && h10 < voidFactor && h01 < voidFactor && h11 < voidFactor)
                return; // Пропускаем рендеринг этой ячейки

            // Центральная точка с учетом дробного шага
            float hCenter = (h00 + h10 + h01 + h11) / 4.0f;

            glBegin(GL_TRIANGLES);

            // Верхний треугольник
            RenderTriangle(x, h00, z, x + step, h10, z, x, h01, z + step);
            RenderTriangle(x + step, h10, z, x + step, h11, z + step, x, h01, z + step);

            // Дополнительные треугольники для плавного перехода через центральную точку
            RenderTriangle(x + step / 2, hCenter, z + step / 2,
                           x, h00, z,
                           x + step, h10, z);

            RenderTriangle(x + step / 2, hCenter, z + step / 2,
                           x + step, h10, z,
                           x + step, h11, z + step);

            RenderTriangle(x + step / 2, hCenter, z + step / 2,
                           x + step, h11, z + step,
                           x, h01, z + step);

            RenderTriangle(x + step / 2, hCenter, z + step / 2,
                           x, h01, z + step,
                           x, h00, z);

            glEnd();
        }



        private void RenderTriangle(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3)
        {
            if (gradient)
            {
                SetVertexColor(y1);
                glVertex3f(x1, y1, z1);

                SetVertexColor(y2);
                glVertex3f(x2, y2, z2);

                SetVertexColor(y3);
                glVertex3f(x3, y3, z3);
            }
            else
            {
                glColor3f(0.2f, 0.2f, 0.2f);
                glVertex3f(x1, y1, z1);
                glVertex3f(x2, y2, z2);
                glVertex3f(x3, y3, z3);
            }
        }


        private void SetVertexColor(float height)
        {
            float normalizedHeight = height / maxHeight;
            glColor3f(normalizedHeight, normalizedHeight, 1.0f - normalizedHeight);
        }

        
        public void ToggleGradient() { gradient = !gradient; }

        public bool getGradient()
        {
            return gradient;
        }
        public void setDatailLevel(float d)
        {
            detailLevel = d;
        }

        public void setVoidFactor(float d)
        {
            voidFactor = d;
        }
        public float[,] getHeightMap()
        {
            return heightMap;
        }
        public float GetMaxHeight()
        {
            float maxHeight = 0;
            for (int x = 0; x < gridSize; x++)
            {
                for (int z = 0; z < gridSize; z++)
                {
                    if (heightMap[x, z] > maxHeight)
                    {
                        maxHeight = heightMap[x, z];
                    }
                }
            }
            return maxHeight;
        }
    }
}

