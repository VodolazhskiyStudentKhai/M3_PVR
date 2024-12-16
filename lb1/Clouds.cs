using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Numerics;
using static openGLProject.OpenGL;
using static System.Windows.Forms.LinkLabel;

namespace openGLProject
{
    using System;
    using System.Collections.Generic;

    public class Clouds
    {
        private class Sphere
        {
            public float offsetX, offsetY, offsetZ; // Смещение сферы в пределах облака
            public float radius;                  // Радиус сферы
        }

        private class Cloud
        {
            public float x, y, z;   // Позиция облака
            public float speed;    // Скорость облака
            public float color;
            public List<Sphere> spheres; // Список сфер, составляющих облако
        }

        private List<Cloud> cloudList;
        private Random random = new Random();
        private float gridSize;       // Размер карты
        private float cloudHeight;    // Высота облаков (y)
        private float speed;          // Скорость движения облака

        public Clouds(int count, float gridSize, float cloudHeight, float speed)
        {
            this.gridSize = gridSize;
            this.cloudHeight = cloudHeight;
            this.speed = speed;
            cloudList = new List<Cloud>();
            for (int i = 0; i < count; i++)
            {
                AddCloud();
            }
        }

        private void AddCloud()
        {
            float x = (float)(random.NextDouble() * gridSize - gridSize / 2);
            float y = cloudHeight;
            float z = (float)(random.NextDouble() * gridSize - gridSize / 2);

            Cloud cloud = new Cloud
            {
                x = x,
                y = y,
                z = z,
                speed = (float)(random.NextDouble() * 0.5 + 0.1),
                spheres = new List<Sphere>()
            };
            cloud.color = Math.Min(1.0f, (float)random.NextDouble() + 0.7f);
            int sphereCount = random.Next(20, 40); 
            for (int i = 0; i < sphereCount; i++)
            {
                cloud.spheres.Add(new Sphere
                {
                    offsetX = (float)(random.NextDouble() * 2 - 1) * 3, 
                    offsetY = (float)(random.NextDouble() * 2 - 1) * 1.5f,
                    offsetZ = (float)(random.NextDouble() * 2 - 1) * 3,
                    radius = (float)(random.NextDouble() * 1.2 + 0.8) 
                });
            }

            cloudList.Add(cloud);
        }

        public void Update()
        {
            if (this.speed == 0)
                return;

            foreach (var cloud in cloudList)
            {
                cloud.x += cloud.speed * this.speed;

                if (cloud.x > gridSize / 2)
                {
                    cloud.x = -gridSize / 2;
                    cloud.z = (float)(random.NextDouble() * gridSize - gridSize / 2);
                }
            }
        }

        public void Render()
        {
            foreach (var cloud in cloudList)
            {
                foreach (var sphere in cloud.spheres)
                {
                    glPushMatrix();
                    glTranslatef(cloud.x + sphere.offsetX, cloud.y + sphere.offsetY, cloud.z + sphere.offsetZ);
                    glScalef(sphere.radius, sphere.radius, sphere.radius);
                    glEnable(GL_BLEND);
                    glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

                    float c = cloud.color;
                    glColor4f(c, c, c, 0.75f);

                    RenderSphere();
                    glDisable(GL_BLEND);

                    glPopMatrix();
                }
            }
        }

        private void RenderSphere()
        {
            IntPtr quad = gluNewQuadric();
            gluSphere(quad, 1.0, 12, 12);
            gluDeleteQuadric(quad);
        }

        public void SetCloudHeight(float newHeight)
        {
            cloudHeight = newHeight;
            foreach (var cloud in cloudList)
            {
                cloud.y = cloudHeight; 
            }
        }

        public void SetCloudSpeed(float newSpeed)
        {
            this.speed = newSpeed;
        }
    }

}
