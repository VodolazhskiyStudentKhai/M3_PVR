
using System.Windows.Forms;

namespace openGLProject
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            renderer = new RenderControl();
            button1 = new Button();
            label1 = new Label();
            label6 = new Label();
            button2 = new Button();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            button3 = new Button();
            numericUpDown2 = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            numericUpDown3 = new NumericUpDown();
            label5 = new Label();
            numericUpDown4 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            numericUpDown6 = new NumericUpDown();
            numericUpDown7 = new NumericUpDown();
            numericUpDown8 = new NumericUpDown();
            numericUpDown9 = new NumericUpDown();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).BeginInit();
            SuspendLayout();
            // 
            // renderer
            // 
            renderer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            renderer.BackColor = System.Drawing.Color.SlateGray;
            renderer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            renderer.ForeColor = System.Drawing.Color.Red;
            renderer.Location = new System.Drawing.Point(-6, -2);
            renderer.Name = "renderer";
            renderer.Size = new System.Drawing.Size(570, 444);
            renderer.TabIndex = 0;
            renderer.TextCodePage = 1251;
            renderer.KeyDown += pressKey;
            renderer.MouseDown += Mouse_Down;
            renderer.MouseMove += Mouse_Move;
            renderer.MouseUp += Mouse_Up;
            renderer.MouseWheel += Mouse_Wheel;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button1.Location = new System.Drawing.Point(570, 333);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 25;
            button1.Text = "OFF";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(565, 313);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(80, 17);
            label1.TabIndex = 26;
            label1.Text = "Gradient on";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(565, 265);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(71, 17);
            label6.TabIndex = 27;
            label6.Text = "Viewmode";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackgroundImageLayout = ImageLayout.Center;
            button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button2.Location = new System.Drawing.Point(570, 362);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(85, 23);
            button2.TabIndex = 28;
            button2.Text = "wireframe";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown1.Location = new System.Drawing.Point(634, 9);
            numericUpDown1.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(67, 23);
            numericUpDown1.TabIndex = 0;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(566, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(45, 17);
            label2.TabIndex = 29;
            label2.Text = "Detail:";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.BackgroundImageLayout = ImageLayout.Center;
            button3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button3.Location = new System.Drawing.Point(570, 285);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(101, 25);
            button3.TabIndex = 30;
            button3.Text = "Ortho";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown2.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown2.Location = new System.Drawing.Point(634, 38);
            numericUpDown2.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new System.Drawing.Size(67, 23);
            numericUpDown2.TabIndex = 31;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(566, 38);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 17);
            label3.TabIndex = 32;
            label3.Text = "Void level";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(566, 70);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(71, 17);
            label4.TabIndex = 33;
            label4.Text = "Day speed";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown3.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDown3.Location = new System.Drawing.Point(635, 70);
            numericUpDown3.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new System.Drawing.Size(67, 23);
            numericUpDown3.TabIndex = 34;
            numericUpDown3.ValueChanged += numericUpDown3_ValueChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(566, 96);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(31, 17);
            label5.TabIndex = 35;
            label5.Text = "Fog";
            // 
            // numericUpDown4
            // 
            numericUpDown4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericUpDown4.Location = new System.Drawing.Point(634, 96);
            numericUpDown4.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new System.Drawing.Size(67, 23);
            numericUpDown4.TabIndex = 36;
            numericUpDown4.ValueChanged += numericUpDown4_ValueChanged;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericUpDown5.DecimalPlaces = 2;
            numericUpDown5.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown5.Location = new System.Drawing.Point(635, 179);
            numericUpDown5.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new System.Drawing.Size(67, 23);
            numericUpDown5.TabIndex = 37;
            numericUpDown5.Value = new decimal(new int[] { 6, 0, 0, 65536 });
            numericUpDown5.ValueChanged += numericUpDown5_ValueChanged;
            // 
            // numericUpDown6
            // 
            numericUpDown6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericUpDown6.DecimalPlaces = 1;
            numericUpDown6.Location = new System.Drawing.Point(635, 208);
            numericUpDown6.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new System.Drawing.Size(67, 23);
            numericUpDown6.TabIndex = 38;
            numericUpDown6.Value = new decimal(new int[] { 15, 0, 0, 0 });
            numericUpDown6.ValueChanged += numericUpDown6_ValueChanged;
            // 
            // numericUpDown7
            // 
            numericUpDown7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericUpDown7.DecimalPlaces = 1;
            numericUpDown7.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numericUpDown7.Location = new System.Drawing.Point(634, 125);
            numericUpDown7.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new System.Drawing.Size(67, 23);
            numericUpDown7.TabIndex = 39;
            numericUpDown7.Value = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown7.ValueChanged += numericUpDown7_ValueChanged;
            // 
            // numericUpDown8
            // 
            numericUpDown8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericUpDown8.DecimalPlaces = 2;
            numericUpDown8.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown8.Location = new System.Drawing.Point(635, 150);
            numericUpDown8.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new System.Drawing.Size(67, 23);
            numericUpDown8.TabIndex = 40;
            numericUpDown8.ValueChanged += numericUpDown8_ValueChanged;
            // 
            // numericUpDown9
            // 
            numericUpDown9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericUpDown9.Location = new System.Drawing.Point(634, 239);
            numericUpDown9.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numericUpDown9.Name = "numericUpDown9";
            numericUpDown9.Size = new System.Drawing.Size(67, 23);
            numericUpDown9.TabIndex = 41;
            numericUpDown9.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown9.ValueChanged += numericUpDown9_ValueChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(565, 128);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(61, 17);
            label7.TabIndex = 42;
            label7.Text = "Water lvl";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label8.Location = new System.Drawing.Point(565, 150);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(70, 17);
            label8.TabIndex = 43;
            label8.Text = "Water spd";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label9.Location = new System.Drawing.Point(561, 185);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(74, 17);
            label9.TabIndex = 44;
            label9.Text = "Water alph";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label10.Location = new System.Drawing.Point(561, 208);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(60, 17);
            label10.TabIndex = 45;
            label10.Text = "Cloud lvl";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label11.Location = new System.Drawing.Point(561, 239);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(69, 17);
            label11.TabIndex = 46;
            label11.Text = "Cloud spd";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(713, 441);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(numericUpDown9);
            Controls.Add(numericUpDown8);
            Controls.Add(numericUpDown7);
            Controls.Add(numericUpDown6);
            Controls.Add(numericUpDown5);
            Controls.Add(numericUpDown4);
            Controls.Add(label5);
            Controls.Add(numericUpDown3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(numericUpDown2);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(renderer);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Main Form";
            MouseDown += Mouse_Down;
            MouseMove += Mouse_Move;
            MouseUp += Mouse_Up;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RenderControl renderer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private Label label2;
        private Button button3;
        private NumericUpDown numericUpDown2;
        private Label label3;
        private Label label4;
        private NumericUpDown numericUpDown3;
        private Label label5;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown6;
        private NumericUpDown numericUpDown7;
        private NumericUpDown numericUpDown8;
        private NumericUpDown numericUpDown9;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
    }
}

