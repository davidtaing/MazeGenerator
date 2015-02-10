namespace MazeDisplay
{
    partial class ChangeSizeForm
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
            this.numericUpDown_Height = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Width = new System.Windows.Forms.NumericUpDown();
            this.label_Height = new System.Windows.Forms.Label();
            this.label_Width = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Width)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_Height
            // 
            this.numericUpDown_Height.Location = new System.Drawing.Point(70, 9);
            this.numericUpDown_Height.Name = "numericUpDown_Height";
            this.numericUpDown_Height.Size = new System.Drawing.Size(42, 20);
            this.numericUpDown_Height.TabIndex = 0;
            // 
            // numericUpDown_Width
            // 
            this.numericUpDown_Width.Location = new System.Drawing.Point(70, 35);
            this.numericUpDown_Width.Name = "numericUpDown_Width";
            this.numericUpDown_Width.Size = new System.Drawing.Size(42, 20);
            this.numericUpDown_Width.TabIndex = 0;
            // 
            // label_Height
            // 
            this.label_Height.AutoSize = true;
            this.label_Height.Location = new System.Drawing.Point(12, 11);
            this.label_Height.Name = "label_Height";
            this.label_Height.Size = new System.Drawing.Size(38, 13);
            this.label_Height.TabIndex = 1;
            this.label_Height.Text = "Height";
            // 
            // label_Width
            // 
            this.label_Width.AutoSize = true;
            this.label_Width.Location = new System.Drawing.Point(12, 37);
            this.label_Width.Name = "label_Width";
            this.label_Width.Size = new System.Drawing.Size(35, 13);
            this.label_Width.TabIndex = 1;
            this.label_Width.Text = "Width";
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(15, 61);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(97, 23);
            this.button_Save.TabIndex = 2;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // ChangeSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(124, 96);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.label_Width);
            this.Controls.Add(this.label_Height);
            this.Controls.Add(this.numericUpDown_Width);
            this.Controls.Add(this.numericUpDown_Height);
            this.Name = "ChangeSizeForm";
            this.Text = "ChangeSizeForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Width)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_Height;
        private System.Windows.Forms.NumericUpDown numericUpDown_Width;
        private System.Windows.Forms.Label label_Height;
        private System.Windows.Forms.Label label_Width;
        private System.Windows.Forms.Button button_Save;
    }
}