using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Numerics;
using System.Transactions;
using static openGLProject.OpenGL;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;

namespace openGLProject
{
    public class Light
    {
        public Light()
        {
            glEnable(GL_LIGHTING);
            glEnable(GL_LIGHT0);
            glColorMaterial(GL_FRONT, GL_AMBIENT_AND_DIFFUSE);
            glEnable(GL_COLOR_MATERIAL);
            float[] lightPosition = { 2f, 0.0f, 7f, 1.0f };
            glLightfv(GL_LIGHT0, GL_POSITION, lightPosition);
        }
    }
}

