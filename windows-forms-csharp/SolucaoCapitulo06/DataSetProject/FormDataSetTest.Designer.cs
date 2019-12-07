namespace DataSetProject
{
    partial class FormDataSetTest
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
            this.btnCriarDataSet = new System.Windows.Forms.Button();
            this.btnInserirDados = new System.Windows.Forms.Button();
            this.btnVisualizarXML = new System.Windows.Forms.Button();
            this.btnControlesVisuais = new System.Windows.Forms.Button();
            this.tcResultados = new System.Windows.Forms.TabControl();
            this.tpgXML = new System.Windows.Forms.TabPage();
            this.txtXML = new System.Windows.Forms.TextBox();
            this.tpgComboEGrid = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCidades = new System.Windows.Forms.DataGridView();
            this.cbxEstados = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.tcResultados.SuspendLayout();
            this.tpgXML.SuspendLayout();
            this.tpgComboEGrid.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCidades)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCriarDataSet
            // 
            this.btnCriarDataSet.Location = new System.Drawing.Point(12, 12);
            this.btnCriarDataSet.Name = "btnCriarDataSet";
            this.btnCriarDataSet.Size = new System.Drawing.Size(117, 23);
            this.btnCriarDataSet.TabIndex = 0;
            this.btnCriarDataSet.Text = "Criar DataSet";
            this.btnCriarDataSet.UseVisualStyleBackColor = true;
            this.btnCriarDataSet.Click += new System.EventHandler(this.btnCriarDataSet_Click);
            // 
            // btnInserirDados
            // 
            this.btnInserirDados.Location = new System.Drawing.Point(135, 12);
            this.btnInserirDados.Name = "btnInserirDados";
            this.btnInserirDados.Size = new System.Drawing.Size(117, 23);
            this.btnInserirDados.TabIndex = 1;
            this.btnInserirDados.Text = "Inserir dados";
            this.btnInserirDados.UseVisualStyleBackColor = true;
            this.btnInserirDados.Click += new System.EventHandler(this.btnInserirDados_Click);
            // 
            // btnVisualizarXML
            // 
            this.btnVisualizarXML.Location = new System.Drawing.Point(258, 12);
            this.btnVisualizarXML.Name = "btnVisualizarXML";
            this.btnVisualizarXML.Size = new System.Drawing.Size(117, 23);
            this.btnVisualizarXML.TabIndex = 2;
            this.btnVisualizarXML.Text = "Visualizar XML";
            this.btnVisualizarXML.UseVisualStyleBackColor = true;
            this.btnVisualizarXML.Click += new System.EventHandler(this.btnVisualizarXML_Click);
            // 
            // btnControlesVisuais
            // 
            this.btnControlesVisuais.Location = new System.Drawing.Point(381, 12);
            this.btnControlesVisuais.Name = "btnControlesVisuais";
            this.btnControlesVisuais.Size = new System.Drawing.Size(117, 23);
            this.btnControlesVisuais.TabIndex = 3;
            this.btnControlesVisuais.Text = "Controles Visuais";
            this.btnControlesVisuais.UseVisualStyleBackColor = true;
            this.btnControlesVisuais.Click += new System.EventHandler(this.btnControlesVisuais_Click);
            // 
            // tcResultados
            // 
            this.tcResultados.Controls.Add(this.tpgXML);
            this.tcResultados.Controls.Add(this.tpgComboEGrid);
            this.tcResultados.Location = new System.Drawing.Point(12, 41);
            this.tcResultados.Name = "tcResultados";
            this.tcResultados.SelectedIndex = 0;
            this.tcResultados.Size = new System.Drawing.Size(486, 208);
            this.tcResultados.TabIndex = 4;
            // 
            // tpgXML
            // 
            this.tpgXML.Controls.Add(this.txtXML);
            this.tpgXML.Location = new System.Drawing.Point(4, 22);
            this.tpgXML.Name = "tpgXML";
            this.tpgXML.Padding = new System.Windows.Forms.Padding(3);
            this.tpgXML.Size = new System.Drawing.Size(478, 182);
            this.tpgXML.TabIndex = 0;
            this.tpgXML.Text = "Dados em XML";
            this.tpgXML.UseVisualStyleBackColor = true;
            // 
            // txtXML
            // 
            this.txtXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXML.Location = new System.Drawing.Point(3, 3);
            this.txtXML.Multiline = true;
            this.txtXML.Name = "txtXML";
            this.txtXML.Size = new System.Drawing.Size(472, 176);
            this.txtXML.TabIndex = 0;
            // 
            // tpgComboEGrid
            // 
            this.tpgComboEGrid.Controls.Add(this.tableLayoutPanel1);
            this.tpgComboEGrid.Location = new System.Drawing.Point(4, 22);
            this.tpgComboEGrid.Name = "tpgComboEGrid";
            this.tpgComboEGrid.Padding = new System.Windows.Forms.Padding(3);
            this.tpgComboEGrid.Size = new System.Drawing.Size(478, 182);
            this.tpgComboEGrid.TabIndex = 1;
            this.tpgComboEGrid.Text = "Dados em Controles";
            this.tpgComboEGrid.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cbxEstados, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvCidades, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblEstado, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(472, 176);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // dgvCidades
            // 
            this.dgvCidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvCidades, 2);
            this.dgvCidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCidades.Location = new System.Drawing.Point(3, 30);
            this.dgvCidades.Name = "dgvCidades";
            this.dgvCidades.Size = new System.Drawing.Size(466, 143);
            this.dgvCidades.TabIndex = 2;
            // 
            // cbxEstados
            // 
            this.cbxEstados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxEstados.FormattingEnabled = true;
            this.cbxEstados.Location = new System.Drawing.Point(52, 3);
            this.cbxEstados.Name = "cbxEstados";
            this.cbxEstados.Size = new System.Drawing.Size(417, 21);
            this.cbxEstados.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(3, 7);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "Estado:";
            // 
            // FormDataSetTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 261);
            this.Controls.Add(this.tcResultados);
            this.Controls.Add(this.btnControlesVisuais);
            this.Controls.Add(this.btnVisualizarXML);
            this.Controls.Add(this.btnInserirDados);
            this.Controls.Add(this.btnCriarDataSet);
            this.Name = "FormDataSetTest";
            this.Text = "Testes com DataSet e seus componentes";
            this.tcResultados.ResumeLayout(false);
            this.tpgXML.ResumeLayout(false);
            this.tpgXML.PerformLayout();
            this.tpgComboEGrid.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCriarDataSet;
        private System.Windows.Forms.Button btnInserirDados;
        private System.Windows.Forms.Button btnVisualizarXML;
        private System.Windows.Forms.Button btnControlesVisuais;
        private System.Windows.Forms.TabControl tcResultados;
        private System.Windows.Forms.TabPage tpgXML;
        private System.Windows.Forms.TabPage tpgComboEGrid;
        private System.Windows.Forms.TextBox txtXML;
        private System.Windows.Forms.ComboBox cbxEstados;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.DataGridView dgvCidades;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

