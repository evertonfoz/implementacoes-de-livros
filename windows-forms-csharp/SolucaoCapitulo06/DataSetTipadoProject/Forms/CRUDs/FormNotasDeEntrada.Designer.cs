namespace DataSetTipadoProject.Forms.CRUDs {
    partial class FormNotasDeEntrada {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label idnotadeentradaLabel;
            System.Windows.Forms.Label idfornecedorLabel;
            System.Windows.Forms.Label numerodanotaLabel;
            System.Windows.Forms.Label datadeemissaoLabel;
            System.Windows.Forms.Label datadeentradaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNotasDeEntrada));
            this.dSEstadosECidades = new DataSetTipadoProject.DataSets.DSEstadosECidades();
            this.notasDeEntradaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.notasDeEntradaTableAdapter = new DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.NotasDeEntradaTableAdapter();
            this.tableAdapterManager = new DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.TableAdapterManager();
            this.produtosNotaDeEntradaTableAdapter = new DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.ProdutosNotaDeEntradaTableAdapter();
            this.produtosTableAdapter = new DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.ProdutosTableAdapter();
            this.notasDeEntradaBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnbAdd = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bnbNext = new System.Windows.Forms.ToolStripButton();
            this.bnbLast = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.notasDeEntradaBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.idnotadeentradaLabel1 = new System.Windows.Forms.Label();
            this.idfornecedorComboBox = new System.Windows.Forms.ComboBox();
            this.fornecedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numerodanotaTextBox = new System.Windows.Forms.TextBox();
            this.datadeemissaoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.datadeentradaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produtosNotaDeEntradaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.fornecedoresTableAdapter = new DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.FornecedoresTableAdapter();
            idnotadeentradaLabel = new System.Windows.Forms.Label();
            idfornecedorLabel = new System.Windows.Forms.Label();
            numerodanotaLabel = new System.Windows.Forms.Label();
            datadeemissaoLabel = new System.Windows.Forms.Label();
            datadeentradaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSEstadosECidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notasDeEntradaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notasDeEntradaBindingNavigator)).BeginInit();
            this.notasDeEntradaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedoresBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosNotaDeEntradaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idnotadeentradaLabel
            // 
            idnotadeentradaLabel.AutoSize = true;
            idnotadeentradaLabel.Location = new System.Drawing.Point(16, 52);
            idnotadeentradaLabel.Name = "idnotadeentradaLabel";
            idnotadeentradaLabel.Size = new System.Drawing.Size(19, 13);
            idnotadeentradaLabel.TabIndex = 1;
            idnotadeentradaLabel.Text = "Id:";
            // 
            // idfornecedorLabel
            // 
            idfornecedorLabel.AutoSize = true;
            idfornecedorLabel.Location = new System.Drawing.Point(16, 81);
            idfornecedorLabel.Name = "idfornecedorLabel";
            idfornecedorLabel.Size = new System.Drawing.Size(64, 13);
            idfornecedorLabel.TabIndex = 3;
            idfornecedorLabel.Text = "Fornecedor:";
            // 
            // numerodanotaLabel
            // 
            numerodanotaLabel.AutoSize = true;
            numerodanotaLabel.Location = new System.Drawing.Point(200, 52);
            numerodanotaLabel.Name = "numerodanotaLabel";
            numerodanotaLabel.Size = new System.Drawing.Size(50, 13);
            numerodanotaLabel.TabIndex = 5;
            numerodanotaLabel.Text = "Nr. Nota:";
            // 
            // datadeemissaoLabel
            // 
            datadeemissaoLabel.AutoSize = true;
            datadeemissaoLabel.Location = new System.Drawing.Point(16, 109);
            datadeemissaoLabel.Name = "datadeemissaoLabel";
            datadeemissaoLabel.Size = new System.Drawing.Size(90, 13);
            datadeemissaoLabel.TabIndex = 7;
            datadeemissaoLabel.Text = "Data de Emissão:";
            // 
            // datadeentradaLabel
            // 
            datadeentradaLabel.AutoSize = true;
            datadeentradaLabel.Location = new System.Drawing.Point(200, 109);
            datadeentradaLabel.Name = "datadeentradaLabel";
            datadeentradaLabel.Size = new System.Drawing.Size(88, 13);
            datadeentradaLabel.TabIndex = 9;
            datadeentradaLabel.Text = "Data de Entrada:";
            // 
            // dSEstadosECidades
            // 
            this.dSEstadosECidades.DataSetName = "DSEstadosECidades";
            this.dSEstadosECidades.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // notasDeEntradaBindingSource
            // 
            this.notasDeEntradaBindingSource.DataMember = "NotasDeEntrada";
            this.notasDeEntradaBindingSource.DataSource = this.dSEstadosECidades;
            // 
            // notasDeEntradaTableAdapter
            // 
            this.notasDeEntradaTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CidadesTableAdapter = null;
            this.tableAdapterManager.ClientesTableAdapter = null;
            this.tableAdapterManager.EstadosTableAdapter = null;
            this.tableAdapterManager.FornecedoresTableAdapter = null;
            this.tableAdapterManager.GruposTableAdapter = null;
            this.tableAdapterManager.NotasDeEntradaTableAdapter = this.notasDeEntradaTableAdapter;
            this.tableAdapterManager.NotasDeVendaTableAdapter = null;
            this.tableAdapterManager.ProdutosNotaDeEntradaTableAdapter = this.produtosNotaDeEntradaTableAdapter;
            this.tableAdapterManager.ProdutosNotaDeSaidaTableAdapter = null;
            this.tableAdapterManager.ProdutosTableAdapter = this.produtosTableAdapter;
            this.tableAdapterManager.UpdateOrder = DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // produtosNotaDeEntradaTableAdapter
            // 
            this.produtosNotaDeEntradaTableAdapter.ClearBeforeFill = true;
            // 
            // produtosTableAdapter
            // 
            this.produtosTableAdapter.ClearBeforeFill = true;
            // 
            // notasDeEntradaBindingNavigator
            // 
            this.notasDeEntradaBindingNavigator.AddNewItem = this.bnbAdd;
            this.notasDeEntradaBindingNavigator.BindingSource = this.notasDeEntradaBindingSource;
            this.notasDeEntradaBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.notasDeEntradaBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.notasDeEntradaBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bnbNext,
            this.bnbLast,
            this.bindingNavigatorSeparator2,
            this.bnbAdd,
            this.bindingNavigatorDeleteItem,
            this.notasDeEntradaBindingNavigatorSaveItem});
            this.notasDeEntradaBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.notasDeEntradaBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.notasDeEntradaBindingNavigator.MoveLastItem = this.bnbLast;
            this.notasDeEntradaBindingNavigator.MoveNextItem = this.bnbNext;
            this.notasDeEntradaBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.notasDeEntradaBindingNavigator.Name = "notasDeEntradaBindingNavigator";
            this.notasDeEntradaBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.notasDeEntradaBindingNavigator.Size = new System.Drawing.Size(398, 25);
            this.notasDeEntradaBindingNavigator.TabIndex = 0;
            this.notasDeEntradaBindingNavigator.Text = "bindingNavigator1";
            // 
            // bnbAdd
            // 
            this.bnbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnbAdd.Image = ((System.Drawing.Image)(resources.GetObject("bnbAdd.Image")));
            this.bnbAdd.Name = "bnbAdd";
            this.bnbAdd.RightToLeftAutoMirrorImage = true;
            this.bnbAdd.Size = new System.Drawing.Size(23, 22);
            this.bnbAdd.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bnbNext
            // 
            this.bnbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnbNext.Image = ((System.Drawing.Image)(resources.GetObject("bnbNext.Image")));
            this.bnbNext.Name = "bnbNext";
            this.bnbNext.RightToLeftAutoMirrorImage = true;
            this.bnbNext.Size = new System.Drawing.Size(23, 22);
            this.bnbNext.Text = "Move next";
            // 
            // bnbLast
            // 
            this.bnbLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnbLast.Image = ((System.Drawing.Image)(resources.GetObject("bnbLast.Image")));
            this.bnbLast.Name = "bnbLast";
            this.bnbLast.RightToLeftAutoMirrorImage = true;
            this.bnbLast.Size = new System.Drawing.Size(23, 22);
            this.bnbLast.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // notasDeEntradaBindingNavigatorSaveItem
            // 
            this.notasDeEntradaBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.notasDeEntradaBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("notasDeEntradaBindingNavigatorSaveItem.Image")));
            this.notasDeEntradaBindingNavigatorSaveItem.Name = "notasDeEntradaBindingNavigatorSaveItem";
            this.notasDeEntradaBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.notasDeEntradaBindingNavigatorSaveItem.Text = "Save Data";
            this.notasDeEntradaBindingNavigatorSaveItem.Click += new System.EventHandler(this.notasDeEntradaBindingNavigatorSaveItem_Click);
            // 
            // idnotadeentradaLabel1
            // 
            this.idnotadeentradaLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.notasDeEntradaBindingSource, "idnotadeentrada", true));
            this.idnotadeentradaLabel1.Location = new System.Drawing.Point(109, 52);
            this.idnotadeentradaLabel1.Name = "idnotadeentradaLabel1";
            this.idnotadeentradaLabel1.Size = new System.Drawing.Size(85, 23);
            this.idnotadeentradaLabel1.TabIndex = 2;
            this.idnotadeentradaLabel1.Text = "label1";
            // 
            // idfornecedorComboBox
            // 
            this.idfornecedorComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.notasDeEntradaBindingSource, "idfornecedor", true));
            this.idfornecedorComboBox.DataSource = this.fornecedoresBindingSource;
            this.idfornecedorComboBox.DisplayMember = "nome";
            this.idfornecedorComboBox.FormattingEnabled = true;
            this.idfornecedorComboBox.Location = new System.Drawing.Point(109, 78);
            this.idfornecedorComboBox.Name = "idfornecedorComboBox";
            this.idfornecedorComboBox.Size = new System.Drawing.Size(270, 21);
            this.idfornecedorComboBox.TabIndex = 4;
            this.idfornecedorComboBox.ValueMember = "idfornecedor";
            // 
            // fornecedoresBindingSource
            // 
            this.fornecedoresBindingSource.DataMember = "Fornecedores";
            this.fornecedoresBindingSource.DataSource = this.dSEstadosECidades;
            // 
            // numerodanotaTextBox
            // 
            this.numerodanotaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.notasDeEntradaBindingSource, "numerodanota", true));
            this.numerodanotaTextBox.Location = new System.Drawing.Point(256, 49);
            this.numerodanotaTextBox.Name = "numerodanotaTextBox";
            this.numerodanotaTextBox.Size = new System.Drawing.Size(123, 20);
            this.numerodanotaTextBox.TabIndex = 6;
            // 
            // datadeemissaoDateTimePicker
            // 
            this.datadeemissaoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.notasDeEntradaBindingSource, "datadeemissao", true));
            this.datadeemissaoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datadeemissaoDateTimePicker.Location = new System.Drawing.Point(109, 105);
            this.datadeemissaoDateTimePicker.Name = "datadeemissaoDateTimePicker";
            this.datadeemissaoDateTimePicker.Size = new System.Drawing.Size(85, 20);
            this.datadeemissaoDateTimePicker.TabIndex = 8;
            // 
            // datadeentradaDateTimePicker
            // 
            this.datadeentradaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.notasDeEntradaBindingSource, "datadeentrada", true));
            this.datadeentradaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datadeentradaDateTimePicker.Location = new System.Drawing.Point(294, 105);
            this.datadeentradaDateTimePicker.Name = "datadeentradaDateTimePicker";
            this.datadeentradaDateTimePicker.Size = new System.Drawing.Size(85, 20);
            this.datadeentradaDateTimePicker.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvProdutos);
            this.groupBox1.Controls.Add(this.bindingNavigator1);
            this.groupBox1.Location = new System.Drawing.Point(19, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 333);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AutoGenerateColumns = false;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvProdutos.DataSource = this.produtosNotaDeEntradaBindingSource;
            this.dgvProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutos.Location = new System.Drawing.Point(3, 41);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.Size = new System.Drawing.Size(354, 289);
            this.dgvProdutos.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "idproduto";
            this.dataGridViewTextBoxColumn3.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "precocustacompra";
            this.dataGridViewTextBoxColumn4.HeaderText = "Custo";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "quantidadecomprada";
            this.dataGridViewTextBoxColumn5.HeaderText = "Quantidade";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // produtosNotaDeEntradaBindingSource
            // 
            this.produtosNotaDeEntradaBindingSource.DataMember = "FK_ProdutosNotaDeEntrada_NotasDeEntrada";
            this.produtosNotaDeEntradaBindingSource.DataSource = this.notasDeEntradaBindingSource;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem1;
            this.bindingNavigator1.BindingSource = this.produtosNotaDeEntradaBindingSource;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem1;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem1;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5,
            this.bindingNavigatorAddNewItem1,
            this.bindingNavigatorDeleteItem1});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 16);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem1;
            this.bindingNavigator1.Size = new System.Drawing.Size(354, 25);
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem1
            // 
            this.bindingNavigatorAddNewItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem1.Image")));
            this.bindingNavigatorAddNewItem1.Name = "bindingNavigatorAddNewItem1";
            this.bindingNavigatorAddNewItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem1.Text = "Add new";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem1.Text = "of {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem1
            // 
            this.bindingNavigatorDeleteItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem1.Image")));
            this.bindingNavigatorDeleteItem1.Name = "bindingNavigatorDeleteItem1";
            this.bindingNavigatorDeleteItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem1.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem1.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem1.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem1.Text = "Move last";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // fornecedoresTableAdapter
            // 
            this.fornecedoresTableAdapter.ClearBeforeFill = true;
            // 
            // FormNotasDeEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(idnotadeentradaLabel);
            this.Controls.Add(this.idnotadeentradaLabel1);
            this.Controls.Add(idfornecedorLabel);
            this.Controls.Add(this.idfornecedorComboBox);
            this.Controls.Add(numerodanotaLabel);
            this.Controls.Add(this.numerodanotaTextBox);
            this.Controls.Add(datadeemissaoLabel);
            this.Controls.Add(this.datadeemissaoDateTimePicker);
            this.Controls.Add(datadeentradaLabel);
            this.Controls.Add(this.datadeentradaDateTimePicker);
            this.Controls.Add(this.notasDeEntradaBindingNavigator);
            this.Name = "FormNotasDeEntrada";
            this.Text = "FormNotasDeEntrada";
            this.Load += new System.EventHandler(this.FormNotaDeEntrada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSEstadosECidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notasDeEntradaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notasDeEntradaBindingNavigator)).EndInit();
            this.notasDeEntradaBindingNavigator.ResumeLayout(false);
            this.notasDeEntradaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedoresBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosNotaDeEntradaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSets.DSEstadosECidades dSEstadosECidades;
        private System.Windows.Forms.BindingSource notasDeEntradaBindingSource;
        private DataSets.DSEstadosECidadesTableAdapters.NotasDeEntradaTableAdapter notasDeEntradaTableAdapter;
        private DataSets.DSEstadosECidadesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator notasDeEntradaBindingNavigator;
        private System.Windows.Forms.ToolStripButton bnbAdd;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bnbNext;
        private System.Windows.Forms.ToolStripButton bnbLast;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton notasDeEntradaBindingNavigatorSaveItem;
        private System.Windows.Forms.Label idnotadeentradaLabel1;
        private System.Windows.Forms.ComboBox idfornecedorComboBox;
        private System.Windows.Forms.TextBox numerodanotaTextBox;
        private System.Windows.Forms.DateTimePicker datadeemissaoDateTimePicker;
        private System.Windows.Forms.DateTimePicker datadeentradaDateTimePicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private DataSets.DSEstadosECidadesTableAdapters.ProdutosNotaDeEntradaTableAdapter produtosNotaDeEntradaTableAdapter;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.BindingSource produtosNotaDeEntradaBindingSource;
        private DataSets.DSEstadosECidadesTableAdapters.ProdutosTableAdapter produtosTableAdapter;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource fornecedoresBindingSource;
        private DataSets.DSEstadosECidadesTableAdapters.FornecedoresTableAdapter fornecedoresTableAdapter;
    }
}