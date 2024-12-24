using System;
using System.Diagnostics;

namespace openGLProject
{
    public partial class RenderControl : OpenGL
    {
        public Params Cam = new Params();

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

            if (Cam.perspective) {
                gluPerspective(75, Width / Height, 0.5, Cam.draw_dist);
                glTranslated(0, -Cam.h, -Cam.l - 20.0);
            }
            else {
                glOrtho(-Cam.w, Cam.w, -Cam.h, Cam.h, -Cam.l * 10, Cam.l * 10);
            }

            // Установка модели-вида
            glMatrixMode(GL_MODELVIEW);
            glLoadIdentity();
            glRotated(Cam.rx, 1, 0, 0);
            glRotated(Cam.ry, 0, 1, 0);
            glScaled(Cam.m, Cam.m, Cam.m);

            // Включение теста глубины и отрисовка
            glEnable(GL_DEPTH_TEST);
            glPolygonMode(GL_FRONT_AND_BACK, wireframe ? GL_LINE : GL_FILL);

            terrain.CreateTerrainDisplay();
            water.RenderWater();
            clouds.Render();
            fog.Render(Cam);

            glDisable(GL_DEPTH_TEST);

            // Завершение рендера
            glFlush();
            Debug.WriteLine($"Camera position: x=0, y={Cam.h}, z={Cam.l}");
            Debug.WriteLine($"Terrain position: x=0, y=0, z=0");

        }

        private void setViewPort()
        {
            if (Width > Height) {
                glViewport((Width - Height) / 2, 0, Height, Height);
            }
            else {
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