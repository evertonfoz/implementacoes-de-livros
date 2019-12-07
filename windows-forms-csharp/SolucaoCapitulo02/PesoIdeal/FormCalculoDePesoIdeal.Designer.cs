namespace PesoIdeal
{
    partial class FormCalculoDePesoIdeal
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
            this.gbxSexo = new System.Windows.Forms.GroupBox();
            this.rbnFeminino = new System.Windows.Forms.RadioButton();
            this.rbnMasculino = new System.Windows.Forms.RadioButton();
            this.lblAltura = new System.Windows.Forms.Label();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.lblPesoIdeal = new System.Windows.Forms.Label();
            this.lblPesoIdealValue = new System.Windows.Forms.Label();
            this.gbxSexo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxSexo
            // 
            this.gbxSexo.Controls.Add(this.rbnFeminino);
            this.gbxSexo.Controls.Add(this.rbnMasculino);
            this.gbxSexo.Location = new System.Drawing.Point(12, 12);
            this.gbxSexo.Name = "gbxSexo";
            this.gbxSexo.Size = new System.Drawing.Size(158, 45);
            this.gbxSexo.TabIndex = 0;
            this.gbxSexo.TabStop = false;
            this.gbxSexo.Text = "Sexo";
            // 
            // rbnFeminino
            // 
            this.rbnFeminino.AutoSize = true;
            this.rbnFeminino.Location = new System.Drawing.Point(85, 19);
            this.rbnFeminino.Name = "rbnFeminino";
            this.rbnFeminino.Size = new System.Drawing.Size(67, 17);
            this.rbnFeminino.TabIndex = 1;
            this.rbnFeminino.TabStop = true;
            this.rbnFeminino.Text = "Feminino";
            this.rbnFeminino.UseVisualStyleBackColor = true;
            this.rbnFeminino.CheckedChanged += new System.EventHandler(this.rbnMasculino_CheckedChanged);
            // 
            // rbnMasculino
            // 
            this.rbnMasculino.AutoSize = true;
            this.rbnMasculino.Location = new System.Drawing.Point(6, 19);
            this.rbnMasculino.Name = "rbnMasculino";
            this.rbnMasculino.Size = new System.Drawing.Size(73, 17);
            this.rbnMasculino.TabIndex = 0;
            this.rbnMasculino.TabStop = true;
            this.rbnMasculino.Text = "Masculino";
            this.rbnMasculino.UseVisualStyleBackColor = true;
            this.rbnMasculino.CheckedChanged += new System.EventHandler(this.rbnMasculino_CheckedChanged);
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(176, 15);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(37, 13);
            this.lblAltura.TabIndex = 1;
            this.lblAltura.Text = "Altura:";
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(179, 32);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(101, 20);
            this.txtAltura.TabIndex = 2;
            this.txtAltura.TextChanged += new System.EventHandler(this.txtAltura_TextChanged);
            // 
            // lblPesoIdeal
            // 
            this.lblPesoIdeal.AutoSize = true;
            this.lblPesoIdeal.Location = new System.Drawing.Point(113, 60);
            this.lblPesoIdeal.Name = "lblPesoIdeal";
            this.lblPesoIdeal.Size = new System.Drawing.Size(57, 13);
            this.lblPesoIdeal.TabIndex = 3;
            this.lblPesoIdeal.Text = "Peso Ideal";
            // 
            // lblPesoIdealValue
            // 
            this.lblPesoIdealValue.AutoSize = true;
            this.lblPesoIdealValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesoIdealValue.ForeColor = System.Drawing.Color.Red;
            this.lblPesoIdealValue.Location = new System.Drawing.Point(117, 77);
            this.lblPesoIdealValue.Name = "lblPesoIdealValue";
            this.lblPesoIdealValue.Size = new System.Drawing.Size(53, 25);
            this.lblPesoIdealValue.TabIndex = 4;
            this.lblPesoIdealValue.Text = "label";
            // 
            // FormCalculoDePesoIdeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 111);
            this.Controls.Add(this.lblPesoIdealValue);
            this.Controls.Add(this.lblPesoIdeal);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.gbxSexo);
            this.Name = "FormCalculoDePesoIdeal";
            this.Text = "Cálculo do peso ideal";
            this.gbxSexo.ResumeLayout(false);
            this.gbxSexo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSexo;
        private System.Windows.Forms.RadioButton rbnFeminino;
        private System.Windows.Forms.RadioButton rbnMasculino;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label lblPesoIdeal;
        private System.Windows.Forms.Label lblPesoIdealValue;
    }
}

