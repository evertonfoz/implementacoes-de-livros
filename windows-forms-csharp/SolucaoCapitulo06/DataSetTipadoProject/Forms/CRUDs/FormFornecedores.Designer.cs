namespace DataSetTipadoProject.Forms.CRUDs {
    partial class FormFornecedores {
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
            System.Windows.Forms.Label idfornecedorLabel;
            System.Windows.Forms.Label idcidadeLabel;
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label cnpjLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFornecedores));
            this.dSEstadosECidades = new DataSetTipadoProject.DataSets.DSEstadosECidades();
            this.fornecedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fornecedoresTableAdapter = new DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.FornecedoresTableAdapter();
            this.tableAdapterManager = new DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.TableAdapterManager();
            this.cidadesTableAdapter = new DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.CidadesTableAdapter();
            this.fornecedoresBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fornecedoresBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.idfornecedorLabel1 = new System.Windows.Forms.Label();
            this.idcidadeComboBox = new System.Windows.Forms.ComboBox();
            this.cidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.cnpjTextBox = new System.Windows.Forms.TextBox();
            idfornecedorLabel = new System.Windows.Forms.Label();
            idcidadeLabel = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            cnpjLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSEstadosECidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedoresBindingNavigator)).BeginInit();
            this.fornecedoresBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cidadesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // idfornecedorLabel
            // 
            idfornecedorLabel.AutoSize = true;
            idfornecedorLabel.Location = new System.Drawing.Point(43, 89);
            idfornecedorLabel.Name = "idfornecedorLabel";
            idfornecedorLabel.Size = new System.Drawing.Size(69, 13);
            idfornecedorLabel.TabIndex = 1;
            idfornecedorLabel.Text = "idfornecedor:";
            // 
            // idcidadeLabel
            // 
            idcidadeLabel.AutoSize = true;
            idcidadeLabel.Location = new System.Drawing.Point(43, 118);
            idcidadeLabel.Name = "idcidadeLabel";
            idcidadeLabel.Size = new System.Drawing.Size(50, 13);
            idcidadeLabel.TabIndex = 3;
            idcidadeLabel.Text = "idcidade:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(43, 145);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(36, 13);
            nomeLabel.TabIndex = 5;
            nomeLabel.Text = "nome:";
            // 
            // cnpjLabel
            // 
            cnpjLabel.AutoSize = true;
            cnpjLabel.Location = new System.Drawing.Point(43, 171);
            cnpjLabel.Name = "cnpjLabel";
            cnpjLabel.Size = new System.Drawing.Size(30, 13);
            cnpjLabel.TabIndex = 7;
            cnpjLabel.Text = "cnpj:";
            // 
            // dSEstadosECidades
            // 
            this.dSEstadosECidades.DataSetName = "DSEstadosECidades";
            this.dSEstadosECidades.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fornecedoresBindingSource
            // 
            this.fornecedoresBindingSource.DataMember = "Fornecedores";
            this.fornecedoresBindingSource.DataSource = this.dSEstadosECidades;
            // 
            // fornecedoresTableAdapter
            // 
            this.fornecedoresTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CidadesTableAdapter = this.cidadesTableAdapter;
            this.tableAdapterManager.EstadosTableAdapter = null;
            this.tableAdapterManager.FornecedoresTableAdapter = this.fornecedoresTableAdapter;
            this.tableAdapterManager.GruposTableAdapter = null;
            this.tableAdapterManager.ProdutosTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cidadesTableAdapter
            // 
            this.cidadesTableAdapter.ClearBeforeFill = true;
            // 
            // fornecedoresBindingNavigator
            // 
            this.fornecedoresBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.fornecedoresBindingNavigator.BindingSource = this.fornecedoresBindingSource;
            this.fornecedoresBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.fornecedoresBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.fornecedoresBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.fornecedoresBindingNavigatorSaveItem});
            this.fornecedoresBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.fornecedoresBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.fornecedoresBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.fornecedoresBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.fornecedoresBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.fornecedoresBindingNavigator.Name = "fornecedoresBindingNavigator";
            this.fornecedoresBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.fornecedoresBindingNavigator.Size = new System.Drawing.Size(284, 25);
            this.fornecedoresBindingNavigator.TabIndex = 0;
            this.fornecedoresBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // fornecedoresBindingNavigatorSaveItem
            // 
            this.fornecedoresBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fornecedoresBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("fornecedoresBindingNavigatorSaveItem.Image")));
            this.fornecedoresBindingNavigatorSaveItem.Name = "fornecedoresBindingNavigatorSaveItem";
            this.fornecedoresBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.fornecedoresBindingNavigatorSaveItem.Text = "Save Data";
            this.fornecedoresBindingNavigatorSaveItem.Click += new System.EventHandler(this.fornecedoresBindingNavigatorSaveItem_Click);
            // 
            // idfornecedorLabel1
            // 
            this.idfornecedorLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornecedoresBindingSource, "idfornecedor", true));
            this.idfornecedorLabel1.Location = new System.Drawing.Point(118, 89);
            this.idfornecedorLabel1.Name = "idfornecedorLabel1";
            this.idfornecedorLabel1.Size = new System.Drawing.Size(121, 23);
            this.idfornecedorLabel1.TabIndex = 2;
            this.idfornecedorLabel1.Text = "label1";
            // 
            // idcidadeComboBox
            // 
            this.idcidadeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.fornecedoresBindingSource, "idcidade", true));
            this.idcidadeComboBox.DataSource = this.cidadesBindingSource;
            this.idcidadeComboBox.DisplayMember = "nome";
            this.idcidadeComboBox.FormattingEnabled = true;
            this.idcidadeComboBox.Location = new System.Drawing.Point(118, 115);
            this.idcidadeComboBox.Name = "idcidadeComboBox";
            this.idcidadeComboBox.Size = new System.Drawing.Size(121, 21);
            this.idcidadeComboBox.TabIndex = 4;
            this.idcidadeComboBox.ValueMember = "idcidade";
            // 
            // cidadesBindingSource
            // 
            this.cidadesBindingSource.DataMember = "Cidades";
            this.cidadesBindingSource.DataSource = this.dSEstadosECidades;
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornecedoresBindingSource, "nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(118, 142);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(121, 20);
            this.nomeTextBox.TabIndex = 6;
            // 
            // cnpjTextBox
            // 
            this.cnpjTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fornecedoresBindingSource, "cnpj", true));
            this.cnpjTextBox.Location = new System.Drawing.Point(118, 168);
            this.cnpjTextBox.Name = "cnpjTextBox";
            this.cnpjTextBox.Size = new System.Drawing.Size(121, 20);
            this.cnpjTextBox.TabIndex = 8;
            // 
            // FormFornecedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(idfornecedorLabel);
            this.Controls.Add(this.idfornecedorLabel1);
            this.Controls.Add(idcidadeLabel);
            this.Controls.Add(this.idcidadeComboBox);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(cnpjLabel);
            this.Controls.Add(this.cnpjTextBox);
            this.Controls.Add(this.fornecedoresBindingNavigator);
            this.Name = "FormFornecedores";
            this.Text = "FormFornecedores";
            this.Load += new System.EventHandler(this.FormFornecedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSEstadosECidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedoresBindingNavigator)).EndInit();
            this.fornecedoresBindingNavigator.ResumeLayout(false);
            this.fornecedoresBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cidadesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSets.DSEstadosECidades dSEstadosECidades;
        private System.Windows.Forms.BindingSource fornecedoresBindingSource;
        private DataSets.DSEstadosECidadesTableAdapters.FornecedoresTableAdapter fornecedoresTableAdapter;
        private DataSets.DSEstadosECidadesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator fornecedoresBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton fornecedoresBindingNavigatorSaveItem;
        private System.Windows.Forms.Label idfornecedorLabel1;
        private System.Windows.Forms.ComboBox idcidadeComboBox;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox cnpjTextBox;
        private DataSets.DSEstadosECidadesTableAdapters.CidadesTableAdapter cidadesTableAdapter;
        private System.Windows.Forms.BindingSource cidadesBindingSource;
    }
}