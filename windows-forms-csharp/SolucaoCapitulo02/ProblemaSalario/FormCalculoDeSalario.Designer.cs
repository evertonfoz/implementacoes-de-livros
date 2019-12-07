namespace ProblemaSalario
{
    partial class FormCalculoDeSalario
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
            this.components = new System.ComponentModel.Container();
            this.lblSalarioMinimo = new System.Windows.Forms.Label();
            this.txtSalarioMinimo = new System.Windows.Forms.TextBox();
            this.lblHorasTrabalhadas = new System.Windows.Forms.Label();
            this.txtHorasTrabalhadas = new System.Windows.Forms.TextBox();
            this.gbxCategoria = new System.Windows.Forms.GroupBox();
            this.rbnCalouro = new System.Windows.Forms.RadioButton();
            this.rbnVeterano = new System.Windows.Forms.RadioButton();
            this.gbxTurno = new System.Windows.Forms.GroupBox();
            this.rbnVespertino = new System.Windows.Forms.RadioButton();
            this.rbnMatunino = new System.Windows.Forms.RadioButton();
            this.lbxResumo = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rbnNoturno = new System.Windows.Forms.RadioButton();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtSituacaoEstagiario = new System.Windows.Forms.TextBox();
            this.gbxCategoria.SuspendLayout();
            this.gbxTurno.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSalarioMinimo
            // 
            this.lblSalarioMinimo.AutoSize = true;
            this.lblSalarioMinimo.Location = new System.Drawing.Point(12, 15);
            this.lblSalarioMinimo.Name = "lblSalarioMinimo";
            this.lblSalarioMinimo.Size = new System.Drawing.Size(80, 13);
            this.lblSalarioMinimo.TabIndex = 0;
            this.lblSalarioMinimo.Text = "Salário Mínimo:";
            // 
            // txtSalarioMinimo
            // 
            this.txtSalarioMinimo.Location = new System.Drawing.Point(118, 12);
            this.txtSalarioMinimo.Name = "txtSalarioMinimo";
            this.txtSalarioMinimo.Size = new System.Drawing.Size(100, 20);
            this.txtSalarioMinimo.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtSalarioMinimo, "Informe o valor atual para o salário mínimo");
            // 
            // lblHorasTrabalhadas
            // 
            this.lblHorasTrabalhadas.AutoSize = true;
            this.lblHorasTrabalhadas.Location = new System.Drawing.Point(12, 40);
            this.lblHorasTrabalhadas.Name = "lblHorasTrabalhadas";
            this.lblHorasTrabalhadas.Size = new System.Drawing.Size(100, 13);
            this.lblHorasTrabalhadas.TabIndex = 2;
            this.lblHorasTrabalhadas.Text = "Horas Trabalhadas:";
            // 
            // txtHorasTrabalhadas
            // 
            this.txtHorasTrabalhadas.Location = new System.Drawing.Point(118, 37);
            this.txtHorasTrabalhadas.Name = "txtHorasTrabalhadas";
            this.txtHorasTrabalhadas.Size = new System.Drawing.Size(100, 20);
            this.txtHorasTrabalhadas.TabIndex = 3;
            // 
            // gbxCategoria
            // 
            this.gbxCategoria.Controls.Add(this.rbnVeterano);
            this.gbxCategoria.Controls.Add(this.rbnCalouro);
            this.gbxCategoria.Location = new System.Drawing.Point(15, 57);
            this.gbxCategoria.Name = "gbxCategoria";
            this.gbxCategoria.Size = new System.Drawing.Size(203, 45);
            this.gbxCategoria.TabIndex = 4;
            this.gbxCategoria.TabStop = false;
            this.gbxCategoria.Text = "Categoria";
            // 
            // rbnCalouro
            // 
            this.rbnCalouro.AutoSize = true;
            this.rbnCalouro.Location = new System.Drawing.Point(12, 19);
            this.rbnCalouro.Name = "rbnCalouro";
            this.rbnCalouro.Size = new System.Drawing.Size(61, 17);
            this.rbnCalouro.TabIndex = 0;
            this.rbnCalouro.TabStop = true;
            this.rbnCalouro.Text = "Calouro";
            this.rbnCalouro.UseVisualStyleBackColor = true;
            // 
            // rbnVeterano
            // 
            this.rbnVeterano.AutoSize = true;
            this.rbnVeterano.Location = new System.Drawing.Point(103, 18);
            this.rbnVeterano.Name = "rbnVeterano";
            this.rbnVeterano.Size = new System.Drawing.Size(68, 17);
            this.rbnVeterano.TabIndex = 1;
            this.rbnVeterano.TabStop = true;
            this.rbnVeterano.Text = "Veterano";
            this.rbnVeterano.UseVisualStyleBackColor = true;
            // 
            // gbxTurno
            // 
            this.gbxTurno.Controls.Add(this.rbnNoturno);
            this.gbxTurno.Controls.Add(this.rbnVespertino);
            this.gbxTurno.Controls.Add(this.rbnMatunino);
            this.gbxTurno.Location = new System.Drawing.Point(224, 6);
            this.gbxTurno.Name = "gbxTurno";
            this.gbxTurno.Size = new System.Drawing.Size(86, 96);
            this.gbxTurno.TabIndex = 5;
            this.gbxTurno.TabStop = false;
            this.gbxTurno.Text = "Turno";
            // 
            // rbnVespertino
            // 
            this.rbnVespertino.AutoSize = true;
            this.rbnVespertino.Location = new System.Drawing.Point(6, 46);
            this.rbnVespertino.Name = "rbnVespertino";
            this.rbnVespertino.Size = new System.Drawing.Size(75, 17);
            this.rbnVespertino.TabIndex = 1;
            this.rbnVespertino.TabStop = true;
            this.rbnVespertino.Text = "Vespertino";
            this.rbnVespertino.UseVisualStyleBackColor = true;
            // 
            // rbnMatunino
            // 
            this.rbnMatunino.AutoSize = true;
            this.rbnMatunino.Location = new System.Drawing.Point(6, 23);
            this.rbnMatunino.Name = "rbnMatunino";
            this.rbnMatunino.Size = new System.Drawing.Size(66, 17);
            this.rbnMatunino.TabIndex = 0;
            this.rbnMatunino.TabStop = true;
            this.rbnMatunino.Text = "Matutino";
            this.rbnMatunino.UseVisualStyleBackColor = true;
            // 
            // lbxResumo
            // 
            this.lbxResumo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxResumo.FormattingEnabled = true;
            this.lbxResumo.ItemHeight = 14;
            this.lbxResumo.Location = new System.Drawing.Point(15, 108);
            this.lbxResumo.Name = "lbxResumo";
            this.lbxResumo.Size = new System.Drawing.Size(295, 130);
            this.lbxResumo.TabIndex = 6;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Ajuda";
            // 
            // rbnNoturno
            // 
            this.rbnNoturno.AutoSize = true;
            this.rbnNoturno.Location = new System.Drawing.Point(6, 69);
            this.rbnNoturno.Name = "rbnNoturno";
            this.rbnNoturno.Size = new System.Drawing.Size(63, 17);
            this.rbnNoturno.TabIndex = 2;
            this.rbnNoturno.TabStop = true;
            this.rbnNoturno.Text = "Noturno";
            this.rbnNoturno.UseVisualStyleBackColor = true;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(235, 248);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 7;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // txtSituacaoEstagiario
            // 
            this.txtSituacaoEstagiario.BackColor = System.Drawing.Color.Yellow;
            this.txtSituacaoEstagiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSituacaoEstagiario.ForeColor = System.Drawing.Color.Blue;
            this.txtSituacaoEstagiario.Location = new System.Drawing.Point(15, 251);
            this.txtSituacaoEstagiario.Name = "txtSituacaoEstagiario";
            this.txtSituacaoEstagiario.Size = new System.Drawing.Size(214, 20);
            this.txtSituacaoEstagiario.TabIndex = 8;
            this.txtSituacaoEstagiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormCalculoDeSalario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 279);
            this.Controls.Add(this.txtSituacaoEstagiario);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lbxResumo);
            this.Controls.Add(this.gbxTurno);
            this.Controls.Add(this.gbxCategoria);
            this.Controls.Add(this.txtHorasTrabalhadas);
            this.Controls.Add(this.lblHorasTrabalhadas);
            this.Controls.Add(this.txtSalarioMinimo);
            this.Controls.Add(this.lblSalarioMinimo);
            this.Name = "FormCalculoDeSalario";
            this.Text = "Cálculo de Salário";
            this.gbxCategoria.ResumeLayout(false);
            this.gbxCategoria.PerformLayout();
            this.gbxTurno.ResumeLayout(false);
            this.gbxTurno.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSalarioMinimo;
        private System.Windows.Forms.TextBox txtSalarioMinimo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblHorasTrabalhadas;
        private System.Windows.Forms.TextBox txtHorasTrabalhadas;
        private System.Windows.Forms.GroupBox gbxCategoria;
        private System.Windows.Forms.RadioButton rbnVeterano;
        private System.Windows.Forms.RadioButton rbnCalouro;
        private System.Windows.Forms.GroupBox gbxTurno;
        private System.Windows.Forms.RadioButton rbnNoturno;
        private System.Windows.Forms.RadioButton rbnVespertino;
        private System.Windows.Forms.RadioButton rbnMatunino;
        private System.Windows.Forms.ListBox lbxResumo;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.TextBox txtSituacaoEstagiario;
    }
}

