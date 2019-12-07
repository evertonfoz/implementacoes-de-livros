namespace DataSetTipadoProject.Forms.CRUDs {
    partial class FormProdutos {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProdutos));
            System.Windows.Forms.Label idprodutoLabel;
            System.Windows.Forms.Label idgrupoLabel;
            System.Windows.Forms.Label descricaoLabel;
            System.Windows.Forms.Label precodecompraLabel;
            System.Windows.Forms.Label precodevendaLabel;
            System.Windows.Forms.Label quantidadeemestoqueLabel;
            this.dSEstadosECidades = new DataSetTipadoProject.DataSets.DSEstadosECidades();
            this.produtosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produtosTableAdapter = new DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.ProdutosTableAdapter();
            this.tableAdapterManager = new DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.TableAdapterManager();
            this.produtosBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.produtosBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.idprodutoLabel1 = new System.Windows.Forms.Label();
            this.idgrupoComboBox = new System.Windows.Forms.ComboBox();
            this.descricaoTextBox = new System.Windows.Forms.TextBox();
            this.precodecompraTextBox = new System.Windows.Forms.TextBox();
            this.precodevendaTextBox = new System.Windows.Forms.TextBox();
            this.quantidadeemestoqueTextBox = new System.Windows.Forms.TextBox();
            this.gruposBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gruposTableAdapter = new DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.GruposTableAdapter();
            idprodutoLabel = new System.Windows.Forms.Label();
            idgrupoLabel = new System.Windows.Forms.Label();
            descricaoLabel = new System.Windows.Forms.Label();
            precodecompraLabel = new System.Windows.Forms.Label();
            precodevendaLabel = new System.Windows.Forms.Label();
            quantidadeemestoqueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSEstadosECidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingNavigator)).BeginInit();
            this.produtosBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gruposBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dSEstadosECidades
            // 
            this.dSEstadosECidades.DataSetName = "DSEstadosECidades";
            this.dSEstadosECidades.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // produtosBindingSource
            // 
            this.produtosBindingSource.DataMember = "Produtos";
            this.produtosBindingSource.DataSource = this.dSEstadosECidades;
            // 
            // produtosTableAdapter
            // 
            this.produtosTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CidadesTableAdapter = null;
            this.tableAdapterManager.EstadosTableAdapter = null;
            this.tableAdapterManager.FornecedoresTableAdapter = null;
            this.tableAdapterManager.GruposTableAdapter = this.gruposTableAdapter;
            this.tableAdapterManager.ProdutosTableAdapter = this.produtosTableAdapter;
            this.tableAdapterManager.UpdateOrder = DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // produtosBindingNavigator
            // 
            this.produtosBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.produtosBindingNavigator.BindingSource = this.produtosBindingSource;
            this.produtosBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.produtosBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.produtosBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.produtosBindingNavigatorSaveItem});
            this.produtosBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.produtosBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.produtosBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.produtosBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.produtosBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.produtosBindingNavigator.Name = "produtosBindingNavigator";
            this.produtosBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.produtosBindingNavigator.Size = new System.Drawing.Size(284, 25);
            this.produtosBindingNavigator.TabIndex = 0;
            this.produtosBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 15);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // produtosBindingNavigatorSaveItem
            // 
            this.produtosBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.produtosBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("produtosBindingNavigatorSaveItem.Image")));
            this.produtosBindingNavigatorSaveItem.Name = "produtosBindingNavigatorSaveItem";
            this.produtosBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
            this.produtosBindingNavigatorSaveItem.Text = "Save Data";
            this.produtosBindingNavigatorSaveItem.Click += new System.EventHandler(this.produtosBindingNavigatorSaveItem_Click);
            // 
            // idprodutoLabel
            // 
            idprodutoLabel.AutoSize = true;
            idprodutoLabel.Location = new System.Drawing.Point(23, 70);
            idprodutoLabel.Name = "idprodutoLabel";
            idprodutoLabel.Size = new System.Drawing.Size(54, 13);
            idprodutoLabel.TabIndex = 1;
            idprodutoLabel.Text = "idproduto:";
            // 
            // idprodutoLabel1
            // 
            this.idprodutoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtosBindingSource, "idproduto", true));
            this.idprodutoLabel1.Location = new System.Drawing.Point(144, 70);
            this.idprodutoLabel1.Name = "idprodutoLabel1";
            this.idprodutoLabel1.Size = new System.Drawing.Size(121, 23);
            this.idprodutoLabel1.TabIndex = 2;
            this.idprodutoLabel1.Text = "label1";
            // 
            // idgrupoLabel
            // 
            idgrupoLabel.AutoSize = true;
            idgrupoLabel.Location = new System.Drawing.Point(23, 99);
            idgrupoLabel.Name = "idgrupoLabel";
            idgrupoLabel.Size = new System.Drawing.Size(45, 13);
            idgrupoLabel.TabIndex = 3;
            idgrupoLabel.Text = "idgrupo:";
            // 
            // idgrupoComboBox
            // 
            this.idgrupoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.produtosBindingSource, "idgrupo", true));
            this.idgrupoComboBox.DataSource = this.gruposBindingSource;
            this.idgrupoComboBox.DisplayMember = "nome";
            this.idgrupoComboBox.FormattingEnabled = true;
            this.idgrupoComboBox.Location = new System.Drawing.Point(144, 96);
            this.idgrupoComboBox.Name = "idgrupoComboBox";
            this.idgrupoComboBox.Size = new System.Drawing.Size(121, 21);
            this.idgrupoComboBox.TabIndex = 4;
            this.idgrupoComboBox.ValueMember = "idgrupo";
            // 
            // descricaoLabel
            // 
            descricaoLabel.AutoSize = true;
            descricaoLabel.Location = new System.Drawing.Point(23, 126);
            descricaoLabel.Name = "descricaoLabel";
            descricaoLabel.Size = new System.Drawing.Size(56, 13);
            descricaoLabel.TabIndex = 5;
            descricaoLabel.Text = "descricao:";
            // 
            // descricaoTextBox
            // 
            this.descricaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtosBindingSource, "descricao", true));
            this.descricaoTextBox.Location = new System.Drawing.Point(144, 123);
            this.descricaoTextBox.Name = "descricaoTextBox";
            this.descricaoTextBox.Size = new System.Drawing.Size(121, 20);
            this.descricaoTextBox.TabIndex = 6;
            // 
            // precodecompraLabel
            // 
            precodecompraLabel.AutoSize = true;
            precodecompraLabel.Location = new System.Drawing.Point(23, 152);
            precodecompraLabel.Name = "precodecompraLabel";
            precodecompraLabel.Size = new System.Drawing.Size(84, 13);
            precodecompraLabel.TabIndex = 7;
            precodecompraLabel.Text = "precodecompra:";
            // 
            // precodecompraTextBox
            // 
            this.precodecompraTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtosBindingSource, "precodecompra", true));
            this.precodecompraTextBox.Location = new System.Drawing.Point(144, 149);
            this.precodecompraTextBox.Name = "precodecompraTextBox";
            this.precodecompraTextBox.Size = new System.Drawing.Size(121, 20);
            this.precodecompraTextBox.TabIndex = 8;
            // 
            // precodevendaLabel
            // 
            precodevendaLabel.AutoSize = true;
            precodevendaLabel.Location = new System.Drawing.Point(23, 178);
            precodevendaLabel.Name = "precodevendaLabel";
            precodevendaLabel.Size = new System.Drawing.Size(79, 13);
            precodevendaLabel.TabIndex = 9;
            precodevendaLabel.Text = "precodevenda:";
            // 
            // precodevendaTextBox
            // 
            this.precodevendaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtosBindingSource, "precodevenda", true));
            this.precodevendaTextBox.Location = new System.Drawing.Point(144, 175);
            this.precodevendaTextBox.Name = "precodevendaTextBox";
            this.precodevendaTextBox.Size = new System.Drawing.Size(121, 20);
            this.precodevendaTextBox.TabIndex = 10;
            // 
            // quantidadeemestoqueLabel
            // 
            quantidadeemestoqueLabel.AutoSize = true;
            quantidadeemestoqueLabel.Location = new System.Drawing.Point(23, 204);
            quantidadeemestoqueLabel.Name = "quantidadeemestoqueLabel";
            quantidadeemestoqueLabel.Size = new System.Drawing.Size(115, 13);
            quantidadeemestoqueLabel.TabIndex = 11;
            quantidadeemestoqueLabel.Text = "quantidadeemestoque:";
            // 
            // quantidadeemestoqueTextBox
            // 
            this.quantidadeemestoqueTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtosBindingSource, "quantidadeemestoque", true));
            this.quantidadeemestoqueTextBox.Location = new System.Drawing.Point(144, 201);
            this.quantidadeemestoqueTextBox.Name = "quantidadeemestoqueTextBox";
            this.quantidadeemestoqueTextBox.Size = new System.Drawing.Size(121, 20);
            this.quantidadeemestoqueTextBox.TabIndex = 12;
            // 
            // gruposBindingSource
            // 
            this.gruposBindingSource.DataMember = "Grupos";
            this.gruposBindingSource.DataSource = this.dSEstadosECidades;
            // 
            // gruposTableAdapter
            // 
            this.gruposTableAdapter.ClearBeforeFill = true;
            // 
            // FormProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(idprodutoLabel);
            this.Controls.Add(this.idprodutoLabel1);
            this.Controls.Add(idgrupoLabel);
            this.Controls.Add(this.idgrupoComboBox);
            this.Controls.Add(descricaoLabel);
            this.Controls.Add(this.descricaoTextBox);
            this.Controls.Add(precodecompraLabel);
            this.Controls.Add(this.precodecompraTextBox);
            this.Controls.Add(precodevendaLabel);
            this.Controls.Add(this.precodevendaTextBox);
            this.Controls.Add(quantidadeemestoqueLabel);
            this.Controls.Add(this.quantidadeemestoqueTextBox);
            this.Controls.Add(this.produtosBindingNavigator);
            this.Name = "FormProdutos";
            this.Text = "FormProdutos";
            this.Load += new System.EventHandler(this.FormProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSEstadosECidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingNavigator)).EndInit();
            this.produtosBindingNavigator.ResumeLayout(false);
            this.produtosBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gruposBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSets.DSEstadosECidades dSEstadosECidades;
        private System.Windows.Forms.BindingSource produtosBindingSource;
        private DataSets.DSEstadosECidadesTableAdapters.ProdutosTableAdapter produtosTableAdapter;
        private DataSets.DSEstadosECidadesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator produtosBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton produtosBindingNavigatorSaveItem;
        private System.Windows.Forms.Label idprodutoLabel1;
        private System.Windows.Forms.ComboBox idgrupoComboBox;
        private System.Windows.Forms.TextBox descricaoTextBox;
        private System.Windows.Forms.TextBox precodecompraTextBox;
        private System.Windows.Forms.TextBox precodevendaTextBox;
        private System.Windows.Forms.TextBox quantidadeemestoqueTextBox;
        private DataSets.DSEstadosECidadesTableAdapters.GruposTableAdapter gruposTableAdapter;
        private System.Windows.Forms.BindingSource gruposBindingSource;
    }
}