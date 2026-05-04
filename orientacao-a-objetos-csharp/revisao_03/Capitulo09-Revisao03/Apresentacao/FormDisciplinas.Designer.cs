namespace Apresentacao
{
    partial class FormDisciplinas
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cbxCursos = new System.Windows.Forms.ComboBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.BtnGravar = new System.Windows.Forms.Button();
            this.BtnNovo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnRemover = new System.Windows.Forms.Button();
            this.dgvDisciplinas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisciplinas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Curso:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nome:";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(61, 15);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(63, 23);
            this.txtID.TabIndex = 3;
            // 
            // cbxCursos
            // 
            this.cbxCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCursos.FormattingEnabled = true;
            this.cbxCursos.Location = new System.Drawing.Point(61, 44);
            this.cbxCursos.Name = "cbxCursos";
            this.cbxCursos.Size = new System.Drawing.Size(316, 23);
            this.cbxCursos.TabIndex = 4;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(61, 73);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(316, 23);
            this.txtNome.TabIndex = 5;
            // 
            // BtnGravar
            // 
            this.BtnGravar.Location = new System.Drawing.Point(204, 112);
            this.BtnGravar.Name = "BtnGravar";
            this.BtnGravar.Size = new System.Drawing.Size(75, 23);
            this.BtnGravar.TabIndex = 6;
            this.BtnGravar.Text = "Gravar";
            this.BtnGravar.UseVisualStyleBackColor = true;
            this.BtnGravar.Click += new System.EventHandler(this.BtnGravar_Click);
            // 
            // BtnNovo
            // 
            this.BtnNovo.Location = new System.Drawing.Point(12, 112);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(75, 23);
            this.BtnNovo.TabIndex = 7;
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.UseVisualStyleBackColor = true;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(108, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Alterar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // BtnRemover
            // 
            this.BtnRemover.Location = new System.Drawing.Point(300, 112);
            this.BtnRemover.Name = "BtnRemover";
            this.BtnRemover.Size = new System.Drawing.Size(75, 23);
            this.BtnRemover.TabIndex = 9;
            this.BtnRemover.Text = "Remover";
            this.BtnRemover.UseVisualStyleBackColor = true;
            this.BtnRemover.Click += new System.EventHandler(this.BtnRemover_Click);
            // 
            // dgvDisciplinas
            // 
            this.dgvDisciplinas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvDisciplinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisciplinas.Location = new System.Drawing.Point(12, 147);
            this.dgvDisciplinas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvDisciplinas.Name = "dgvDisciplinas";
            this.dgvDisciplinas.Size = new System.Drawing.Size(361, 180);
            this.dgvDisciplinas.TabIndex = 5;
            this.dgvDisciplinas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDisciplinas_CellClick);
            // 
            // FormDisciplinas
            // 
            this.ClientSize = new System.Drawing.Size(382, 331);
            this.Controls.Add(this.dgvDisciplinas);
            this.Controls.Add(this.BtnRemover);
            this.Controls.Add(this.BtnGravar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtnNovo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxCursos);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "FormDisciplinas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisciplinas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cbxCursos;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button BtnGravar;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnRemover;
        private System.Windows.Forms.DataGridView dgvDisciplinas;
    }
}