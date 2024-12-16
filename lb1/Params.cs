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
        public double h = 10.0;
        public double l = 10.0;
        public double rx = 32.5, ry = -41.5;
        public double m = 1.0;
        public bool perspective = true;

        public double[] clip = new double[] { 0, 1, 1, -0.5 };
        public double get_m() {
            return m;
        }
        public void set_m(double v) {
            m = Math.Max(v, 1.0);
        }
    }
    
}
