using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Numerics;
using System.Resources;
using static openGLProject.OpenGL;
using static System.Windows.Forms.LinkLabel;

namespace openGLProject
{
    public class Params
    {
        public double w = 10.0;
        public double h = 15.0;
        public double l = 10.0;
        public double rx = 25, ry = 135;
        public double m = 1.0;
        public bool perspective = true;
        public float draw_dist = 1000.0f; // Дальность прорисовки

        public double get_m() {
            return m;
        }
        public void set_m(double v) {
            m = Math.Max(v, 1.0);
        }
    }
    
}
