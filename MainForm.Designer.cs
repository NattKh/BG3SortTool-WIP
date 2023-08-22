namespace BG3LootTableGenerator
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            userControl11 = new UserControl1();
            SuspendLayout();
            // 
            // userControl11
            // 
            userControl11.Location = new Point(56, 83);
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(1365, 675);
            userControl11.TabIndex = 0;
            userControl11.Load += UserControl11_Load;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1469, 859);
            Controls.Add(userControl11);
            Name = "MainForm";
            Text = "BG3Sort";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private UserControl1 userControl11;
    }
}