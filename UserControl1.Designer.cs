namespace BG3LootTableGenerator
{
    partial class UserControl1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBoxSource = new TextBox();
            textBoxDestination = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(227, 33);
            button1.Name = "button1";
            button1.Size = new Size(809, 61);
            button1.TabIndex = 0;
            button1.Text = "UnpackLocation";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(227, 160);
            button2.Name = "button2";
            button2.Size = new Size(809, 64);
            button2.TabIndex = 1;
            button2.Text = "OutputLocation";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(500, 282);
            button3.Name = "button3";
            button3.Size = new Size(249, 105);
            button3.TabIndex = 2;
            button3.Text = "Sort";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBoxSource
            // 
            textBoxSource.Location = new Point(227, 100);
            textBoxSource.Name = "textBoxSource";
            textBoxSource.Size = new Size(809, 31);
            textBoxSource.TabIndex = 3;
            // 
            // textBoxDestination
            // 
            textBoxDestination.Location = new Point(227, 230);
            textBoxDestination.Name = "textBoxDestination";
            textBoxDestination.Size = new Size(809, 31);
            textBoxDestination.TabIndex = 4;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxDestination);
            Controls.Add(textBoxSource);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "UserControl1";
            Size = new Size(1372, 850);
            Load += UserControl1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBoxSource;
        private TextBox textBoxDestination;
    }
}
