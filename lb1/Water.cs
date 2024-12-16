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
    public class Water
    {
        private int gridSize; // Размер сетки (общий для воды и ландшафта)
        private float waterLevel; // Уровень воды
        private float transparency; // Прозрачность воды
        private float waveSpeed; // Скорость волн
        private float waveHeight; // Высота волн
        private float time; // Время для динамической модели

        public Water(int gridSize, float waterLevel, float transparency)
        {
            this.gridSize = gridSize;
            this.waterLevel = waterLevel;
            this.transparency = transparency;
            waveSpeed = 0.0f; // По умолчанию
            waveHeight = 0.5f; // По умолчанию
        }

        public void RenderWater()
        {
            if (waterLevel == 0)
                return;

            glEnable(GL_BLEND); // Включение прозрачности
            glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
            glColor4f(0.0f, 0.4f, 0.8f, 1.0f - transparency); // Цвет воды с прозрачностью

            glBegin(GL_QUADS);

            // Верхняя поверхность воды
            for (int x = 0; x < gridSize - 1; x++)
            {
                for (int z = 0; z < gridSize - 1; z++)
                {
                    float y1 = CalculateWaveHeight(x, z);
                    float y2 = CalculateWaveHeight(x + 1, z);
                    float y3 = CalculateWaveHeight(x + 1, z + 1);
                    float y4 = CalculateWaveHeight(x, z + 1);

                    glVertex3f(x, waterLevel + y1, z);
                    glVertex3f(x + 1, waterLevel + y2, z);
                    glVertex3f(x + 1, waterLevel + y3, z + 1);
                    glVertex3f(x, waterLevel + y4, z + 1);
                }
            }

            // Боковые грани воды
            for (int x = 0; x < gridSize - 1; x++)
            {
                for (int z = 0; z < gridSize - 1; z++)
                {
                    // Текущие и соседние высоты волн
                    float y1 = CalculateWaveHeight(x, z);
                    float y2 = CalculateWaveHeight(x + 1, z);
                    float y3 = CalculateWaveHeight(x, z + 1);

                    // Грань вдоль X
                    glVertex3f(x, 0, z);
                    glVertex3f(x, waterLevel + y1, z);
                    glVertex3f(x + 1, waterLevel + y2, z);
                    glVertex3f(x + 1, 0, z);

                    // Грань вдоль Z
                    glVertex3f(x, 0, z);
                    glVertex3f(x, waterLevel + y1, z);
                    glVertex3f(x, waterLevel + y3, z + 1);
                    glVertex3f(x, 0, z + 1);
                }
            }

            glEnd();

            glDisable(GL_BLEND);
        }

        public void UpdateTime(float deltaTime)
        {
            time += deltaTime * waveSpeed;
        }

        private float CalculateWaveHeight(int x, int z)
        {
            return (float)Math.Sin(x * 0.1 + z * 0.1 + time) * waveHeight;
        }

        public void SetWaterLevel(float level) => waterLevel = level;
        public void SetTransparency(float alpha) => transparency = Math.Clamp(alpha, 0.0f, 1.0f);
        public void SetWaveSpeed(float speed) => waveSpeed = speed;
        public void SetWaveHeight(float height) => waveHeight = height;
        public void SetGridSize(int size) => gridSize = size;
    }
}

