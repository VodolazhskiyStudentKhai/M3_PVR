using System;
using System.Diagnostics;

namespace openGLProject
{
    public partial class RenderControl : OpenGL
    {
        public Params Par = new Params();

        private int gridSize = 200; // Размер сетки

        private Terrain terrain;
        private Water water;
        private Sky sky;
        private Clouds clouds; // Поле для облаков
        private Fog fog;

        private bool wireframe = false;

        public RenderControl()
        {
            InitializeComponent();
            sky = new Sky();

            terrain = new Terrain(gridSize);
            clouds = new Clouds(10, gridSize, 15f, 1.0f);
            fog = new Fog(0.0f, 20.0f); // Максимальная плотность тумана, дальность обзора


            water = new Water(gridSize, 2.0f, 0.6f); // Размеры, уровень воды и прозрачность
        }

        private void OnRender(object sender, EventArgs e)
        {
            water.UpdateTime(0.2f);
            sky.UpdateSky(); // Обновление состояния неба
            clouds.Update();
            sky.RenderSky(); // Рендеринг неба
            RenderScene();
            this.Invalidate();
        }

        private void RenderScene()
        {
            // Очистка буферов
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

            // Установка области отображения
            setViewPort();

            // Установка проекционной матрицы
            glMatrixMode(GL_PROJECTION);
            glLoadIdentity();

            if (Par.perspective)
            {
                gluPerspective(75, Width / Height, 0.5, Par.l * 10);
                glTranslated(0, -Par.h, -Par.l - 10);
            }
            else
            {
                glOrtho(-Par.w, Par.w, -Par.h, Par.h, -Par.l * 10, Par.l * 10);
            }

            // Установка модели-вида
            glMatrixMode(GL_MODELVIEW);
            glLoadIdentity();
            glRotated(Par.rx, 1, 0, 0);
            glRotated(Par.ry, 0, 1, 0);
            glScaled(Par.m, Par.m, Par.m);

            // Включение теста глубины и отрисовка
            glEnable(GL_DEPTH_TEST);
            glPolygonMode(GL_FRONT_AND_BACK, wireframe ? GL_LINE : GL_FILL);

            terrain.CreateTerrainDisplay();
            water.RenderWater();
            clouds.Render();
            fog.Render(Par);

            glDisable(GL_DEPTH_TEST);

            // Завершение рендера
            glFlush();
        }

        private void setViewPort()
        {
            if (Width > Height)
            {
                glViewport((Width - Height) / 2, 0, Height, Height);
            }
            else
            {
                glViewport(0, (Height - Width) / 2, Width, Width);
            }
        }
        public void ToggleWireframe() { wireframe = !wireframe; }
        public bool getWireframe()
        {
            return wireframe;
        }

        public void ToggleGradient()
        {
            terrain.ToggleGradient();
        }
        public bool getTerGradient()
        {
            return terrain.getGradient();
        }
        public void setDatailLevel(float d)
        {
            terrain.setDatailLevel(d);
        }
        public void setVoidFactor(float d)
        {
            terrain.setVoidFactor(d);
        }
        public void setDaySpeed(float s )
        {
            sky.setDaySpeed(s);
        }
        public void SetFogDensity(float f)
        {
            fog.SetDensity(f);
        }
        public void setWaterLevel(float s)
        {
            water.SetWaterLevel(s);
        }
        public void setWaveSpeed(float s)
        {
            water.SetWaveSpeed(s);
        }
        public void setWaterTransparency(float s)
        {
            water.SetTransparency(s);
        }
        public void SetCloudsHeight(float f)
        {
            clouds.SetCloudHeight(f);
        }
        public void SetCloudsSpeed(float f)
        {
            clouds.SetCloudSpeed(f);
        }

    }

}