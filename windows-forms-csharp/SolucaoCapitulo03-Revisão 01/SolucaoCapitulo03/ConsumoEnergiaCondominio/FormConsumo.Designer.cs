namespace ConsumoEnergiaCondominio
{
    partial class FormConsumo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCasa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConsumo = new System.Windows.Forms.TextBox();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.dgvLeituras = new System.Windows.Forms.DataGridView();
            this.BtnProcessar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeituras)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nr. Casa:";
            // 
            // txtCasa
            // 
            this.txtCasa.Location = new System.Drawing.Point(57, 12);
            this.txtCasa.Name = "txtCasa";
            this.txtCasa.Size = new System.Drawing.Size(52, 20);
            this.txtCasa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Consumo:";
            // 
            // txtConsumo
            // 
            this.txtConsumo.Location = new System.Drawing.Point(177, 12);
            this.txtConsumo.Name = "txtConsumo";
            this.txtConsumo.Size = new System.Drawing.Size(84, 20);
            this.txtConsumo.TabIndex = 3;
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Location = new System.Drawing.Point(267, 10);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(95, 23);
            this.BtnRegistrar.TabIndex = 4;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvLeituras
            // 
            this.dgvLeituras.AllowUserToAddRows = false;
            this.dgvLeituras.AllowUserToDeleteRows = false;
            this.dgvLeituras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeituras.Location = new System.Drawing.Point(11, 38);
            this.dgvLeituras.Name = "dgvLeituras";
            this.dgvLeituras.ReadOnly = true;
            this.dgvLeituras.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvLeituras.Size = new System.Drawing.Size(351, 219);
            this.dgvLeituras.TabIndex = 5;
            // 
            // BtnProcessar
            // 
            this.BtnProcessar.Location = new System.Drawing.Point(12, 263);
            this.BtnProcessar.Name = "BtnProcessar";
            this.BtnProcessar.Size = new System.Drawing.Size(97, 23);
            this.BtnProcessar.TabIndex = 6;
            this.BtnProcessar.Text = "Processar dados";
            this.BtnProcessar.UseVisualStyleBackColor = true;
            this.BtnProcessar.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.Location = new System.Drawing.Point(115, 261);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(247, 27);
            this.lblResultado.TabIndex = 7;
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormConsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 291);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.BtnProcessar);
            this.Controls.Add(this.dgvLeituras);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.txtConsumo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCasa);
            this.Controls.Add(this.label1);
            this.Name = "FormConsumo";
            this.Text = "Consumo de energia de um condomínio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeituras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCasa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConsumo;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.DataGridView dgvLeituras;
        private System.Windows.Forms.Button BtnProcessar;
        private System.Windows.Forms.Label lblResultado;
    }
}

