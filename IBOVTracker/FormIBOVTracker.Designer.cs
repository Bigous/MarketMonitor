namespace IBOVTracker
{
	partial class FormIBOVTracker
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIBOVTracker));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
			this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
			this.IBOVLabel = new MaterialSkin.Controls.MaterialLabel();
			this.IBOVTeoricoLabel = new MaterialSkin.Controls.MaterialLabel();
			this.WINFUTLabel = new MaterialSkin.Controls.MaterialLabel();
			this.GapTeoricoLabel = new MaterialSkin.Controls.MaterialLabel();
			this.EmLeilaoLabel = new MaterialSkin.Controls.MaterialLabel();
			this.ReprLeilaoLabel = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
			this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
			this.LeilaoValDGV = new System.Windows.Forms.DataGridView();
			this.LeilaoDesDGV = new System.Windows.Forms.DataGridView();
			this.MercadoValDGV = new System.Windows.Forms.DataGridView();
			this.MercadoDesDGV = new System.Windows.Forms.DataGridView();
			this.CopyIBOVButton = new MaterialSkin.Controls.MaterialButton();
			this.GAPTB = new MaterialSkin.Controls.MaterialTextBox();
			this.TopSwitch = new MaterialSkin.Controls.MaterialSwitch();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.IBOVTP = new System.Windows.Forms.TableLayoutPanel();
			this.ReductorLabel = new MaterialSkin.Controls.MaterialLabel();
			this.DateLabel = new MaterialSkin.Controls.MaterialLabel();
			this.CalcLabel = new MaterialSkin.Controls.MaterialLabel();
			this.IBOVDGV = new System.Windows.Forms.DataGridView();
			this.StatusLabel = new MaterialSkin.Controls.MaterialLabel();
			this.tableLayoutPanel1.SuspendLayout();
			this.materialTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LeilaoValDGV)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeilaoDesDGV)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MercadoValDGV)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MercadoDesDGV)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.IBOVTP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.IBOVDGV)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.materialTabSelector1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.materialTabControl1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.StatusLabel, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 24);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 323);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// materialTabSelector1
			// 
			this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
			this.materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
			this.materialTabSelector1.Depth = 0;
			this.materialTabSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialTabSelector1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.materialTabSelector1.Location = new System.Drawing.Point(3, 3);
			this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialTabSelector1.Name = "materialTabSelector1";
			this.materialTabSelector1.Size = new System.Drawing.Size(788, 44);
			this.materialTabSelector1.TabIndex = 0;
			this.materialTabSelector1.Text = "materialTabSelector1";
			// 
			// materialTabControl1
			// 
			this.materialTabControl1.Controls.Add(this.tabPage1);
			this.materialTabControl1.Controls.Add(this.tabPage2);
			this.materialTabControl1.Depth = 0;
			this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialTabControl1.Location = new System.Drawing.Point(3, 53);
			this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialTabControl1.Multiline = true;
			this.materialTabControl1.Name = "materialTabControl1";
			this.materialTabControl1.SelectedIndex = 0;
			this.materialTabControl1.Size = new System.Drawing.Size(788, 243);
			this.materialTabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.tableLayoutPanel2);
			this.tabPage1.Location = new System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(780, 215);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Gap";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 6;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.Controls.Add(this.materialLabel1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.materialLabel2, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.materialLabel3, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.materialLabel4, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.materialLabel5, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.materialLabel6, 0, 5);
			this.tableLayoutPanel2.Controls.Add(this.materialLabel7, 0, 6);
			this.tableLayoutPanel2.Controls.Add(this.IBOVLabel, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.IBOVTeoricoLabel, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.WINFUTLabel, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.GapTeoricoLabel, 1, 4);
			this.tableLayoutPanel2.Controls.Add(this.EmLeilaoLabel, 1, 5);
			this.tableLayoutPanel2.Controls.Add(this.ReprLeilaoLabel, 1, 6);
			this.tableLayoutPanel2.Controls.Add(this.materialLabel8, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.materialLabel9, 4, 0);
			this.tableLayoutPanel2.Controls.Add(this.materialLabel10, 2, 1);
			this.tableLayoutPanel2.Controls.Add(this.materialLabel11, 3, 1);
			this.tableLayoutPanel2.Controls.Add(this.materialLabel12, 4, 1);
			this.tableLayoutPanel2.Controls.Add(this.materialLabel13, 5, 1);
			this.tableLayoutPanel2.Controls.Add(this.LeilaoValDGV, 2, 2);
			this.tableLayoutPanel2.Controls.Add(this.LeilaoDesDGV, 3, 2);
			this.tableLayoutPanel2.Controls.Add(this.MercadoValDGV, 4, 2);
			this.tableLayoutPanel2.Controls.Add(this.MercadoDesDGV, 5, 2);
			this.tableLayoutPanel2.Controls.Add(this.CopyIBOVButton, 0, 7);
			this.tableLayoutPanel2.Controls.Add(this.GAPTB, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.TopSwitch, 1, 7);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 8;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(774, 209);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// materialLabel1
			// 
			this.materialLabel1.AutoSize = true;
			this.materialLabel1.Depth = 0;
			this.materialLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.materialLabel1.Location = new System.Drawing.Point(3, 0);
			this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel1.Name = "materialLabel1";
			this.materialLabel1.Size = new System.Drawing.Size(144, 24);
			this.materialLabel1.TabIndex = 0;
			this.materialLabel1.Text = "IBOV";
			this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// materialLabel2
			// 
			this.materialLabel2.AutoSize = true;
			this.materialLabel2.Depth = 0;
			this.materialLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.materialLabel2.Location = new System.Drawing.Point(3, 24);
			this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel2.Name = "materialLabel2";
			this.materialLabel2.Size = new System.Drawing.Size(144, 24);
			this.materialLabel2.TabIndex = 1;
			this.materialLabel2.Text = "IBOV Teórico";
			this.materialLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// materialLabel3
			// 
			this.materialLabel3.AutoSize = true;
			this.materialLabel3.Depth = 0;
			this.materialLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.materialLabel3.Location = new System.Drawing.Point(3, 48);
			this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel3.Name = "materialLabel3";
			this.materialLabel3.Size = new System.Drawing.Size(144, 24);
			this.materialLabel3.TabIndex = 2;
			this.materialLabel3.Text = "WINFUT";
			this.materialLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// materialLabel4
			// 
			this.materialLabel4.AutoSize = true;
			this.materialLabel4.Depth = 0;
			this.materialLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.materialLabel4.Location = new System.Drawing.Point(3, 72);
			this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel4.Name = "materialLabel4";
			this.materialLabel4.Size = new System.Drawing.Size(144, 50);
			this.materialLabel4.TabIndex = 3;
			this.materialLabel4.Text = "GAP";
			this.materialLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// materialLabel5
			// 
			this.materialLabel5.AutoSize = true;
			this.materialLabel5.Depth = 0;
			this.materialLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.materialLabel5.Location = new System.Drawing.Point(3, 122);
			this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel5.Name = "materialLabel5";
			this.materialLabel5.Size = new System.Drawing.Size(144, 24);
			this.materialLabel5.TabIndex = 4;
			this.materialLabel5.Text = "GAP Teórico";
			this.materialLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// materialLabel6
			// 
			this.materialLabel6.AutoSize = true;
			this.materialLabel6.Depth = 0;
			this.materialLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.materialLabel6.Location = new System.Drawing.Point(3, 146);
			this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel6.Name = "materialLabel6";
			this.materialLabel6.Size = new System.Drawing.Size(144, 24);
			this.materialLabel6.TabIndex = 5;
			this.materialLabel6.Text = "Em Leilão";
			this.materialLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// materialLabel7
			// 
			this.materialLabel7.AutoSize = true;
			this.materialLabel7.Depth = 0;
			this.materialLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.materialLabel7.Location = new System.Drawing.Point(3, 170);
			this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel7.Name = "materialLabel7";
			this.materialLabel7.Size = new System.Drawing.Size(144, 24);
			this.materialLabel7.TabIndex = 6;
			this.materialLabel7.Text = "Repr. Leilão";
			this.materialLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// IBOVLabel
			// 
			this.IBOVLabel.AutoSize = true;
			this.IBOVLabel.Depth = 0;
			this.IBOVLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.IBOVLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.IBOVLabel.Location = new System.Drawing.Point(153, 0);
			this.IBOVLabel.MouseState = MaterialSkin.MouseState.HOVER;
			this.IBOVLabel.Name = "IBOVLabel";
			this.IBOVLabel.Size = new System.Drawing.Size(84, 24);
			this.IBOVLabel.TabIndex = 7;
			this.IBOVLabel.Text = "??????";
			this.IBOVLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// IBOVTeoricoLabel
			// 
			this.IBOVTeoricoLabel.AutoSize = true;
			this.IBOVTeoricoLabel.Depth = 0;
			this.IBOVTeoricoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.IBOVTeoricoLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.IBOVTeoricoLabel.Location = new System.Drawing.Point(153, 24);
			this.IBOVTeoricoLabel.MouseState = MaterialSkin.MouseState.HOVER;
			this.IBOVTeoricoLabel.Name = "IBOVTeoricoLabel";
			this.IBOVTeoricoLabel.Size = new System.Drawing.Size(84, 24);
			this.IBOVTeoricoLabel.TabIndex = 8;
			this.IBOVTeoricoLabel.Text = "??????";
			this.IBOVTeoricoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// WINFUTLabel
			// 
			this.WINFUTLabel.AutoSize = true;
			this.WINFUTLabel.Depth = 0;
			this.WINFUTLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.WINFUTLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.WINFUTLabel.Location = new System.Drawing.Point(153, 48);
			this.WINFUTLabel.MouseState = MaterialSkin.MouseState.HOVER;
			this.WINFUTLabel.Name = "WINFUTLabel";
			this.WINFUTLabel.Size = new System.Drawing.Size(84, 24);
			this.WINFUTLabel.TabIndex = 9;
			this.WINFUTLabel.Text = "??????";
			this.WINFUTLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// GapTeoricoLabel
			// 
			this.GapTeoricoLabel.AutoSize = true;
			this.GapTeoricoLabel.Depth = 0;
			this.GapTeoricoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GapTeoricoLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.GapTeoricoLabel.HighEmphasis = true;
			this.GapTeoricoLabel.Location = new System.Drawing.Point(153, 122);
			this.GapTeoricoLabel.MouseState = MaterialSkin.MouseState.HOVER;
			this.GapTeoricoLabel.Name = "GapTeoricoLabel";
			this.GapTeoricoLabel.Size = new System.Drawing.Size(84, 24);
			this.GapTeoricoLabel.TabIndex = 10;
			this.GapTeoricoLabel.Text = "??????";
			this.GapTeoricoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EmLeilaoLabel
			// 
			this.EmLeilaoLabel.AutoSize = true;
			this.EmLeilaoLabel.Depth = 0;
			this.EmLeilaoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EmLeilaoLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.EmLeilaoLabel.Location = new System.Drawing.Point(153, 146);
			this.EmLeilaoLabel.MouseState = MaterialSkin.MouseState.HOVER;
			this.EmLeilaoLabel.Name = "EmLeilaoLabel";
			this.EmLeilaoLabel.Size = new System.Drawing.Size(84, 24);
			this.EmLeilaoLabel.TabIndex = 11;
			this.EmLeilaoLabel.Text = "??????";
			this.EmLeilaoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReprLeilaoLabel
			// 
			this.ReprLeilaoLabel.AutoSize = true;
			this.ReprLeilaoLabel.Depth = 0;
			this.ReprLeilaoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ReprLeilaoLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ReprLeilaoLabel.Location = new System.Drawing.Point(153, 170);
			this.ReprLeilaoLabel.MouseState = MaterialSkin.MouseState.HOVER;
			this.ReprLeilaoLabel.Name = "ReprLeilaoLabel";
			this.ReprLeilaoLabel.Size = new System.Drawing.Size(84, 24);
			this.ReprLeilaoLabel.TabIndex = 12;
			this.ReprLeilaoLabel.Text = "??????";
			this.ReprLeilaoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// materialLabel8
			// 
			this.materialLabel8.AutoSize = true;
			this.tableLayoutPanel2.SetColumnSpan(this.materialLabel8, 2);
			this.materialLabel8.Depth = 0;
			this.materialLabel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialLabel8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.materialLabel8.Location = new System.Drawing.Point(243, 0);
			this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel8.Name = "materialLabel8";
			this.materialLabel8.Size = new System.Drawing.Size(260, 24);
			this.materialLabel8.TabIndex = 13;
			this.materialLabel8.Text = "Leilão";
			this.materialLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// materialLabel9
			// 
			this.materialLabel9.AutoSize = true;
			this.tableLayoutPanel2.SetColumnSpan(this.materialLabel9, 2);
			this.materialLabel9.Depth = 0;
			this.materialLabel9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialLabel9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.materialLabel9.Location = new System.Drawing.Point(509, 0);
			this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel9.Name = "materialLabel9";
			this.materialLabel9.Size = new System.Drawing.Size(262, 24);
			this.materialLabel9.TabIndex = 14;
			this.materialLabel9.Text = "Mercado";
			this.materialLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// materialLabel10
			// 
			this.materialLabel10.AutoSize = true;
			this.materialLabel10.Depth = 0;
			this.materialLabel10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialLabel10.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.materialLabel10.Location = new System.Drawing.Point(243, 24);
			this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel10.Name = "materialLabel10";
			this.materialLabel10.Size = new System.Drawing.Size(127, 24);
			this.materialLabel10.TabIndex = 15;
			this.materialLabel10.Text = "Valorização";
			this.materialLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// materialLabel11
			// 
			this.materialLabel11.AutoSize = true;
			this.materialLabel11.Depth = 0;
			this.materialLabel11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialLabel11.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.materialLabel11.Location = new System.Drawing.Point(376, 24);
			this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel11.Name = "materialLabel11";
			this.materialLabel11.Size = new System.Drawing.Size(127, 24);
			this.materialLabel11.TabIndex = 16;
			this.materialLabel11.Text = "Desvalorização";
			this.materialLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// materialLabel12
			// 
			this.materialLabel12.AutoSize = true;
			this.materialLabel12.Depth = 0;
			this.materialLabel12.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialLabel12.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.materialLabel12.Location = new System.Drawing.Point(509, 24);
			this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel12.Name = "materialLabel12";
			this.materialLabel12.Size = new System.Drawing.Size(127, 24);
			this.materialLabel12.TabIndex = 17;
			this.materialLabel12.Text = "Valorização";
			this.materialLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// materialLabel13
			// 
			this.materialLabel13.AutoSize = true;
			this.materialLabel13.Depth = 0;
			this.materialLabel13.Dock = System.Windows.Forms.DockStyle.Fill;
			this.materialLabel13.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.materialLabel13.Location = new System.Drawing.Point(642, 24);
			this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialLabel13.Name = "materialLabel13";
			this.materialLabel13.Size = new System.Drawing.Size(129, 24);
			this.materialLabel13.TabIndex = 18;
			this.materialLabel13.Text = "Desvalorização";
			this.materialLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LeilaoValDGV
			// 
			this.LeilaoValDGV.AllowUserToAddRows = false;
			this.LeilaoValDGV.AllowUserToDeleteRows = false;
			this.LeilaoValDGV.AllowUserToResizeRows = false;
			this.LeilaoValDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.LeilaoValDGV.ColumnHeadersVisible = false;
			this.LeilaoValDGV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LeilaoValDGV.Enabled = false;
			this.LeilaoValDGV.Location = new System.Drawing.Point(243, 51);
			this.LeilaoValDGV.Name = "LeilaoValDGV";
			this.LeilaoValDGV.ReadOnly = true;
			this.LeilaoValDGV.RowHeadersVisible = false;
			this.tableLayoutPanel2.SetRowSpan(this.LeilaoValDGV, 6);
			this.LeilaoValDGV.RowTemplate.Height = 25;
			this.LeilaoValDGV.Size = new System.Drawing.Size(127, 155);
			this.LeilaoValDGV.TabIndex = 19;
			// 
			// LeilaoDesDGV
			// 
			this.LeilaoDesDGV.AllowUserToAddRows = false;
			this.LeilaoDesDGV.AllowUserToDeleteRows = false;
			this.LeilaoDesDGV.AllowUserToResizeRows = false;
			this.LeilaoDesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.LeilaoDesDGV.ColumnHeadersVisible = false;
			this.LeilaoDesDGV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LeilaoDesDGV.Enabled = false;
			this.LeilaoDesDGV.Location = new System.Drawing.Point(376, 51);
			this.LeilaoDesDGV.Name = "LeilaoDesDGV";
			this.LeilaoDesDGV.ReadOnly = true;
			this.LeilaoDesDGV.RowHeadersVisible = false;
			this.tableLayoutPanel2.SetRowSpan(this.LeilaoDesDGV, 6);
			this.LeilaoDesDGV.RowTemplate.Height = 25;
			this.LeilaoDesDGV.Size = new System.Drawing.Size(127, 155);
			this.LeilaoDesDGV.TabIndex = 20;
			// 
			// MercadoValDGV
			// 
			this.MercadoValDGV.AllowUserToAddRows = false;
			this.MercadoValDGV.AllowUserToDeleteRows = false;
			this.MercadoValDGV.AllowUserToResizeRows = false;
			this.MercadoValDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.MercadoValDGV.ColumnHeadersVisible = false;
			this.MercadoValDGV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MercadoValDGV.Enabled = false;
			this.MercadoValDGV.Location = new System.Drawing.Point(509, 51);
			this.MercadoValDGV.Name = "MercadoValDGV";
			this.MercadoValDGV.ReadOnly = true;
			this.MercadoValDGV.RowHeadersVisible = false;
			this.tableLayoutPanel2.SetRowSpan(this.MercadoValDGV, 6);
			this.MercadoValDGV.RowTemplate.Height = 25;
			this.MercadoValDGV.Size = new System.Drawing.Size(127, 155);
			this.MercadoValDGV.TabIndex = 21;
			// 
			// MercadoDesDGV
			// 
			this.MercadoDesDGV.AllowUserToAddRows = false;
			this.MercadoDesDGV.AllowUserToDeleteRows = false;
			this.MercadoDesDGV.AllowUserToResizeRows = false;
			this.MercadoDesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.MercadoDesDGV.ColumnHeadersVisible = false;
			this.MercadoDesDGV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MercadoDesDGV.Enabled = false;
			this.MercadoDesDGV.Location = new System.Drawing.Point(642, 51);
			this.MercadoDesDGV.Name = "MercadoDesDGV";
			this.MercadoDesDGV.ReadOnly = true;
			this.MercadoDesDGV.RowHeadersVisible = false;
			this.tableLayoutPanel2.SetRowSpan(this.MercadoDesDGV, 6);
			this.MercadoDesDGV.RowTemplate.Height = 25;
			this.MercadoDesDGV.Size = new System.Drawing.Size(129, 155);
			this.MercadoDesDGV.TabIndex = 22;
			// 
			// CopyIBOVButton
			// 
			this.CopyIBOVButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CopyIBOVButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
			this.CopyIBOVButton.Depth = 0;
			this.CopyIBOVButton.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.CopyIBOVButton.HighEmphasis = true;
			this.CopyIBOVButton.Icon = null;
			this.CopyIBOVButton.Location = new System.Drawing.Point(4, 200);
			this.CopyIBOVButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.CopyIBOVButton.MouseState = MaterialSkin.MouseState.HOVER;
			this.CopyIBOVButton.Name = "CopyIBOVButton";
			this.CopyIBOVButton.NoAccentTextColor = System.Drawing.Color.Empty;
			this.CopyIBOVButton.Size = new System.Drawing.Size(142, 3);
			this.CopyIBOVButton.TabIndex = 23;
			this.CopyIBOVButton.Text = "IBOV Clipboard";
			this.CopyIBOVButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			this.CopyIBOVButton.UseAccentColor = false;
			this.CopyIBOVButton.UseVisualStyleBackColor = true;
			this.CopyIBOVButton.Click += new System.EventHandler(this.CopyIBOVButton_Click);
			// 
			// GAPTB
			// 
			this.GAPTB.AnimateReadOnly = false;
			this.GAPTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.GAPTB.Depth = 0;
			this.GAPTB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GAPTB.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.GAPTB.LeadingIcon = null;
			this.GAPTB.Location = new System.Drawing.Point(153, 75);
			this.GAPTB.MaxLength = 50;
			this.GAPTB.MouseState = MaterialSkin.MouseState.OUT;
			this.GAPTB.Multiline = false;
			this.GAPTB.Name = "GAPTB";
			this.GAPTB.Size = new System.Drawing.Size(84, 50);
			this.GAPTB.TabIndex = 24;
			this.GAPTB.Text = "";
			this.GAPTB.TrailingIcon = null;
			// 
			// TopSwitch
			// 
			this.TopSwitch.AutoSize = true;
			this.TopSwitch.Depth = 0;
			this.TopSwitch.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.TopSwitch.Location = new System.Drawing.Point(150, 194);
			this.TopSwitch.Margin = new System.Windows.Forms.Padding(0);
			this.TopSwitch.MouseLocation = new System.Drawing.Point(-1, -1);
			this.TopSwitch.MouseState = MaterialSkin.MouseState.HOVER;
			this.TopSwitch.Name = "TopSwitch";
			this.TopSwitch.Ripple = true;
			this.TopSwitch.Size = new System.Drawing.Size(90, 15);
			this.TopSwitch.TabIndex = 25;
			this.TopSwitch.Text = "Top";
			this.TopSwitch.UseVisualStyleBackColor = true;
			this.TopSwitch.CheckedChanged += new System.EventHandler(this.TopSwitch_CheckedChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.IBOVTP);
			this.tabPage2.Location = new System.Drawing.Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(780, 215);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "IBOV";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// IBOVTP
			// 
			this.IBOVTP.ColumnCount = 3;
			this.IBOVTP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247F));
			this.IBOVTP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.IBOVTP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.IBOVTP.Controls.Add(this.ReductorLabel, 0, 0);
			this.IBOVTP.Controls.Add(this.DateLabel, 2, 0);
			this.IBOVTP.Controls.Add(this.CalcLabel, 1, 0);
			this.IBOVTP.Controls.Add(this.IBOVDGV, 0, 1);
			this.IBOVTP.Dock = System.Windows.Forms.DockStyle.Fill;
			this.IBOVTP.Location = new System.Drawing.Point(3, 3);
			this.IBOVTP.Name = "IBOVTP";
			this.IBOVTP.RowCount = 2;
			this.IBOVTP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.IBOVTP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.IBOVTP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.IBOVTP.Size = new System.Drawing.Size(774, 209);
			this.IBOVTP.TabIndex = 0;
			// 
			// ReductorLabel
			// 
			this.ReductorLabel.AutoSize = true;
			this.ReductorLabel.Depth = 0;
			this.ReductorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ReductorLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ReductorLabel.Location = new System.Drawing.Point(3, 0);
			this.ReductorLabel.MouseState = MaterialSkin.MouseState.HOVER;
			this.ReductorLabel.Name = "ReductorLabel";
			this.ReductorLabel.Size = new System.Drawing.Size(241, 24);
			this.ReductorLabel.TabIndex = 0;
			this.ReductorLabel.Text = "materialLabel2";
			this.ReductorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DateLabel
			// 
			this.DateLabel.AutoSize = true;
			this.DateLabel.Depth = 0;
			this.DateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DateLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.DateLabel.Location = new System.Drawing.Point(677, 0);
			this.DateLabel.MouseState = MaterialSkin.MouseState.HOVER;
			this.DateLabel.Name = "DateLabel";
			this.DateLabel.Size = new System.Drawing.Size(94, 24);
			this.DateLabel.TabIndex = 1;
			this.DateLabel.Text = "materialLabel2";
			this.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// CalcLabel
			// 
			this.CalcLabel.AutoSize = true;
			this.CalcLabel.Depth = 0;
			this.CalcLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CalcLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.CalcLabel.Location = new System.Drawing.Point(250, 0);
			this.CalcLabel.MouseState = MaterialSkin.MouseState.HOVER;
			this.CalcLabel.Name = "CalcLabel";
			this.CalcLabel.Size = new System.Drawing.Size(421, 24);
			this.CalcLabel.TabIndex = 2;
			this.CalcLabel.Text = "materialLabel2";
			this.CalcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// IBOVDGV
			// 
			this.IBOVDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.IBOVTP.SetColumnSpan(this.IBOVDGV, 3);
			this.IBOVDGV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.IBOVDGV.Location = new System.Drawing.Point(3, 27);
			this.IBOVDGV.Name = "IBOVDGV";
			this.IBOVDGV.RowHeadersVisible = false;
			this.IBOVDGV.RowTemplate.Height = 25;
			this.IBOVDGV.Size = new System.Drawing.Size(768, 179);
			this.IBOVDGV.TabIndex = 3;
			// 
			// StatusLabel
			// 
			this.StatusLabel.AutoSize = true;
			this.StatusLabel.Depth = 0;
			this.StatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.StatusLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.StatusLabel.Location = new System.Drawing.Point(3, 299);
			this.StatusLabel.MouseState = MaterialSkin.MouseState.HOVER;
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(788, 24);
			this.StatusLabel.TabIndex = 2;
			this.StatusLabel.Text = "Loading...";
			this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormIBOVTracker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 350);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(800, 350);
			this.Name = "FormIBOVTracker";
			this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
			this.Text = "Bigous IBOV Tracker";
			this.Load += new System.EventHandler(this.FormIBOVTracker_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.materialTabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LeilaoValDGV)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeilaoDesDGV)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MercadoValDGV)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MercadoDesDGV)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.IBOVTP.ResumeLayout(false);
			this.IBOVTP.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.IBOVDGV)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
		private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private MaterialSkin.Controls.MaterialLabel StatusLabel;
		private TableLayoutPanel IBOVTP;
		private MaterialSkin.Controls.MaterialLabel ReductorLabel;
		private MaterialSkin.Controls.MaterialLabel DateLabel;
		private MaterialSkin.Controls.MaterialLabel CalcLabel;
		private DataGridView IBOVDGV;
		private TableLayoutPanel tableLayoutPanel2;
		private MaterialSkin.Controls.MaterialLabel materialLabel1;
		private MaterialSkin.Controls.MaterialLabel materialLabel2;
		private MaterialSkin.Controls.MaterialLabel materialLabel3;
		private MaterialSkin.Controls.MaterialLabel materialLabel4;
		private MaterialSkin.Controls.MaterialLabel materialLabel5;
		private MaterialSkin.Controls.MaterialLabel materialLabel6;
		private MaterialSkin.Controls.MaterialLabel materialLabel7;
		private MaterialSkin.Controls.MaterialLabel IBOVLabel;
		private MaterialSkin.Controls.MaterialLabel IBOVTeoricoLabel;
		private MaterialSkin.Controls.MaterialLabel WINFUTLabel;
		private MaterialSkin.Controls.MaterialLabel GapTeoricoLabel;
		private MaterialSkin.Controls.MaterialLabel EmLeilaoLabel;
		private MaterialSkin.Controls.MaterialLabel ReprLeilaoLabel;
		private MaterialSkin.Controls.MaterialLabel materialLabel8;
		private MaterialSkin.Controls.MaterialLabel materialLabel9;
		private MaterialSkin.Controls.MaterialLabel materialLabel10;
		private MaterialSkin.Controls.MaterialLabel materialLabel11;
		private MaterialSkin.Controls.MaterialLabel materialLabel12;
		private MaterialSkin.Controls.MaterialLabel materialLabel13;
		private DataGridView LeilaoValDGV;
		private DataGridView LeilaoDesDGV;
		private DataGridView MercadoValDGV;
		private DataGridView MercadoDesDGV;
		private MaterialSkin.Controls.MaterialButton CopyIBOVButton;
		private MaterialSkin.Controls.MaterialTextBox GAPTB;
		private MaterialSkin.Controls.MaterialSwitch TopSwitch;
	}
}