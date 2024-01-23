namespace Projekt2_Karwowski65859
{
    partial class pkMainForm
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
            this.btnRandomShapeForm = new System.Windows.Forms.Button();
            this.btnMouseShapeForm = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRandomShapeForm
            // 
            this.btnRandomShapeForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomShapeForm.Location = new System.Drawing.Point(129, 149);
            this.btnRandomShapeForm.Name = "btnRandomShapeForm";
            this.btnRandomShapeForm.Size = new System.Drawing.Size(295, 133);
            this.btnRandomShapeForm.TabIndex = 0;
            this.btnRandomShapeForm.Text = "Laboratorium Nr2 \r\n(prezentacja losowo\r\nwybranych figur geometrycznych)";
            this.btnRandomShapeForm.UseVisualStyleBackColor = true;
            this.btnRandomShapeForm.Click += new System.EventHandler(this.MoveToLabNr2);
            // 
            // btnMouseShapeForm
            // 
            this.btnMouseShapeForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMouseShapeForm.Location = new System.Drawing.Point(534, 149);
            this.btnMouseShapeForm.Name = "btnMouseShapeForm";
            this.btnMouseShapeForm.Size = new System.Drawing.Size(295, 133);
            this.btnMouseShapeForm.TabIndex = 1;
            this.btnMouseShapeForm.Text = "Projekt Indywidualny Nr2\r\n(prezentacja figur geometrycnych\r\nkreslonych mysza)";
            this.btnMouseShapeForm.UseVisualStyleBackColor = true;
            this.btnMouseShapeForm.Click += new System.EventHandler(this.btnMouseShapeForm_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(196, 47);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(578, 50);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Praktyczne poznanie paradygmatu Hermetyzacji, Dziedziczenia\r\ni Polimorfizmu na pr" +
    "zykladzie prezentacji figur geometrycznych";
            // 
            // pkMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 528);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.btnMouseShapeForm);
            this.Controls.Add(this.btnRandomShapeForm);
            this.Name = "pkMainForm";
            this.Text = "Poznawanie paradygmatu Hermetyzacji, dziedziczenia i polimorfizmu w C#";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.pkMainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRandomShapeForm;
        private System.Windows.Forms.Button btnMouseShapeForm;
        private System.Windows.Forms.Label TitleLabel;
    }
}

