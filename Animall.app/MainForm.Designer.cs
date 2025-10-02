namespace Animall.app
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControlPrincipal = new System.Windows.Forms.TabControl();
            this.tabPageVenta = new System.Windows.Forms.TabPage();
            this.lblMetodoPagoActual = new System.Windows.Forms.Label();
            this.panelClockVenta = new System.Windows.Forms.Panel();
            this.lblClockVenta = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBoxDetalle = new System.Windows.Forms.GroupBox();
            this.lstItemsVenta = new System.Windows.Forms.ListBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.numImporte = new System.Windows.Forms.NumericUpDown();
            this.lblImporte = new System.Windows.Forms.Label();
            this.cmbCategorias = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.tabPageSalida = new System.Windows.Forms.TabPage();
            this.groupBoxSalida = new System.Windows.Forms.GroupBox();
            this.lblTipoSalida = new System.Windows.Forms.Label();
            this.cmbTipoSalida = new System.Windows.Forms.ComboBox();
            this.lblMotivoSalida = new System.Windows.Forms.Label();
            this.btnRegistrarSalida = new System.Windows.Forms.Button();
            this.cmbMotivoSalida = new System.Windows.Forms.ComboBox();
            this.numMontoSalida = new System.Windows.Forms.NumericUpDown();
            this.lblMontoSalida = new System.Windows.Forms.Label();
            this.lblDetalleSalida = new System.Windows.Forms.Label();
            this.txtOtroMotivo = new System.Windows.Forms.TextBox();
            this.cmbDetalleSalida = new System.Windows.Forms.ComboBox();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.panelClockSalida = new System.Windows.Forms.Panel();
            this.lblClockSalida = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabPageReporte = new System.Windows.Forms.TabPage();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            this.btnDescargarReporte = new System.Windows.Forms.Button();
            this.panelClockReporte = new System.Windows.Forms.Panel();
            this.lblClockReporte = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTotalDelDia = new System.Windows.Forms.Label();
            this.groupBoxReporte = new System.Windows.Forms.GroupBox();
            this.lstVentasDelDia = new System.Windows.Forms.ListBox();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.tabControlPrincipal.SuspendLayout();
            this.tabPageVenta.SuspendLayout();
            this.panelClockVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImporte)).BeginInit();
            this.tabPageSalida.SuspendLayout();
            this.groupBoxSalida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMontoSalida)).BeginInit();
            this.panelClockSalida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabPageReporte.SuspendLayout();
            this.panelClockReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBoxReporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPrincipal
            // 
            this.tabControlPrincipal.Controls.Add(this.tabPageVenta);
            this.tabControlPrincipal.Controls.Add(this.tabPageSalida);
            this.tabControlPrincipal.Controls.Add(this.tabPageReporte);
            this.tabControlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPrincipal.ImageList = this.imageListIcons;
            this.tabControlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabControlPrincipal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControlPrincipal.Name = "tabControlPrincipal";
            this.tabControlPrincipal.SelectedIndex = 0;
            this.tabControlPrincipal.Size = new System.Drawing.Size(1445, 961);
            this.tabControlPrincipal.TabIndex = 0;
            // 
            // tabPageVenta
            // 
            this.tabPageVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(224)))), ((int)(((byte)(133)))));
            this.tabPageVenta.Controls.Add(this.lblMetodoPagoActual);
            this.tabPageVenta.Controls.Add(this.panelClockVenta);
            this.tabPageVenta.Controls.Add(this.pictureBox1);
            this.tabPageVenta.Controls.Add(this.btnFinalizar);
            this.tabPageVenta.Controls.Add(this.lblTotal);
            this.tabPageVenta.Controls.Add(this.groupBoxDetalle);
            this.tabPageVenta.Controls.Add(this.btnAgregar);
            this.tabPageVenta.Controls.Add(this.numImporte);
            this.tabPageVenta.Controls.Add(this.lblImporte);
            this.tabPageVenta.Controls.Add(this.cmbCategorias);
            this.tabPageVenta.Controls.Add(this.lblCategoria);
            this.tabPageVenta.ImageKey = "cart.png";
            this.tabPageVenta.Location = new System.Drawing.Point(4, 29);
            this.tabPageVenta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageVenta.Name = "tabPageVenta";
            this.tabPageVenta.Padding = new System.Windows.Forms.Padding(11, 13, 11, 13);
            this.tabPageVenta.Size = new System.Drawing.Size(1437, 928);
            this.tabPageVenta.TabIndex = 0;
            this.tabPageVenta.Text = "Nueva Venta";
            // 
            // lblMetodoPagoActual
            // 
            this.lblMetodoPagoActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMetodoPagoActual.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMetodoPagoActual.Location = new System.Drawing.Point(925, 870);
            this.lblMetodoPagoActual.Name = "lblMetodoPagoActual";
            this.lblMetodoPagoActual.Size = new System.Drawing.Size(263, 23);
            this.lblMetodoPagoActual.TabIndex = 22;
            this.lblMetodoPagoActual.Text = "Método de Pago: Efectivo";
            this.lblMetodoPagoActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelClockVenta
            // 
            this.panelClockVenta.BackColor = System.Drawing.Color.Black;
            this.panelClockVenta.Controls.Add(this.lblClockVenta);
            this.panelClockVenta.Location = new System.Drawing.Point(816, 40);
            this.panelClockVenta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelClockVenta.Name = "panelClockVenta";
            this.panelClockVenta.Size = new System.Drawing.Size(171, 53);
            this.panelClockVenta.TabIndex = 21;
            // 
            // lblClockVenta
            // 
            this.lblClockVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClockVenta.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold);
            this.lblClockVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(226)))), ((int)(((byte)(5)))));
            this.lblClockVenta.Location = new System.Drawing.Point(0, 0);
            this.lblClockVenta.Name = "lblClockVenta";
            this.lblClockVenta.Size = new System.Drawing.Size(171, 53);
            this.lblClockVenta.TabIndex = 20;
            this.lblClockVenta.Text = "00:00:00";
            this.lblClockVenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1081, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(339, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(174)))), ((int)(((byte)(212)))));
            this.btnFinalizar.FlatAppearance.BorderSize = 0;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFinalizar.ForeColor = System.Drawing.Color.Black;
            this.btnFinalizar.ImageKey = "check.png";
            this.btnFinalizar.ImageList = this.imageListIcons;
            this.btnFinalizar.Location = new System.Drawing.Point(1195, 845);
            this.btnFinalizar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnFinalizar.Size = new System.Drawing.Size(225, 53);
            this.btnFinalizar.TabIndex = 4;
            this.btnFinalizar.Text = " Finalizar Venta (F5)";
            this.btnFinalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // imageListIcons
            // 
            this.imageListIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcons.ImageStream")));
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIcons.Images.SetKeyName(0, "report.png");
            this.imageListIcons.Images.SetKeyName(1, "money.png");
            this.imageListIcons.Images.SetKeyName(2, "cart.png");
            this.imageListIcons.Images.SetKeyName(3, "cash.png");
            this.imageListIcons.Images.SetKeyName(4, "download.png");
            this.imageListIcons.Images.SetKeyName(5, "check.png");
            this.imageListIcons.Images.SetKeyName(6, "add.png");
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(15, 856);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(536, 49);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "TOTAL: $0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxDetalle
            // 
            this.groupBoxDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDetalle.Controls.Add(this.lstItemsVenta);
            this.groupBoxDetalle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxDetalle.ForeColor = System.Drawing.Color.Black;
            this.groupBoxDetalle.Location = new System.Drawing.Point(15, 124);
            this.groupBoxDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxDetalle.Name = "groupBoxDetalle";
            this.groupBoxDetalle.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxDetalle.Size = new System.Drawing.Size(1406, 704);
            this.groupBoxDetalle.TabIndex = 14;
            this.groupBoxDetalle.TabStop = false;
            this.groupBoxDetalle.Text = "Detalle de Venta (Seleccione un ítem y presione SUPR para eliminar)";
            // 
            // lstItemsVenta
            // 
            this.lstItemsVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstItemsVenta.Font = new System.Drawing.Font("Consolas", 12F);
            this.lstItemsVenta.FormattingEnabled = true;
            this.lstItemsVenta.ItemHeight = 23;
            this.lstItemsVenta.Location = new System.Drawing.Point(3, 24);
            this.lstItemsVenta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstItemsVenta.Name = "lstItemsVenta";
            this.lstItemsVenta.Size = new System.Drawing.Size(1400, 676);
            this.lstItemsVenta.TabIndex = 5;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(174)))), ((int)(((byte)(212)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.ImageKey = "add.png";
            this.btnAgregar.ImageList = this.imageListIcons;
            this.btnAgregar.Location = new System.Drawing.Point(622, 49);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnAgregar.Size = new System.Drawing.Size(143, 32);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = " Agregar Ítem";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // numImporte
            // 
            this.numImporte.DecimalPlaces = 2;
            this.numImporte.Location = new System.Drawing.Point(462, 51);
            this.numImporte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numImporte.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numImporte.Name = "numImporte";
            this.numImporte.Size = new System.Drawing.Size(137, 27);
            this.numImporte.TabIndex = 1;
            this.numImporte.Enter += new System.EventHandler(this.numImporte_Enter);
            this.numImporte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numImporte_KeyDown);
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblImporte.ForeColor = System.Drawing.Color.Black;
            this.lblImporte.Location = new System.Drawing.Point(462, 25);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(70, 20);
            this.lblImporte.TabIndex = 11;
            this.lblImporte.Text = "Importe:";
            // 
            // cmbCategorias
            // 
            this.cmbCategorias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategorias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategorias.FormattingEnabled = true;
            this.cmbCategorias.Location = new System.Drawing.Point(15, 49);
            this.cmbCategorias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCategorias.Name = "cmbCategorias";
            this.cmbCategorias.Size = new System.Drawing.Size(423, 28);
            this.cmbCategorias.TabIndex = 0;
            this.cmbCategorias.SelectedIndexChanged += new System.EventHandler(this.cmbCategorias_SelectedIndexChanged);
            this.cmbCategorias.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCategorias_Validating);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategoria.ForeColor = System.Drawing.Color.Black;
            this.lblCategoria.Location = new System.Drawing.Point(15, 25);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(80, 20);
            this.lblCategoria.TabIndex = 9;
            this.lblCategoria.Text = "Categoría:";
            // 
            // tabPageSalida
            // 
            this.tabPageSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(224)))), ((int)(((byte)(133)))));
            this.tabPageSalida.Controls.Add(this.groupBoxSalida);
            this.tabPageSalida.Controls.Add(this.panelClockSalida);
            this.tabPageSalida.Controls.Add(this.pictureBox3);
            this.tabPageSalida.ImageKey = "money.png";
            this.tabPageSalida.Location = new System.Drawing.Point(4, 29);
            this.tabPageSalida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageSalida.Name = "tabPageSalida";
            this.tabPageSalida.Padding = new System.Windows.Forms.Padding(11, 13, 11, 13);
            this.tabPageSalida.Size = new System.Drawing.Size(1437, 928);
            this.tabPageSalida.TabIndex = 2;
            this.tabPageSalida.Text = "Registrar Salida";
            // 
            // groupBoxSalida
            // 
            this.groupBoxSalida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBoxSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.groupBoxSalida.Controls.Add(this.lblTipoSalida);
            this.groupBoxSalida.Controls.Add(this.cmbTipoSalida);
            this.groupBoxSalida.Controls.Add(this.lblMotivoSalida);
            this.groupBoxSalida.Controls.Add(this.btnRegistrarSalida);
            this.groupBoxSalida.Controls.Add(this.cmbMotivoSalida);
            this.groupBoxSalida.Controls.Add(this.numMontoSalida);
            this.groupBoxSalida.Controls.Add(this.lblMontoSalida);
            this.groupBoxSalida.Controls.Add(this.lblDetalleSalida);
            this.groupBoxSalida.Controls.Add(this.txtOtroMotivo);
            this.groupBoxSalida.Controls.Add(this.cmbDetalleSalida);
            this.groupBoxSalida.Controls.Add(this.txtProveedor);
            this.groupBoxSalida.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxSalida.Location = new System.Drawing.Point(432, 196);
            this.groupBoxSalida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxSalida.Name = "groupBoxSalida";
            this.groupBoxSalida.Padding = new System.Windows.Forms.Padding(11, 13, 11, 13);
            this.groupBoxSalida.Size = new System.Drawing.Size(571, 533);
            this.groupBoxSalida.TabIndex = 29;
            this.groupBoxSalida.TabStop = false;
            this.groupBoxSalida.Text = "Registrar Salida de Dinero";
            // 
            // lblTipoSalida
            // 
            this.lblTipoSalida.AutoSize = true;
            this.lblTipoSalida.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoSalida.ForeColor = System.Drawing.Color.Black;
            this.lblTipoSalida.Location = new System.Drawing.Point(46, 267);
            this.lblTipoSalida.Name = "lblTipoSalida";
            this.lblTipoSalida.Size = new System.Drawing.Size(110, 20);
            this.lblTipoSalida.TabIndex = 10;
            this.lblTipoSalida.Text = "Tipo de Salida:";
            // 
            // cmbTipoSalida
            // 
            this.cmbTipoSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoSalida.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipoSalida.FormattingEnabled = true;
            this.cmbTipoSalida.Location = new System.Drawing.Point(46, 293);
            this.cmbTipoSalida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoSalida.Name = "cmbTipoSalida";
            this.cmbTipoSalida.Size = new System.Drawing.Size(220, 28);
            this.cmbTipoSalida.TabIndex = 2;
            // 
            // lblMotivoSalida
            // 
            this.lblMotivoSalida.AutoSize = true;
            this.lblMotivoSalida.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMotivoSalida.ForeColor = System.Drawing.Color.Black;
            this.lblMotivoSalida.Location = new System.Drawing.Point(46, 67);
            this.lblMotivoSalida.Name = "lblMotivoSalida";
            this.lblMotivoSalida.Size = new System.Drawing.Size(63, 20);
            this.lblMotivoSalida.TabIndex = 1;
            this.lblMotivoSalida.Text = "Motivo:";
            // 
            // btnRegistrarSalida
            // 
            this.btnRegistrarSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(174)))), ((int)(((byte)(212)))));
            this.btnRegistrarSalida.FlatAppearance.BorderSize = 0;
            this.btnRegistrarSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarSalida.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarSalida.ForeColor = System.Drawing.Color.Black;
            this.btnRegistrarSalida.ImageKey = "add.png";
            this.btnRegistrarSalida.ImageList = this.imageListIcons;
            this.btnRegistrarSalida.Location = new System.Drawing.Point(174, 400);
            this.btnRegistrarSalida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRegistrarSalida.Name = "btnRegistrarSalida";
            this.btnRegistrarSalida.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnRegistrarSalida.Size = new System.Drawing.Size(225, 53);
            this.btnRegistrarSalida.TabIndex = 4;
            this.btnRegistrarSalida.Text = " Registrar Salida";
            this.btnRegistrarSalida.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegistrarSalida.UseVisualStyleBackColor = false;
            this.btnRegistrarSalida.Click += new System.EventHandler(this.btnRegistrarSalida_Click);
            // 
            // cmbMotivoSalida
            // 
            this.cmbMotivoSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMotivoSalida.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbMotivoSalida.FormattingEnabled = true;
            this.cmbMotivoSalida.Location = new System.Drawing.Point(46, 93);
            this.cmbMotivoSalida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMotivoSalida.Name = "cmbMotivoSalida";
            this.cmbMotivoSalida.Size = new System.Drawing.Size(479, 28);
            this.cmbMotivoSalida.TabIndex = 0;
            // 
            // numMontoSalida
            // 
            this.numMontoSalida.DecimalPlaces = 2;
            this.numMontoSalida.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numMontoSalida.Location = new System.Drawing.Point(305, 293);
            this.numMontoSalida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numMontoSalida.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMontoSalida.Name = "numMontoSalida";
            this.numMontoSalida.Size = new System.Drawing.Size(221, 27);
            this.numMontoSalida.TabIndex = 3;
            this.numMontoSalida.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numMontoSalida_KeyDown);
            // 
            // lblMontoSalida
            // 
            this.lblMontoSalida.AutoSize = true;
            this.lblMontoSalida.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMontoSalida.ForeColor = System.Drawing.Color.Black;
            this.lblMontoSalida.Location = new System.Drawing.Point(305, 267);
            this.lblMontoSalida.Name = "lblMontoSalida";
            this.lblMontoSalida.Size = new System.Drawing.Size(60, 20);
            this.lblMontoSalida.TabIndex = 7;
            this.lblMontoSalida.Text = "Monto:";
            // 
            // lblDetalleSalida
            // 
            this.lblDetalleSalida.AutoSize = true;
            this.lblDetalleSalida.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDetalleSalida.ForeColor = System.Drawing.Color.Black;
            this.lblDetalleSalida.Location = new System.Drawing.Point(46, 167);
            this.lblDetalleSalida.Name = "lblDetalleSalida";
            this.lblDetalleSalida.Size = new System.Drawing.Size(62, 20);
            this.lblDetalleSalida.TabIndex = 3;
            this.lblDetalleSalida.Text = "Detalle:";
            // 
            // txtOtroMotivo
            // 
            this.txtOtroMotivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOtroMotivo.Location = new System.Drawing.Point(46, 193);
            this.txtOtroMotivo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOtroMotivo.Name = "txtOtroMotivo";
            this.txtOtroMotivo.Size = new System.Drawing.Size(479, 27);
            this.txtOtroMotivo.TabIndex = 1;
            // 
            // cmbDetalleSalida
            // 
            this.cmbDetalleSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDetalleSalida.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbDetalleSalida.FormattingEnabled = true;
            this.cmbDetalleSalida.Location = new System.Drawing.Point(46, 193);
            this.cmbDetalleSalida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDetalleSalida.Name = "cmbDetalleSalida";
            this.cmbDetalleSalida.Size = new System.Drawing.Size(479, 28);
            this.cmbDetalleSalida.TabIndex = 1;
            // 
            // txtProveedor
            // 
            this.txtProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProveedor.Location = new System.Drawing.Point(46, 193);
            this.txtProveedor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(479, 27);
            this.txtProveedor.TabIndex = 1;
            // 
            // panelClockSalida
            // 
            this.panelClockSalida.BackColor = System.Drawing.Color.Black;
            this.panelClockSalida.Controls.Add(this.lblClockSalida);
            this.panelClockSalida.Location = new System.Drawing.Point(15, 40);
            this.panelClockSalida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelClockSalida.Name = "panelClockSalida";
            this.panelClockSalida.Size = new System.Drawing.Size(171, 53);
            this.panelClockSalida.TabIndex = 28;
            // 
            // lblClockSalida
            // 
            this.lblClockSalida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClockSalida.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold);
            this.lblClockSalida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(226)))), ((int)(((byte)(5)))));
            this.lblClockSalida.Location = new System.Drawing.Point(0, 0);
            this.lblClockSalida.Name = "lblClockSalida";
            this.lblClockSalida.Size = new System.Drawing.Size(171, 53);
            this.lblClockSalida.TabIndex = 21;
            this.lblClockSalida.Text = "00:00:00";
            this.lblClockSalida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1081, 17);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(339, 99);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 27;
            this.pictureBox3.TabStop = false;
            // 
            // tabPageReporte
            // 
            this.tabPageReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(224)))), ((int)(((byte)(133)))));
            this.tabPageReporte.Controls.Add(this.btnCerrarCaja);
            this.tabPageReporte.Controls.Add(this.btnDescargarReporte);
            this.tabPageReporte.Controls.Add(this.panelClockReporte);
            this.tabPageReporte.Controls.Add(this.pictureBox2);
            this.tabPageReporte.Controls.Add(this.lblTotalDelDia);
            this.tabPageReporte.Controls.Add(this.groupBoxReporte);
            this.tabPageReporte.ImageKey = "report.png";
            this.tabPageReporte.Location = new System.Drawing.Point(4, 29);
            this.tabPageReporte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageReporte.Name = "tabPageReporte";
            this.tabPageReporte.Padding = new System.Windows.Forms.Padding(11, 13, 11, 13);
            this.tabPageReporte.Size = new System.Drawing.Size(1437, 928);
            this.tabPageReporte.TabIndex = 1;
            this.tabPageReporte.Text = "Reporte del Día";
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCerrarCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCerrarCaja.FlatAppearance.BorderSize = 0;
            this.btnCerrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarCaja.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrarCaja.ForeColor = System.Drawing.Color.Black;
            this.btnCerrarCaja.ImageKey = "cash.png";
            this.btnCerrarCaja.ImageList = this.imageListIcons;
            this.btnCerrarCaja.Location = new System.Drawing.Point(15, 856);
            this.btnCerrarCaja.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnCerrarCaja.Size = new System.Drawing.Size(171, 53);
            this.btnCerrarCaja.TabIndex = 0;
            this.btnCerrarCaja.Text = " Cerrar Caja";
            this.btnCerrarCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarCaja.UseVisualStyleBackColor = false;
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
            // 
            // btnDescargarReporte
            // 
            this.btnDescargarReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDescargarReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(174)))), ((int)(((byte)(212)))));
            this.btnDescargarReporte.FlatAppearance.BorderSize = 0;
            this.btnDescargarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargarReporte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDescargarReporte.ForeColor = System.Drawing.Color.Black;
            this.btnDescargarReporte.ImageKey = "download.png";
            this.btnDescargarReporte.ImageList = this.imageListIcons;
            this.btnDescargarReporte.Location = new System.Drawing.Point(193, 856);
            this.btnDescargarReporte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDescargarReporte.Name = "btnDescargarReporte";
            this.btnDescargarReporte.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnDescargarReporte.Size = new System.Drawing.Size(206, 53);
            this.btnDescargarReporte.TabIndex = 1;
            this.btnDescargarReporte.Text = " Descargar Reporte";
            this.btnDescargarReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDescargarReporte.UseVisualStyleBackColor = false;
            this.btnDescargarReporte.Click += new System.EventHandler(this.btnDescargarReporte_Click);
            // 
            // panelClockReporte
            // 
            this.panelClockReporte.BackColor = System.Drawing.Color.Black;
            this.panelClockReporte.Controls.Add(this.lblClockReporte);
            this.panelClockReporte.Location = new System.Drawing.Point(15, 40);
            this.panelClockReporte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelClockReporte.Name = "panelClockReporte";
            this.panelClockReporte.Size = new System.Drawing.Size(171, 53);
            this.panelClockReporte.TabIndex = 22;
            // 
            // lblClockReporte
            // 
            this.lblClockReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClockReporte.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold);
            this.lblClockReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(226)))), ((int)(((byte)(5)))));
            this.lblClockReporte.Location = new System.Drawing.Point(0, 0);
            this.lblClockReporte.Name = "lblClockReporte";
            this.lblClockReporte.Size = new System.Drawing.Size(171, 53);
            this.lblClockReporte.TabIndex = 21;
            this.lblClockReporte.Text = "00:00:00";
            this.lblClockReporte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1081, 17);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(339, 99);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // lblTotalDelDia
            // 
            this.lblTotalDelDia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDelDia.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalDelDia.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDelDia.Location = new System.Drawing.Point(15, 873);
            this.lblTotalDelDia.Name = "lblTotalDelDia";
            this.lblTotalDelDia.Size = new System.Drawing.Size(1406, 33);
            this.lblTotalDelDia.TabIndex = 2;
            this.lblTotalDelDia.Text = "TOTAL VENTAS: $0.00";
            this.lblTotalDelDia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxReporte
            // 
            this.groupBoxReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxReporte.Controls.Add(this.lstVentasDelDia);
            this.groupBoxReporte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxReporte.ForeColor = System.Drawing.Color.Black;
            this.groupBoxReporte.Location = new System.Drawing.Point(15, 124);
            this.groupBoxReporte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxReporte.Name = "groupBoxReporte";
            this.groupBoxReporte.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxReporte.Size = new System.Drawing.Size(1406, 704);
            this.groupBoxReporte.TabIndex = 21;
            this.groupBoxReporte.TabStop = false;
            this.groupBoxReporte.Text = "Movimientos del Día (Doble clic para ver ticket)";
            // 
            // lstVentasDelDia
            // 
            this.lstVentasDelDia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVentasDelDia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstVentasDelDia.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lstVentasDelDia.FormattingEnabled = true;
            this.lstVentasDelDia.ItemHeight = 15;
            this.lstVentasDelDia.Location = new System.Drawing.Point(3, 24);
            this.lstVentasDelDia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstVentasDelDia.Name = "lstVentasDelDia";
            this.lstVentasDelDia.Size = new System.Drawing.Size(1400, 676);
            this.lstVentasDelDia.TabIndex = 2;
            this.lstVentasDelDia.DoubleClick += new System.EventHandler(this.lstVentasDelDia_DoubleClick);
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 961);
            this.Controls.Add(this.tabControlPrincipal);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(912, 784);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Punto de Venta - AnimallForrajería";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.tabControlPrincipal.ResumeLayout(false);
            this.tabPageVenta.ResumeLayout(false);
            this.tabPageVenta.PerformLayout();
            this.panelClockVenta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numImporte)).EndInit();
            this.tabPageSalida.ResumeLayout(false);
            this.groupBoxSalida.ResumeLayout(false);
            this.groupBoxSalida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMontoSalida)).EndInit();
            this.panelClockSalida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabPageReporte.ResumeLayout(false);
            this.panelClockReporte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBoxReporte.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPrincipal;
        private System.Windows.Forms.TabPage tabPageVenta;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox groupBoxDetalle;
        private System.Windows.Forms.ListBox lstItemsVenta;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.NumericUpDown numImporte;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.ComboBox cmbCategorias;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TabPage tabPageReporte;
        private System.Windows.Forms.Label lblTotalDelDia;
        private System.Windows.Forms.ListBox lstVentasDelDia;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBoxReporte;
        private System.Windows.Forms.Label lblClockVenta;
        private System.Windows.Forms.Label lblClockReporte;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Panel panelClockVenta;
        private System.Windows.Forms.Panel panelClockReporte;
        private System.Windows.Forms.Button btnDescargarReporte;
        private System.Windows.Forms.TabPage tabPageSalida;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panelClockSalida;
        private System.Windows.Forms.Label lblClockSalida;
        private System.Windows.Forms.ImageList imageListIcons;
        private System.Windows.Forms.Button btnCerrarCaja;
        private System.Windows.Forms.GroupBox groupBoxSalida;
        private System.Windows.Forms.Label lblMotivoSalida;
        private System.Windows.Forms.Button btnRegistrarSalida;
        private System.Windows.Forms.ComboBox cmbMotivoSalida;
        private System.Windows.Forms.NumericUpDown numMontoSalida;
        private System.Windows.Forms.Label lblMontoSalida;
        private System.Windows.Forms.Label lblDetalleSalida;
        private System.Windows.Forms.TextBox txtOtroMotivo;
        private System.Windows.Forms.ComboBox cmbDetalleSalida;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label lblTipoSalida;
        private System.Windows.Forms.ComboBox cmbTipoSalida;
        private System.Windows.Forms.Label lblMetodoPagoActual;
    }
}
