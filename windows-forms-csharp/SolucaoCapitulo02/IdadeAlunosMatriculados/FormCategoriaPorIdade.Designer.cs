namespace IdadeAlunosMatriculados
{
    partial class FormCategoriaPorIdade
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
            this.txtAnoNascimento = new System.Windows.Forms.TextBox();
            this.txtAnoUltimoAniversario = new System.Windows.Forms.TextBox();
            this.lblAnoUltimoAniversario = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblCategoriaValue = new System.Windows.Forms.Label();
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
            this.lblAnoNascimento.Size = new System.Drawing.Size(86, 13);
            this.lblAnoNascimento.TabIndex = 1;
            this.lblAnoNascimento.Text = "&Ano nascimento:";
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
            // txtAnoNascimento
            // 
            this.txtAnoNascimento.Location = new System.Drawing.Point(95, 32);
            this.txtAnoNascimento.Name = "txtAnoNascimento";
            this.txtAnoNascimento.Size = new System.Drawing.Size(50, 20);
            this.txtAnoNascimento.TabIndex = 4;
            this.txtAnoNascimento.Validating += new System.ComponentModel.CancelEventHandler(this.txtAnoUltimoAniversario_Validating);
            // 
            // txtAnoUltimoAniversario
            // 
            this.txtAnoUltimoAniversario.Location = new System.Drawing.Point(270, 32);
            this.txtAnoUltimoAniversario.Name = "txtAnoUltimoAniversario";
            this.txtAnoUltimoAniversario.Size = new System.Drawing.Size(50, 20);
            this.txtAnoUltimoAniversario.TabIndex = 5;
            this.txtAnoUltimoAniversario.Enter += new System.EventHandler(this.txtAnoUltimoAniversario_Enter);
            this.txtAnoUltimoAniversario.Validating += new System.ComponentModel.CancelEventHandler(this.txtAnoUltimoAniversario_Validating);
            // 
            // lblAnoUltimoAniversario
            // 
            this.lblAnoUltimoAniversario.AutoSize = true;
            this.lblAnoUltimoAniversario.Location = new System.Drawing.Point(151, 35);
            this.lblAnoUltimoAniversario.Name = "lblAnoUltimoAniversario";
            this.lblAnoUltimoAniversario.Size = new System.Drawing.Size(113, 13);
            this.lblAnoUltimoAniversario.TabIndex = 6;
            this.lblAnoUltimoAniversario.Text = "An&o último aniversário:";
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
            // FormMatriculaDeAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 86);
            this.Controls.Add(this.lblCategoriaValue);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblAnoUltimoAniversario);
            this.Controls.Add(this.txtAnoUltimoAniversario);
            this.Controls.Add(this.txtAnoNascimento);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btnIdentificarCategoria);
            this.Controls.Add(this.lblAnoNascimento);
            this.Controls.Add(this.lblNome);
            this.Name = "FormMatriculaDeAluno";
            this.Text = "Matrícula de aluno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblAnoNascimento;
        private System.Windows.Forms.Button btnIdentificarCategoria;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtAnoNascimento;
        private System.Windows.Forms.TextBox txtAnoUltimoAniversario;
        private System.Windows.Forms.Label lblAnoUltimoAniversario;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblCategoriaValue;
    }
}

