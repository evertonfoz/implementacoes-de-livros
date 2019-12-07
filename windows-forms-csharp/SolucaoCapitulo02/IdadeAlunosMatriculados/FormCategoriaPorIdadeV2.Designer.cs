namespace IdadeAlunosMatriculados
{
    partial class FormCategoriaPorIdadeV2
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
            this.lblNome = new System.Windows.Forms.Label();
            this.lblAnoNascimento = new System.Windows.Forms.Label();
            this.btnIdentificarCategoria = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblHoje = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblCategoriaValue = new System.Windows.Forms.Label();
            this.dtpDataDeNascimento = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(3, 9);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "&Nome:";
            // 
            // lblAnoNascimento
            // 
            this.lblAnoNascimento.AutoSize = true;
            this.lblAnoNascimento.Location = new System.Drawing.Point(3, 35);
            this.lblAnoNascimento.Name = "lblAnoNascimento";
            this.lblAnoNascimento.Size = new System.Drawing.Size(105, 13);
            this.lblAnoNascimento.TabIndex = 1;
            this.lblAnoNascimento.Text = "Data de nascimento:";
            // 
            // btnIdentificarCategoria
            // 
            this.btnIdentificarCategoria.Location = new System.Drawing.Point(6, 58);
            this.btnIdentificarCategoria.Name = "btnIdentificarCategoria";
            this.btnIdentificarCategoria.Size = new System.Drawing.Size(119, 23);
            this.btnIdentificarCategoria.TabIndex = 2;
            this.btnIdentificarCategoria.Text = "Identificar Categoria";
            this.btnIdentificarCategoria.UseVisualStyleBackColor = true;
            this.btnIdentificarCategoria.Click += new System.EventHandler(this.btnIdentificarCategoria_Click);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(44, 6);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(276, 20);
            this.txtNome.TabIndex = 3;
            // 
            // lblHoje
            // 
            this.lblHoje.AutoSize = true;
            this.lblHoje.Location = new System.Drawing.Point(199, 35);
            this.lblHoje.Name = "lblHoje";
            this.lblHoje.Size = new System.Drawing.Size(29, 13);
            this.lblHoje.TabIndex = 6;
            this.lblHoje.Text = "label";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(131, 63);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(55, 13);
            this.lblCategoria.TabIndex = 7;
            this.lblCategoria.Text = "Categoria:";
            // 
            // lblCategoriaValue
            // 
            this.lblCategoriaValue.BackColor = System.Drawing.Color.Yellow;
            this.lblCategoriaValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCategoriaValue.Location = new System.Drawing.Point(192, 58);
            this.lblCategoriaValue.Name = "lblCategoriaValue";
            this.lblCategoriaValue.Size = new System.Drawing.Size(128, 23);
            this.lblCategoriaValue.TabIndex = 8;
            this.lblCategoriaValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDataDeNascimento
            // 
            this.dtpDataDeNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataDeNascimento.Location = new System.Drawing.Point(114, 32);
            this.dtpDataDeNascimento.Name = "dtpDataDeNascimento";
            this.dtpDataDeNascimento.Size = new System.Drawing.Size(79, 20);
            this.dtpDataDeNascimento.TabIndex = 9;
            // 
            // FormCategoriaPorIdadeV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 86);
            this.Controls.Add(this.dtpDataDeNascimento);
            this.Controls.Add(this.lblCategoriaValue);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblHoje);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btnIdentificarCategoria);
            this.Controls.Add(this.lblAnoNascimento);
            this.Controls.Add(this.lblNome);
            this.Name = "FormCategoriaPorIdadeV2";
            this.Text = "Matrícula de aluno versão 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblAnoNascimento;
        private System.Windows.Forms.Button btnIdentificarCategoria;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblHoje;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblCategoriaValue;
        private System.Windows.Forms.DateTimePicker dtpDataDeNascimento;
    }
}

