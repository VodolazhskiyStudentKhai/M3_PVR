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

namespace openGLProject
{
    public class Sky
    {
        private float r, g, b; // Цвет неба
        private float timeOfDay = 0.0f; // Время суток
        private float daySpeed = 0.0f; // Скорость смены времени суток

        public Sky()
        {
            r = 0.5f;
            g = 0.7f;
            b = 1.0f;
        }

        public void UpdateSky()
        {
            // Обновление времени суток
            timeOfDay += daySpeed;
            if (timeOfDay > 1.0f) timeOfDay = 0.0f;

            // Логика цвета неба
            if (timeOfDay < 0.25f)
            {
                r = Lerp(0.2f, 0.5f, timeOfDay / 0.25f);
                g = Lerp(0.2f, 0.7f, timeOfDay / 0.25f);
                b = Lerp(0.4f, 1.0f, timeOfDay / 0.25f);
            }
            else if (timeOfDay < 0.5f)
            {
                r = 0.5f;
                g = 0.7f;
                b = 1.0f;
            }
            else if (timeOfDay < 0.75f)
            {
                r = Lerp(0.5f, 0.8f, (timeOfDay - 0.5f) / 0.25f);
                g = Lerp(0.7f, 0.4f, (timeOfDay - 0.5f) / 0.25f);
                b = Lerp(1.0f, 0.2f, (timeOfDay - 0.5f) / 0.25f);
            }
            else
            {
                r = Lerp(0.8f, 0.2f, (timeOfDay - 0.75f) / 0.25f);
                g = Lerp(0.4f, 0.2f, (timeOfDay - 0.75f) / 0.25f);
                b = Lerp(0.2f, 0.1f, (timeOfDay - 0.75f) / 0.25f);
            }
        }

        public void RenderSky()
        {
            // Установка цвета фона
            glClearColor(r, g, b, 1.0f);
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        }

        private float Lerp(float start, float end, float t)
        {
            return start + t * (end - start);
        }

        public void setDaySpeed(float s)
        {
            daySpeed = Math.Clamp(s, 0.001f, 1.0f);
        }
    }

}

