using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Numerics;
using System.Transactions;
using static openGLProject.OpenGL;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace openGLProject
{
    public class MushroomForest
    {
        private readonly List<Mushroom> mushrooms = new List<Mushroom>();
        private float[,] heightMap;
        private int gridSize;
        private int mushroomCount;

        public MushroomForest(float[,] hM, int gS, int mC)
        {
            heightMap = hM;
            gridSize = gS;
            mushroomCount = mC;
            GenerateMushrooms();
        }
        public void RenderMushrooms()
        {
            foreach (var m in mushrooms) {
                m.Render();
            }
        }

        public void GenerateMushrooms()
        {
            Random rand = new Random();
            for (int i = 0; i < mushroomCount; i++) {
                int x = rand.Next(1, gridSize-1);
                int z = rand.Next(1, gridSize-1);
                float y = heightMap[x, z];
                mushrooms.Add(new Mushroom(x, y, z));
            }
        }

        public int setCount(int mC)
        {
            mC = Math.Clamp(mC, 0, gridSize);

            if(mushroomCount < mC)
            {
                int a = mC - mushroomCount;
                Random rand = new Random();
                for (int i = 0; i < a; i++)
                {
                    int x = rand.Next(1, gridSize - 1);
                    int z = rand.Next(1, gridSize - 1);
                    float y = heightMap[x, z];
                    mushrooms.Add(new Mushroom(x, y, z));
                }
            }
            else {
                int d = mushroomCount - mC;
                for (int i = 0; i < d; i++)
                {
                    mushrooms.RemoveAt(mushrooms.Count - 1);
                }
            }
            return mushroomCount = mC;
        }

        public void setHeighMap(float[,] hM)
        {
            heightMap = hM;
        }
        public void setGridSize(int gS)
        {
            gridSize = gS;
        }

        private class Mushroom
        {
            private float X { get; }
            private float Y { get; }
            private float Z { get; }

            private uint Color;
            private float size;
            //Размеры макс, мин гриба
            private static readonly float maxSize = 2.4f;
            private static readonly float minSize = 0.8f;
            
            public Mushroom(float x, float y, float z) {
                X = x;
                Y = y;
                Z = z;
                Random rand = new Random();
                Color = (uint)((rand.Next(100, 256) << 16) |
                       (rand.Next(0, 256) << 8) |
                       rand.Next(0, 100));
                size = Math.Clamp((float)rand.NextDouble() * 2.5f, minSize, maxSize);
            }
            public void Render()
            {
                IntPtr quadric = gluNewQuadric();
                byte r, g, b;

                r = (byte)((Color >> 16) & 0xFF);
                g = (byte)((Color >> 8) & 0xFF);
                b = (byte)(Color & 0xFF);


                // Ножка гриба
                glPushMatrix();
                glTranslatef(X, Y, Z);
                glScalef(size, size, size);
                glRotatef(-90, 1.0f, 0.0f, 0.0f); 
                glColor3f(0.5f, 0.3f, 0.1f); 
                gluCylinder(quadric, 0.2f, 0.2f, 2.0f, 8, 8);
                glPopMatrix();

                // Шапочка гриба (купол)
                glPushMatrix();
                glTranslatef(X , Y+2.0f*size, Z);
                glScalef(size, size, size);
                glColor3ub(r, g, b);

                // Отсечение
                double[] clipPlane = { 0.0, 1.0, 0.0, 0.0 }; // Оставляем только верхнюю половину
                glEnable(GL_CLIP_PLANE0);
                glClipPlane(GL_CLIP_PLANE0, clipPlane);

                gluSphere(quadric, 1.0f, 16, 8); // Рисуем сферу радиусом 1.0

                glDisable(GL_CLIP_PLANE0);
                glPopMatrix();

                gluDeleteQuadric(quadric);
            }

        }
    }
}

