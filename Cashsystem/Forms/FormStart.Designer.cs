namespace Cashsystem.Forms
{
    partial class FormStart
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
            this.buttonCashSystem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCashSystem
            // 
            this.buttonCashSystem.Location = new System.Drawing.Point(12, 12);
            this.buttonCashSystem.Name = "buttonCashSystem";
            this.buttonCashSystem.Size = new System.Drawing.Size(450, 50);
            this.buttonCashSystem.TabIndex = 0;
            this.buttonCashSystem.Text = "Kassensystem";
            this.buttonCashSystem.UseVisualStyleBackColor = true;
            this.buttonCashSystem.Click += new System.EventHandler(this.buttonCashSystem_Click);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 429);
            this.Controls.Add(this.buttonCashSystem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormStart";
            this.ShowIcon = false;
            this.Text = "Start";
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonCashSystem;
    }
}