namespace ViewProject
{
    partial class FormNotaEntrada
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblIDNota = new System.Windows.Forms.Label();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.dgvNotasEntrada = new System.Windows.Forms.DataGridView();
            this.txtIDNota = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNovoNota = new System.Windows.Forms.Button();
            this.btnGravarNota = new System.Windows.Forms.Button();
            this.btnCancelarNota = new System.Windows.Forms.Button();
            this.btnRemoverNota = new System.Windows.Forms.Button();
            this.lblEmissao = new System.Windows.Forms.Label();
            this.lblEntrada = new System.Windows.Forms.Label();
            this.cbxFornecedor = new System.Windows.Forms.ComboBox();
            this.dtpEmissao = new System.Windows.Forms.DateTimePicker();
            this.dtpEntrada = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblIDProduto = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.lblCUsto = new System.Windows.Forms.Label();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.txtIDProduto = new System.Windows.Forms.TextBox();
            this.txtCusto = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNovoProduto = new System.Windows.Forms.Button();
            this.btnGravarProduto = new System.Windows.Forms.Button();
            this.btnCancelarProduto = new System.Windows.Forms.Button();
            this.btnRemoverProduto = new System.Windows.Forms.Button();
            this.cbxProduto = new System.Windows.Forms.ComboBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCorpoDaNota = new System.Windows.Forms.Label();
            this.lblProdutosComprados = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotasEntrada)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblIDNota, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFornecedor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNumero, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvNotasEntrada, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtIDNota, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNumero, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblEmissao, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblEntrada, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxFornecedor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpEmissao, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtpEntrada, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(304, 461);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblIDNota
            // 
            this.lblIDNota.AutoSize = true;
            this.lblIDNota.Location = new System.Drawing.Point(3, 0);
            this.lblIDNota.Name = "lblIDNota";
            this.lblIDNota.Size = new System.Drawing.Size(19, 13);
            this.lblIDNota.TabIndex = 0;
            this.lblIDNota.Text = "Id:";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(3, 26);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(64, 13);
            this.lblFornecedor.TabIndex = 1;
            this.lblFornecedor.Text = "Fornecedor:";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(3, 53);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(47, 13);
            this.lblNumero.TabIndex = 2;
            this.lblNumero.Text = "Número:";
            // 
            // dgvNotasEntrada
            // 
            this.dgvNotasEntrada.AllowUserToAddRows = false;
            this.dgvNotasEntrada.AllowUserToDeleteRows = false;
            this.dgvNotasEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvNotasEntrada, 2);
            this.dgvNotasEntrada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotasEntrada.Location = new System.Drawing.Point(3, 195);
            this.dgvNotasEntrada.Name = "dgvNotasEntrada";
            this.dgvNotasEntrada.ReadOnly = true;
            this.dgvNotasEntrada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotasEntrada.Size = new System.Drawing.Size(298, 263);
            this.dgvNotasEntrada.TabIndex = 3;
            this.dgvNotasEntrada.SelectionChanged += new System.EventHandler(this.dgvNotasEntrada_SelectionChanged);
            // 
            // txtIDNota
            // 
            this.txtIDNota.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDNota.Enabled = false;
            this.txtIDNota.Location = new System.Drawing.Point(73, 3);
            this.txtIDNota.Name = "txtIDNota";
            this.txtIDNota.Size = new System.Drawing.Size(228, 20);
            this.txtIDNota.TabIndex = 4;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(73, 56);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(202, 20);
            this.txtNumero.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.btnNovoNota, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGravarNota, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancelarNota, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRemoverNota, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 147);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(298, 29);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // btnNovoNota
            // 
            this.btnNovoNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoNota.Location = new System.Drawing.Point(3, 3);
            this.btnNovoNota.Name = "btnNovoNota";
            this.btnNovoNota.Size = new System.Drawing.Size(68, 23);
            this.btnNovoNota.TabIndex = 0;
            this.btnNovoNota.Text = "Novo";
            this.btnNovoNota.UseVisualStyleBackColor = true;
            this.btnNovoNota.Click += new System.EventHandler(this.btnNovoNota_Click);
            // 
            // btnGravarNota
            // 
            this.btnGravarNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGravarNota.Location = new System.Drawing.Point(77, 3);
            this.btnGravarNota.Name = "btnGravarNota";
            this.btnGravarNota.Size = new System.Drawing.Size(68, 23);
            this.btnGravarNota.TabIndex = 1;
            this.btnGravarNota.Text = "Gravar";
            this.btnGravarNota.UseVisualStyleBackColor = true;
            this.btnGravarNota.Click += new System.EventHandler(this.btnGravarNota_Click);
            // 
            // btnCancelarNota
            // 
            this.btnCancelarNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarNota.Location = new System.Drawing.Point(151, 3);
            this.btnCancelarNota.Name = "btnCancelarNota";
            this.btnCancelarNota.Size = new System.Drawing.Size(68, 23);
            this.btnCancelarNota.TabIndex = 2;
            this.btnCancelarNota.Text = "Cancelar";
            this.btnCancelarNota.UseVisualStyleBackColor = true;
            this.btnCancelarNota.Click += new System.EventHandler(this.btnCancelarNota_Click);
            // 
            // btnRemoverNota
            // 
            this.btnRemoverNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverNota.Location = new System.Drawing.Point(225, 3);
            this.btnRemoverNota.Name = "btnRemoverNota";
            this.btnRemoverNota.Size = new System.Drawing.Size(70, 23);
            this.btnRemoverNota.TabIndex = 3;
            this.btnRemoverNota.Text = "Remover";
            this.btnRemoverNota.UseVisualStyleBackColor = true;
            this.btnRemoverNota.Click += new System.EventHandler(this.btnRemoverNota_Click);
            // 
            // lblEmissao
            // 
            this.lblEmissao.AutoSize = true;
            this.lblEmissao.Location = new System.Drawing.Point(3, 79);
            this.lblEmissao.Name = "lblEmissao";
            this.lblEmissao.Size = new System.Drawing.Size(49, 13);
            this.lblEmissao.TabIndex = 8;
            this.lblEmissao.Text = "Emissão:";
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Location = new System.Drawing.Point(3, 105);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(47, 13);
            this.lblEntrada.TabIndex = 9;
            this.lblEntrada.Text = "Entrada:";
            // 
            // cbxFornecedor
            // 
            this.cbxFornecedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFornecedor.FormattingEnabled = true;
            this.cbxFornecedor.Location = new System.Drawing.Point(73, 29);
            this.cbxFornecedor.Name = "cbxFornecedor";
            this.cbxFornecedor.Size = new System.Drawing.Size(228, 21);
            this.cbxFornecedor.TabIndex = 10;
            // 
            // dtpEmissao
            // 
            this.dtpEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEmissao.Location = new System.Drawing.Point(73, 82);
            this.dtpEmissao.Name = "dtpEmissao";
            this.dtpEmissao.Size = new System.Drawing.Size(98, 20);
            this.dtpEmissao.TabIndex = 11;
            // 
            // dtpEntrada
            // 
            this.dtpEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntrada.Location = new System.Drawing.Point(73, 108);
            this.dtpEntrada.Name = "dtpEntrada";
            this.dtpEntrada.Size = new System.Drawing.Size(98, 20);
            this.dtpEntrada.TabIndex = 12;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.lblIDProduto, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblProduto, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblCUsto, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.dgvProdutos, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.txtIDProduto, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtCusto, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.cbxProduto, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblQuantidade, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtQuantidade, 1, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(326, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(304, 461);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // lblIDProduto
            // 
            this.lblIDProduto.AutoSize = true;
            this.lblIDProduto.Location = new System.Drawing.Point(3, 0);
            this.lblIDProduto.Name = "lblIDProduto";
            this.lblIDProduto.Size = new System.Drawing.Size(19, 13);
            this.lblIDProduto.TabIndex = 0;
            this.lblIDProduto.Text = "Id:";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(3, 26);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(47, 13);
            this.lblProduto.TabIndex = 1;
            this.lblProduto.Text = "Produto:";
            // 
            // lblCUsto
            // 
            this.lblCUsto.AutoSize = true;
            this.lblCUsto.Location = new System.Drawing.Point(3, 53);
            this.lblCUsto.Name = "lblCUsto";
            this.lblCUsto.Size = new System.Drawing.Size(37, 13);
            this.lblCUsto.TabIndex = 2;
            this.lblCUsto.Text = "Custo:";
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel3.SetColumnSpan(this.dgvProdutos, 2);
            this.dgvProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutos.Location = new System.Drawing.Point(3, 169);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(298, 289);
            this.dgvProdutos.TabIndex = 3;
            // 
            // txtIDProduto
            // 
            this.txtIDProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDProduto.Enabled = false;
            this.txtIDProduto.Location = new System.Drawing.Point(74, 3);
            this.txtIDProduto.Name = "txtIDProduto";
            this.txtIDProduto.Size = new System.Drawing.Size(227, 20);
            this.txtIDProduto.TabIndex = 4;
            // 
            // txtCusto
            // 
            this.txtCusto.Enabled = false;
            this.txtCusto.Location = new System.Drawing.Point(74, 56);
            this.txtCusto.Name = "txtCusto";
            this.txtCusto.Size = new System.Drawing.Size(198, 20);
            this.txtCusto.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel3.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.btnNovoProduto, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnGravarProduto, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnCancelarProduto, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnRemoverProduto, 3, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 121);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(298, 29);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // btnNovoProduto
            // 
            this.btnNovoProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoProduto.Location = new System.Drawing.Point(3, 3);
            this.btnNovoProduto.Name = "btnNovoProduto";
            this.btnNovoProduto.Size = new System.Drawing.Size(68, 23);
            this.btnNovoProduto.TabIndex = 0;
            this.btnNovoProduto.Text = "Novo";
            this.btnNovoProduto.UseVisualStyleBackColor = true;
            this.btnNovoProduto.Click += new System.EventHandler(this.btnNovoProduto_Click);
            // 
            // btnGravarProduto
            // 
            this.btnGravarProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGravarProduto.Enabled = false;
            this.btnGravarProduto.Location = new System.Drawing.Point(77, 3);
            this.btnGravarProduto.Name = "btnGravarProduto";
            this.btnGravarProduto.Size = new System.Drawing.Size(68, 23);
            this.btnGravarProduto.TabIndex = 1;
            this.btnGravarProduto.Text = "Gravar";
            this.btnGravarProduto.UseVisualStyleBackColor = true;
            this.btnGravarProduto.Click += new System.EventHandler(this.btnGravarProduto_Click);
            // 
            // btnCancelarProduto
            // 
            this.btnCancelarProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarProduto.Enabled = false;
            this.btnCancelarProduto.Location = new System.Drawing.Point(151, 3);
            this.btnCancelarProduto.Name = "btnCancelarProduto";
            this.btnCancelarProduto.Size = new System.Drawing.Size(68, 23);
            this.btnCancelarProduto.TabIndex = 2;
            this.btnCancelarProduto.Text = "Cancelar";
            this.btnCancelarProduto.UseVisualStyleBackColor = true;
            this.btnCancelarProduto.Click += new System.EventHandler(this.btnCancelarProduto_Click);
            // 
            // btnRemoverProduto
            // 
            this.btnRemoverProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverProduto.Enabled = false;
            this.btnRemoverProduto.Location = new System.Drawing.Point(225, 3);
            this.btnRemoverProduto.Name = "btnRemoverProduto";
            this.btnRemoverProduto.Size = new System.Drawing.Size(70, 23);
            this.btnRemoverProduto.TabIndex = 3;
            this.btnRemoverProduto.Text = "Remover";
            this.btnRemoverProduto.UseVisualStyleBackColor = true;
            this.btnRemoverProduto.Click += new System.EventHandler(this.btnRemoverProduto_Click);
            // 
            // cbxProduto
            // 
            this.cbxProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProduto.Enabled = false;
            this.cbxProduto.FormattingEnabled = true;
            this.cbxProduto.Location = new System.Drawing.Point(74, 29);
            this.cbxProduto.Name = "cbxProduto";
            this.cbxProduto.Size = new System.Drawing.Size(227, 21);
            this.cbxProduto.TabIndex = 8;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(3, 79);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(65, 13);
            this.lblQuantidade.TabIndex = 9;
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Enabled = false;
            this.txtQuantidade.Location = new System.Drawing.Point(74, 82);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(198, 20);
            this.txtQuantidade.TabIndex = 10;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.lblCorpoDaNota, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel3, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblProdutosComprados, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(633, 487);
            this.tableLayoutPanel5.TabIndex = 9;
            // 
            // lblCorpoDaNota
            // 
            this.lblCorpoDaNota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCorpoDaNota.AutoSize = true;
            this.lblCorpoDaNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorpoDaNota.Location = new System.Drawing.Point(92, 0);
            this.lblCorpoDaNota.Name = "lblCorpoDaNota";
            this.lblCorpoDaNota.Size = new System.Drawing.Size(125, 20);
            this.lblCorpoDaNota.TabIndex = 0;
            this.lblCorpoDaNota.Text = "Corpo da Nota";
            // 
            // lblProdutosComprados
            // 
            this.lblProdutosComprados.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblProdutosComprados.AutoSize = true;
            this.lblProdutosComprados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdutosComprados.Location = new System.Drawing.Point(391, 0);
            this.lblProdutosComprados.Name = "lblProdutosComprados";
            this.lblProdutosComprados.Size = new System.Drawing.Size(174, 20);
            this.lblProdutosComprados.TabIndex = 1;
            this.lblProdutosComprados.Text = "Produtos comprados";
            // 
            // FormNotaEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 487);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Name = "FormNotaEntrada";
            this.Text = "Registro de notas de entrada";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotasEntrada)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblIDNota;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.DataGridView dgvNotasEntrada;
        private System.Windows.Forms.TextBox txtIDNota;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnNovoNota;
        private System.Windows.Forms.Button btnGravarNota;
        private System.Windows.Forms.Button btnCancelarNota;
        private System.Windows.Forms.Button btnRemoverNota;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblIDProduto;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label lblCUsto;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.TextBox txtIDProduto;
        private System.Windows.Forms.TextBox txtCusto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnNovoProduto;
        private System.Windows.Forms.Button btnGravarProduto;
        private System.Windows.Forms.Button btnCancelarProduto;
        private System.Windows.Forms.Button btnRemoverProduto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblCorpoDaNota;
        private System.Windows.Forms.Label lblProdutosComprados;
        private System.Windows.Forms.Label lblEmissao;
        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.ComboBox cbxFornecedor;
        private System.Windows.Forms.DateTimePicker dtpEmissao;
        private System.Windows.Forms.DateTimePicker dtpEntrada;
        private System.Windows.Forms.ComboBox cbxProduto;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
    }
}