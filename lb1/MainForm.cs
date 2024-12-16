using System;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Windows.Forms;
using static openGLProject.OpenGL;


namespace openGLProject
{
    public partial class MainForm : Form
    {
        double dx = 0, dy = 0;
        bool moveMouse = false;
        public MainForm()
        {
            InitializeComponent();
        }


        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            moveMouse = (e.Button == MouseButtons.Left);
            if (moveMouse)
            {
                dx = e.X;
                dy = e.Y;
            }

        }
        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (moveMouse)
            {

                renderer.Par.rx = renderer.Par.rx - (dy - e.Y) / 2.0;
                renderer.Par.ry = renderer.Par.ry - (dx - e.X) / 2.0;

                dx = e.X;
                dy = e.Y;
                renderer.Invalidate();
            }
        }
        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && moveMouse)
            {
                moveMouse = false;
            }


        }
        private void Mouse_Wheel(object sender, MouseEventArgs e)
        {
            double m = renderer.Par.get_m() + e.Delta / 120;
            renderer.Par.set_m(m);
            renderer.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            renderer.ToggleGradient();
            bool g = renderer.getTerGradient();

            button1.Text = (g) ? "OFF" : "ON";
            label1.Text = (g) ? "Gradient on" : "Gradient off";
            renderer.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = (!renderer.getWireframe()) ? "fill" : "wireframe";
            renderer.ToggleWireframe();
            renderer.Invalidate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            renderer.setDatailLevel((float)numericUpDown1.Value);
            renderer.Invalidate();
        }
        private void pressKey(object sender, KeyEventArgs e)
        {
            if (!renderer.Par.perspective)
                return;

            // Управление камерой
            switch (e.KeyCode)
            {
                case Keys.W:
                    renderer.Par.l -= 1.0f;
                    break;

                case Keys.S:
                    renderer.Par.l += 1.0f;
                    break;

                case Keys.Space:
                    renderer.Par.h += 1.0f;
                    break;

                case Keys.ControlKey:
                    renderer.Par.h -= 1.0f;
                    break;

                case Keys.A:
                    renderer.Par.ry -= 1.0f;
                    break;

                case Keys.D:
                    renderer.Par.ry += 1.0f;
                    break;

                case Keys.Q:
                    if (renderer.Par.rx > -90.0f)
                    { // Ограничение угла наклона вверх
                        renderer.Par.rx -= 1.0f;
                        renderer.Par.h += 0.2f;
                    }
                    break;

                case Keys.E:
                    if (renderer.Par.rx < 90.0f)
                    {  // Ограничение угла наклона вниз
                        renderer.Par.rx += 1.0f;
                        renderer.Par.h -= 0.2f;
                    }
                    break;
            }

            // Обновляем сцену
            Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool p = renderer.Par.perspective;

            renderer.Par.perspective = !p;

            button3.Text = (!p) ? "Ortho" : "Perspective";

            renderer.Invalidate();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            renderer.setVoidFactor((float)numericUpDown2.Value);
            renderer.Invalidate();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            renderer.setDaySpeed((float)numericUpDown3.Value / 3);
            renderer.Invalidate();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            renderer.SetFogDensity((float)numericUpDown4.Value * 0.15f);
            renderer.Invalidate();
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            renderer.setWaterLevel((float)numericUpDown7.Value);
            renderer.Invalidate();
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            renderer.setWaveSpeed((float)numericUpDown8.Value);
            renderer.Invalidate();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            renderer.setWaterTransparency((float)numericUpDown5.Value);
            renderer.Invalidate();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            renderer.SetCloudsHeight((float)numericUpDown6.Value);
            renderer.Invalidate();
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            renderer.SetCloudsSpeed((float)numericUpDown9.Value);
            renderer.Invalidate();
        }
    }
}
