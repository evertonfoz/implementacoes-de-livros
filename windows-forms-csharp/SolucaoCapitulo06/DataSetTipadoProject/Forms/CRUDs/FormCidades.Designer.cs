namespace DataSetTipadoProject.Forms.CRUDs {
    partial class FormCidades {
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
            System.Windows.Forms.Label idcidadeLabel;
            System.Windows.Forms.Label idestadoLabel;
            System.Windows.Forms.Label nomeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCidades));
            this.dSEstadosECidades = new DataSetTipadoProject.DataSets.DSEstadosECidades();
            this.cidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cidadesTableAdapter = new DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.CidadesTableAdapter();
            this.tableAdapterManager = new DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.TableAdapterManager();
            this.estadosTableAdapter = new DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.EstadosTableAdapter();
            this.cidadesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.cidadesBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.idcidadeLabel1 = new System.Windows.Forms.Label();
            this.idestadoComboBox = new System.Windows.Forms.ComboBox();
            this.estadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            idcidadeLabel = new System.Windows.Forms.Label();
            idestadoLabel = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSEstadosECidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cidadesBindingNavigator)).BeginInit();
            this.cidadesBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estadosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // idcidadeLabel
            // 
            idcidadeLabel.AutoSize = true;
            idcidadeLabel.Location = new System.Drawing.Point(52, 102);
            idcidadeLabel.Name = "idcidadeLabel";
            idcidadeLabel.Size = new System.Drawing.Size(50, 13);
            idcidadeLabel.TabIndex = 1;
            idcidadeLabel.Text = "idcidade:";
            // 
            // idestadoLabel
            // 
            idestadoLabel.AutoSize = true;
            idestadoLabel.Location = new System.Drawing.Point(52, 131);
            idestadoLabel.Name = "idestadoLabel";
            idestadoLabel.Size = new System.Drawing.Size(50, 13);
            idestadoLabel.TabIndex = 3;
            idestadoLabel.Text = "idestado:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(52, 158);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(36, 13);
            nomeLabel.TabIndex = 5;
            nomeLabel.Text = "nome:";
            // 
            // dSEstadosECidades
            // 
            this.dSEstadosECidades.DataSetName = "DSEstadosECidades";
            this.dSEstadosECidades.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cidadesBindingSource
            // 
            this.cidadesBindingSource.DataMember = "Cidades";
            this.cidadesBindingSource.DataSource = this.dSEstadosECidades;
            // 
            // cidadesTableAdapter
            // 
            this.cidadesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CidadesTableAdapter = this.cidadesTableAdapter;
            this.tableAdapterManager.EstadosTableAdapter = this.estadosTableAdapter;
            this.tableAdapterManager.FornecedoresTableAdapter = null;
            this.tableAdapterManager.GruposTableAdapter = null;
            this.tableAdapterManager.ProdutosTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DataSetTipadoProject.DataSets.DSEstadosECidadesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // estadosTableAdapter
            // 
            this.estadosTableAdapter.ClearBeforeFill = true;
            // 
            // cidadesBindingNavigator
            // 
            this.cidadesBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.cidadesBindingNavigator.BindingSource = this.cidadesBindingSource;
            this.cidadesBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.cidadesBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.cidadesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.cidadesBindingNavigatorSaveItem});
            this.cidadesBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.cidadesBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.cidadesBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.cidadesBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.cidadesBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.cidadesBindingNavigator.Name = "cidadesBindingNavigator";
            this.cidadesBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.cidadesBindingNavigator.Size = new System.Drawing.Size(284, 25);
            this.cidadesBindingNavigator.TabIndex = 0;
            this.cidadesBindingNavigator.Text = "bindingNavigator1";
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
            // cidadesBindingNavigatorSaveItem
            // 
            this.cidadesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cidadesBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("cidadesBindingNavigatorSaveItem.Image")));
            this.cidadesBindingNavigatorSaveItem.Name = "cidadesBindingNavigatorSaveItem";
            this.cidadesBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.cidadesBindingNavigatorSaveItem.Text = "Save Data";
            this.cidadesBindingNavigatorSaveItem.Click += new System.EventHandler(this.cidadesBindingNavigatorSaveItem_Click);
            // 
            // idcidadeLabel1
            // 
            this.idcidadeLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cidadesBindingSource, "idcidade", true));
            this.idcidadeLabel1.Location = new System.Drawing.Point(108, 102);
            this.idcidadeLabel1.Name = "idcidadeLabel1";
            this.idcidadeLabel1.Size = new System.Drawing.Size(121, 23);
            this.idcidadeLabel1.TabIndex = 2;
            this.idcidadeLabel1.Text = "label1";
            // 
            // idestadoComboBox
            // 
            this.idestadoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cidadesBindingSource, "idestado", true));
            this.idestadoComboBox.DataSource = this.estadosBindingSource;
            this.idestadoComboBox.DisplayMember = "nome";
            this.idestadoComboBox.FormattingEnabled = true;
            this.idestadoComboBox.Location = new System.Drawing.Point(108, 128);
            this.idestadoComboBox.Name = "idestadoComboBox";
            this.idestadoComboBox.Size = new System.Drawing.Size(121, 21);
            this.idestadoComboBox.TabIndex = 4;
            this.idestadoComboBox.ValueMember = "idestado";
            // 
            // estadosBindingSource
            // 
            this.estadosBindingSource.DataMember = "Estados";
            this.estadosBindingSource.DataSource = this.dSEstadosECidades;
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cidadesBindingSource, "nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(108, 155);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(121, 20);
            this.nomeTextBox.TabIndex = 6;
            // 
            // FormCidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(idcidadeLabel);
            this.Controls.Add(this.idcidadeLabel1);
            this.Controls.Add(idestadoLabel);
            this.Controls.Add(this.idestadoComboBox);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(this.cidadesBindingNavigator);
            this.Name = "FormCidades";
            this.Text = "FormCidades";
            this.Load += new System.EventHandler(this.FormCidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSEstadosECidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cidadesBindingNavigator)).EndInit();
            this.cidadesBindingNavigator.ResumeLayout(false);
            this.cidadesBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estadosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSets.DSEstadosECidades dSEstadosECidades;
        private System.Windows.Forms.BindingSource cidadesBindingSource;
        private DataSets.DSEstadosECidadesTableAdapters.CidadesTableAdapter cidadesTableAdapter;
        private DataSets.DSEstadosECidadesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator cidadesBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton cidadesBindingNavigatorSaveItem;
        private System.Windows.Forms.Label idcidadeLabel1;
        private System.Windows.Forms.ComboBox idestadoComboBox;
        private System.Windows.Forms.TextBox nomeTextBox;
        private DataSets.DSEstadosECidadesTableAdapters.EstadosTableAdapter estadosTableAdapter;
        private System.Windows.Forms.BindingSource estadosBindingSource;
    }
}