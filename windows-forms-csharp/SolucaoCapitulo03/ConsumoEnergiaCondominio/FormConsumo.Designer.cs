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
            this.lblCasa = new System.Windows.Forms.Label();
            this.lblConsumo = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.txtCasa = new System.Windows.Forms.TextBox();
            this.txtConsumo = new System.Windows.Forms.TextBox();
            this.btnProcessar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.dgvLeituras = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeituras)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCasa
            // 
            this.lblCasa.AutoSize = true;
            this.lblCasa.Location = new System.Drawing.Point(12, 9);
            this.lblCasa.Name = "lblCasa";
            this.lblCasa.Size = new System.Drawing.Size(51, 13);
            this.lblCasa.TabIndex = 0;
            this.lblCasa.Text = "Nr. Casa:";
            // 
            // lblConsumo
            // 
            this.lblConsumo.AutoSize = true;
            this.lblConsumo.Location = new System.Drawing.Point(132, 9);
            this.lblConsumo.Name = "lblConsumo";
            this.lblConsumo.Size = new System.Drawing.Size(54, 13);
            this.lblConsumo.TabIndex = 1;
            this.lblConsumo.Text = "Consumo:";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(298, 4);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 2;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // txtCasa
            // 
            this.txtCasa.Location = new System.Drawing.Point(69, 6);
            this.txtCasa.Name = "txtCasa";
            this.txtCasa.Size = new System.Drawing.Size(57, 20);
            this.txtCasa.TabIndex = 3;
            // 
            // txtConsumo
            // 
            this.txtConsumo.Location = new System.Drawing.Point(192, 6);
            this.txtConsumo.Name = "txtConsumo";
            this.txtConsumo.Size = new System.Drawing.Size(100, 20);
            this.txtConsumo.TabIndex = 4;
            // 
            // btnProcessar
            // 
            this.btnProcessar.Location = new System.Drawing.Point(15, 256);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(115, 23);
            this.btnProcessar.TabIndex = 5;
            this.btnProcessar.Text = "Processar dados";
            this.btnProcessar.UseVisualStyleBackColor = true;
            this.btnProcessar.Click += new System.EventHandler(this.BtnProcessar_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(136, 261);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 13);
            this.lblResultado.TabIndex = 6;
            // 
            // dgvLeituras
            // 
            this.dgvLeituras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeituras.Location = new System.Drawing.Point(15, 32);
            this.dgvLeituras.Name = "dgvLeituras";
            this.dgvLeituras.Size = new System.Drawing.Size(358, 218);
            this.dgvLeituras.TabIndex = 7;
            // 
            // FormConsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 287);
            this.Controls.Add(this.dgvLeituras);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnProcessar);
            this.Controls.Add(this.txtConsumo);
            this.Controls.Add(this.txtCasa);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.lblConsumo);
            this.Controls.Add(this.lblCasa);
            this.Name = "FormConsumo";
            this.Text = "Consumo de energia de um condomínio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeituras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCasa;
        private System.Windows.Forms.Label lblConsumo;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.TextBox txtCasa;
        private System.Windows.Forms.TextBox txtConsumo;
        private System.Windows.Forms.Button btnProcessar;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.DataGridView dgvLeituras;
    }
}

