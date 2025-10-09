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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControlPrincipal = new TabControl();
            tabPageVenta = new TabPage();
            lblMetodoPagoActual = new Label();
            panelClockVenta = new Panel();
            lblClockVenta = new Label();
            pictureBox1 = new PictureBox();
            btnFinalizar = new Button();
            imageListIcons = new ImageList(components);
            lblTotal = new Label();
            groupBoxDetalle = new GroupBox();
            lstItemsVenta = new ListBox();
            btnAgregar = new Button();
            numImporte = new NumericUpDown();
            lblImporte = new Label();
            cmbCategorias = new ComboBox();
            lblCategoria = new Label();
            tabPageSalida = new TabPage();
            groupBoxSalida = new GroupBox();
            lblTipoSalida = new Label();
            cmbTipoSalida = new ComboBox();
            lblMotivoSalida = new Label();
            btnRegistrarSalida = new Button();
            cmbMotivoSalida = new ComboBox();
            numMontoSalida = new NumericUpDown();
            lblMontoSalida = new Label();
            lblDetalleSalida = new Label();
            txtOtroMotivo = new TextBox();
            cmbDetalleSalida = new ComboBox();
            txtProveedor = new TextBox();
            panelClockSalida = new Panel();
            lblClockSalida = new Label();
            pictureBox3 = new PictureBox();
            tabPageReporte = new TabPage();
            btnCerrarCaja = new Button();
            btnDescargarReporte = new Button();
            panelClockReporte = new Panel();
            lblClockReporte = new Label();
            pictureBox2 = new PictureBox();
            lblTotalDelDia = new Label();
            groupBoxReporte = new GroupBox();
            lstVentasDelDia = new ListBox();
            timerClock = new System.Windows.Forms.Timer(components);
            tabControlPrincipal.SuspendLayout();
            tabPageVenta.SuspendLayout();
            panelClockVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBoxDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numImporte).BeginInit();
            tabPageSalida.SuspendLayout();
            groupBoxSalida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMontoSalida).BeginInit();
            panelClockSalida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            tabPageReporte.SuspendLayout();
            panelClockReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBoxReporte.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlPrincipal
            // 
            tabControlPrincipal.Controls.Add(tabPageVenta);
            tabControlPrincipal.Controls.Add(tabPageSalida);
            tabControlPrincipal.Controls.Add(tabPageReporte);
            tabControlPrincipal.Dock = DockStyle.Fill;
            tabControlPrincipal.ImageList = imageListIcons;
            tabControlPrincipal.Location = new Point(0, 0);
            tabControlPrincipal.Margin = new Padding(3, 4, 3, 4);
            tabControlPrincipal.Name = "tabControlPrincipal";
            tabControlPrincipal.SelectedIndex = 0;
            tabControlPrincipal.Size = new Size(1445, 961);
            tabControlPrincipal.TabIndex = 0;
            // 
            // tabPageVenta
            // 
            tabPageVenta.BackColor = Color.FromArgb(242, 224, 133);
            tabPageVenta.Controls.Add(lblMetodoPagoActual);
            tabPageVenta.Controls.Add(panelClockVenta);
            tabPageVenta.Controls.Add(pictureBox1);
            tabPageVenta.Controls.Add(btnFinalizar);
            tabPageVenta.Controls.Add(lblTotal);
            tabPageVenta.Controls.Add(groupBoxDetalle);
            tabPageVenta.Controls.Add(btnAgregar);
            tabPageVenta.Controls.Add(numImporte);
            tabPageVenta.Controls.Add(lblImporte);
            tabPageVenta.Controls.Add(cmbCategorias);
            tabPageVenta.Controls.Add(lblCategoria);
            tabPageVenta.ImageKey = "cart.png";
            tabPageVenta.Location = new Point(4, 29);
            tabPageVenta.Margin = new Padding(3, 4, 3, 4);
            tabPageVenta.Name = "tabPageVenta";
            tabPageVenta.Padding = new Padding(11, 13, 11, 13);
            tabPageVenta.Size = new Size(1437, 928);
            tabPageVenta.TabIndex = 0;
            tabPageVenta.Text = "Nueva Venta";
            // 
            // lblMetodoPagoActual
            // 
            lblMetodoPagoActual.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblMetodoPagoActual.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMetodoPagoActual.Location = new Point(780, 874);
            lblMetodoPagoActual.Name = "lblMetodoPagoActual";
            lblMetodoPagoActual.Size = new Size(360, 23);
            lblMetodoPagoActual.TabIndex = 22;
            lblMetodoPagoActual.Text = "Método de Pago: Efectivo (CTRL)";
            lblMetodoPagoActual.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelClockVenta
            // 
            panelClockVenta.BackColor = Color.Black;
            panelClockVenta.Controls.Add(lblClockVenta);
            panelClockVenta.Location = new Point(816, 40);
            panelClockVenta.Margin = new Padding(3, 4, 3, 4);
            panelClockVenta.Name = "panelClockVenta";
            panelClockVenta.Size = new Size(171, 53);
            panelClockVenta.TabIndex = 21;
            // 
            // lblClockVenta
            // 
            lblClockVenta.Dock = DockStyle.Fill;
            lblClockVenta.Font = new Font("Consolas", 20F, FontStyle.Bold);
            lblClockVenta.ForeColor = Color.FromArgb(242, 226, 5);
            lblClockVenta.Location = new Point(0, 0);
            lblClockVenta.Name = "lblClockVenta";
            lblClockVenta.Size = new Size(171, 53);
            lblClockVenta.TabIndex = 20;
            lblClockVenta.Text = "00:00:00";
            lblClockVenta.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1081, 17);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(339, 99);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // btnFinalizar
            // 
            btnFinalizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFinalizar.BackColor = Color.FromArgb(242, 174, 212);
            btnFinalizar.FlatAppearance.BorderSize = 0;
            btnFinalizar.FlatStyle = FlatStyle.Flat;
            btnFinalizar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnFinalizar.ForeColor = Color.Black;
            btnFinalizar.ImageKey = "check.png";
            btnFinalizar.ImageList = imageListIcons;
            btnFinalizar.Location = new Point(1145, 849);
            btnFinalizar.Margin = new Padding(3, 4, 3, 4);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(275, 53);
            btnFinalizar.TabIndex = 4;
            btnFinalizar.Text = "Finalizar Venta (ALT)";
            btnFinalizar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFinalizar.UseVisualStyleBackColor = false;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // imageListIcons
            // 
            imageListIcons.ColorDepth = ColorDepth.Depth32Bit;
            imageListIcons.ImageStream = (ImageListStreamer)resources.GetObject("imageListIcons.ImageStream");
            imageListIcons.TransparentColor = Color.Transparent;
            imageListIcons.Images.SetKeyName(0, "add.png");
            imageListIcons.Images.SetKeyName(1, "cart.png");
            imageListIcons.Images.SetKeyName(2, "check.png");
            imageListIcons.Images.SetKeyName(3, "download.png");
            imageListIcons.Images.SetKeyName(4, "report.png");
            imageListIcons.Images.SetKeyName(5, "money.png");
            imageListIcons.Images.SetKeyName(6, "cash.png");
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotal.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lblTotal.ForeColor = Color.Black;
            lblTotal.Location = new Point(15, 860);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(536, 49);
            lblTotal.TabIndex = 15;
            lblTotal.Text = "TOTAL: $0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBoxDetalle
            // 
            groupBoxDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxDetalle.Controls.Add(lstItemsVenta);
            groupBoxDetalle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxDetalle.ForeColor = Color.Black;
            groupBoxDetalle.Location = new Point(15, 124);
            groupBoxDetalle.Margin = new Padding(3, 4, 3, 4);
            groupBoxDetalle.Name = "groupBoxDetalle";
            groupBoxDetalle.Padding = new Padding(3, 4, 3, 4);
            groupBoxDetalle.Size = new Size(1406, 708);
            groupBoxDetalle.TabIndex = 14;
            groupBoxDetalle.TabStop = false;
            groupBoxDetalle.Text = "Detalle de Venta (Seleccione un ítem y presione SUPR para eliminar)";
            // 
            // lstItemsVenta
            // 
            lstItemsVenta.Dock = DockStyle.Fill;
            lstItemsVenta.Font = new Font("Consolas", 12F);
            lstItemsVenta.FormattingEnabled = true;
            lstItemsVenta.ItemHeight = 23;
            lstItemsVenta.Location = new Point(3, 24);
            lstItemsVenta.Margin = new Padding(3, 4, 3, 4);
            lstItemsVenta.Name = "lstItemsVenta";
            lstItemsVenta.Size = new Size(1400, 680);
            lstItemsVenta.TabIndex = 5;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(242, 174, 212);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.Black;
            btnAgregar.ImageKey = "add.png";
            btnAgregar.ImageList = imageListIcons;
            btnAgregar.Location = new Point(622, 49);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Padding = new Padding(6, 0, 0, 0);
            btnAgregar.Size = new Size(143, 32);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = " Agregar Ítem";
            btnAgregar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // numImporte
            // 
            numImporte.DecimalPlaces = 2;
            numImporte.Location = new Point(462, 51);
            numImporte.Margin = new Padding(3, 4, 3, 4);
            numImporte.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numImporte.Name = "numImporte";
            numImporte.Size = new Size(137, 27);
            numImporte.TabIndex = 1;
            numImporte.Enter += numImporte_Enter;
            numImporte.KeyDown += numImporte_KeyDown;
            // 
            // lblImporte
            // 
            lblImporte.AutoSize = true;
            lblImporte.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblImporte.ForeColor = Color.Black;
            lblImporte.Location = new Point(462, 25);
            lblImporte.Name = "lblImporte";
            lblImporte.Size = new Size(70, 20);
            lblImporte.TabIndex = 11;
            lblImporte.Text = "Importe:";
            // 
            // cmbCategorias
            // 
            cmbCategorias.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCategorias.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCategorias.FormattingEnabled = true;
            cmbCategorias.Location = new Point(15, 49);
            cmbCategorias.Margin = new Padding(3, 4, 3, 4);
            cmbCategorias.Name = "cmbCategorias";
            cmbCategorias.Size = new Size(423, 28);
            cmbCategorias.TabIndex = 0;
            cmbCategorias.SelectedIndexChanged += cmbCategorias_SelectedIndexChanged;
            cmbCategorias.KeyDown += cmbCategorias_KeyDown;
            cmbCategorias.Validating += cmbCategorias_Validating;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategoria.ForeColor = Color.Black;
            lblCategoria.Location = new Point(15, 25);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(80, 20);
            lblCategoria.TabIndex = 9;
            lblCategoria.Text = "Categoría:";
            // 
            // tabPageSalida
            // 
            tabPageSalida.BackColor = Color.FromArgb(242, 224, 133);
            tabPageSalida.Controls.Add(groupBoxSalida);
            tabPageSalida.Controls.Add(panelClockSalida);
            tabPageSalida.Controls.Add(pictureBox3);
            tabPageSalida.ImageKey = "money.png";
            tabPageSalida.Location = new Point(4, 29);
            tabPageSalida.Margin = new Padding(3, 4, 3, 4);
            tabPageSalida.Name = "tabPageSalida";
            tabPageSalida.Padding = new Padding(11, 13, 11, 13);
            tabPageSalida.Size = new Size(1437, 928);
            tabPageSalida.TabIndex = 2;
            tabPageSalida.Text = "Registrar Salida";
            // 
            // groupBoxSalida
            // 
            groupBoxSalida.Anchor = AnchorStyles.None;
            groupBoxSalida.BackColor = Color.FromArgb(255, 250, 240);
            groupBoxSalida.Controls.Add(lblTipoSalida);
            groupBoxSalida.Controls.Add(cmbTipoSalida);
            groupBoxSalida.Controls.Add(lblMotivoSalida);
            groupBoxSalida.Controls.Add(btnRegistrarSalida);
            groupBoxSalida.Controls.Add(cmbMotivoSalida);
            groupBoxSalida.Controls.Add(numMontoSalida);
            groupBoxSalida.Controls.Add(lblMontoSalida);
            groupBoxSalida.Controls.Add(lblDetalleSalida);
            groupBoxSalida.Controls.Add(txtOtroMotivo);
            groupBoxSalida.Controls.Add(cmbDetalleSalida);
            groupBoxSalida.Controls.Add(txtProveedor);
            groupBoxSalida.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            groupBoxSalida.Location = new Point(433, 197);
            groupBoxSalida.Margin = new Padding(3, 4, 3, 4);
            groupBoxSalida.Name = "groupBoxSalida";
            groupBoxSalida.Padding = new Padding(11, 13, 11, 13);
            groupBoxSalida.Size = new Size(571, 533);
            groupBoxSalida.TabIndex = 29;
            groupBoxSalida.TabStop = false;
            groupBoxSalida.Text = "Registrar Salida de Dinero";
            // 
            // lblTipoSalida
            // 
            lblTipoSalida.AutoSize = true;
            lblTipoSalida.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipoSalida.ForeColor = Color.Black;
            lblTipoSalida.Location = new Point(46, 267);
            lblTipoSalida.Name = "lblTipoSalida";
            lblTipoSalida.Size = new Size(110, 20);
            lblTipoSalida.TabIndex = 10;
            lblTipoSalida.Text = "Tipo de Salida:";
            // 
            // cmbTipoSalida
            // 
            cmbTipoSalida.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoSalida.Font = new Font("Segoe UI", 9F);
            cmbTipoSalida.FormattingEnabled = true;
            cmbTipoSalida.Location = new Point(46, 293);
            cmbTipoSalida.Margin = new Padding(3, 4, 3, 4);
            cmbTipoSalida.Name = "cmbTipoSalida";
            cmbTipoSalida.Size = new Size(220, 28);
            cmbTipoSalida.TabIndex = 2;
            // 
            // lblMotivoSalida
            // 
            lblMotivoSalida.AutoSize = true;
            lblMotivoSalida.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMotivoSalida.ForeColor = Color.Black;
            lblMotivoSalida.Location = new Point(46, 67);
            lblMotivoSalida.Name = "lblMotivoSalida";
            lblMotivoSalida.Size = new Size(63, 20);
            lblMotivoSalida.TabIndex = 1;
            lblMotivoSalida.Text = "Motivo:";
            // 
            // btnRegistrarSalida
            // 
            btnRegistrarSalida.BackColor = Color.FromArgb(242, 174, 212);
            btnRegistrarSalida.FlatAppearance.BorderSize = 0;
            btnRegistrarSalida.FlatStyle = FlatStyle.Flat;
            btnRegistrarSalida.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegistrarSalida.ForeColor = Color.Black;
            btnRegistrarSalida.ImageKey = "add.png";
            btnRegistrarSalida.ImageList = imageListIcons;
            btnRegistrarSalida.Location = new Point(174, 400);
            btnRegistrarSalida.Margin = new Padding(3, 4, 3, 4);
            btnRegistrarSalida.Name = "btnRegistrarSalida";
            btnRegistrarSalida.Padding = new Padding(11, 0, 0, 0);
            btnRegistrarSalida.Size = new Size(225, 53);
            btnRegistrarSalida.TabIndex = 4;
            btnRegistrarSalida.Text = " Registrar Salida";
            btnRegistrarSalida.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRegistrarSalida.UseVisualStyleBackColor = false;
            btnRegistrarSalida.Click += btnRegistrarSalida_Click;
            // 
            // cmbMotivoSalida
            // 
            cmbMotivoSalida.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMotivoSalida.Font = new Font("Segoe UI", 9F);
            cmbMotivoSalida.FormattingEnabled = true;
            cmbMotivoSalida.Location = new Point(46, 93);
            cmbMotivoSalida.Margin = new Padding(3, 4, 3, 4);
            cmbMotivoSalida.Name = "cmbMotivoSalida";
            cmbMotivoSalida.Size = new Size(479, 28);
            cmbMotivoSalida.TabIndex = 0;
            // 
            // numMontoSalida
            // 
            numMontoSalida.DecimalPlaces = 2;
            numMontoSalida.Font = new Font("Segoe UI", 9F);
            numMontoSalida.Location = new Point(305, 293);
            numMontoSalida.Margin = new Padding(3, 4, 3, 4);
            numMontoSalida.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numMontoSalida.Name = "numMontoSalida";
            numMontoSalida.Size = new Size(221, 27);
            numMontoSalida.TabIndex = 3;
            numMontoSalida.KeyDown += numMontoSalida_KeyDown;
            // 
            // lblMontoSalida
            // 
            lblMontoSalida.AutoSize = true;
            lblMontoSalida.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMontoSalida.ForeColor = Color.Black;
            lblMontoSalida.Location = new Point(305, 267);
            lblMontoSalida.Name = "lblMontoSalida";
            lblMontoSalida.Size = new Size(60, 20);
            lblMontoSalida.TabIndex = 7;
            lblMontoSalida.Text = "Monto:";
            // 
            // lblDetalleSalida
            // 
            lblDetalleSalida.AutoSize = true;
            lblDetalleSalida.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetalleSalida.ForeColor = Color.Black;
            lblDetalleSalida.Location = new Point(46, 167);
            lblDetalleSalida.Name = "lblDetalleSalida";
            lblDetalleSalida.Size = new Size(62, 20);
            lblDetalleSalida.TabIndex = 3;
            lblDetalleSalida.Text = "Detalle:";
            // 
            // txtOtroMotivo
            // 
            txtOtroMotivo.Font = new Font("Segoe UI", 9F);
            txtOtroMotivo.Location = new Point(46, 193);
            txtOtroMotivo.Margin = new Padding(3, 4, 3, 4);
            txtOtroMotivo.Name = "txtOtroMotivo";
            txtOtroMotivo.Size = new Size(479, 27);
            txtOtroMotivo.TabIndex = 1;
            // 
            // cmbDetalleSalida
            // 
            cmbDetalleSalida.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDetalleSalida.Font = new Font("Segoe UI", 9F);
            cmbDetalleSalida.FormattingEnabled = true;
            cmbDetalleSalida.Location = new Point(46, 193);
            cmbDetalleSalida.Margin = new Padding(3, 4, 3, 4);
            cmbDetalleSalida.Name = "cmbDetalleSalida";
            cmbDetalleSalida.Size = new Size(479, 28);
            cmbDetalleSalida.TabIndex = 1;
            // 
            // txtProveedor
            // 
            txtProveedor.Font = new Font("Segoe UI", 9F);
            txtProveedor.Location = new Point(46, 193);
            txtProveedor.Margin = new Padding(3, 4, 3, 4);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(479, 27);
            txtProveedor.TabIndex = 1;
            // 
            // panelClockSalida
            // 
            panelClockSalida.BackColor = Color.Black;
            panelClockSalida.Controls.Add(lblClockSalida);
            panelClockSalida.Location = new Point(15, 40);
            panelClockSalida.Margin = new Padding(3, 4, 3, 4);
            panelClockSalida.Name = "panelClockSalida";
            panelClockSalida.Size = new Size(171, 53);
            panelClockSalida.TabIndex = 28;
            // 
            // lblClockSalida
            // 
            lblClockSalida.Dock = DockStyle.Fill;
            lblClockSalida.Font = new Font("Consolas", 20F, FontStyle.Bold);
            lblClockSalida.ForeColor = Color.FromArgb(242, 226, 5);
            lblClockSalida.Location = new Point(0, 0);
            lblClockSalida.Name = "lblClockSalida";
            lblClockSalida.Size = new Size(171, 53);
            lblClockSalida.TabIndex = 21;
            lblClockSalida.Text = "00:00:00";
            lblClockSalida.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox3.Location = new Point(1081, 17);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(339, 99);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 27;
            pictureBox3.TabStop = false;
            // 
            // tabPageReporte
            // 
            tabPageReporte.BackColor = Color.FromArgb(242, 224, 133);
            tabPageReporte.Controls.Add(btnCerrarCaja);
            tabPageReporte.Controls.Add(btnDescargarReporte);
            tabPageReporte.Controls.Add(panelClockReporte);
            tabPageReporte.Controls.Add(pictureBox2);
            tabPageReporte.Controls.Add(lblTotalDelDia);
            tabPageReporte.Controls.Add(groupBoxReporte);
            tabPageReporte.ImageKey = "report.png";
            tabPageReporte.Location = new Point(4, 29);
            tabPageReporte.Margin = new Padding(3, 4, 3, 4);
            tabPageReporte.Name = "tabPageReporte";
            tabPageReporte.Padding = new Padding(11, 13, 11, 13);
            tabPageReporte.Size = new Size(1437, 928);
            tabPageReporte.TabIndex = 1;
            tabPageReporte.Text = "Reporte del Día";
            // 
            // btnCerrarCaja
            // 
            btnCerrarCaja.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCerrarCaja.BackColor = Color.FromArgb(255, 128, 128);
            btnCerrarCaja.FlatAppearance.BorderSize = 0;
            btnCerrarCaja.FlatStyle = FlatStyle.Flat;
            btnCerrarCaja.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCerrarCaja.ForeColor = Color.Black;
            btnCerrarCaja.ImageKey = "cash.png";
            btnCerrarCaja.ImageList = imageListIcons;
            btnCerrarCaja.Location = new Point(228, 860);
            btnCerrarCaja.Margin = new Padding(3, 4, 3, 4);
            btnCerrarCaja.Name = "btnCerrarCaja";
            btnCerrarCaja.Padding = new Padding(11, 0, 0, 0);
            btnCerrarCaja.Size = new Size(171, 53);
            btnCerrarCaja.TabIndex = 0;
            btnCerrarCaja.Text = " Cerrar Caja";
            btnCerrarCaja.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCerrarCaja.UseVisualStyleBackColor = false;
            btnCerrarCaja.Click += btnCerrarCaja_Click;
            // 
            // btnDescargarReporte
            // 
            btnDescargarReporte.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDescargarReporte.BackColor = Color.FromArgb(242, 174, 212);
            btnDescargarReporte.FlatAppearance.BorderSize = 0;
            btnDescargarReporte.FlatStyle = FlatStyle.Flat;
            btnDescargarReporte.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDescargarReporte.ForeColor = Color.Black;
            btnDescargarReporte.ImageKey = "download.png";
            btnDescargarReporte.ImageList = imageListIcons;
            btnDescargarReporte.Location = new Point(15, 860);
            btnDescargarReporte.Margin = new Padding(3, 4, 3, 4);
            btnDescargarReporte.Name = "btnDescargarReporte";
            btnDescargarReporte.Padding = new Padding(11, 0, 0, 0);
            btnDescargarReporte.Size = new Size(206, 53);
            btnDescargarReporte.TabIndex = 1;
            btnDescargarReporte.Text = " Descargar Reporte";
            btnDescargarReporte.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDescargarReporte.UseVisualStyleBackColor = false;
            btnDescargarReporte.Click += btnDescargarReporte_Click;
            // 
            // panelClockReporte
            // 
            panelClockReporte.BackColor = Color.Black;
            panelClockReporte.Controls.Add(lblClockReporte);
            panelClockReporte.Location = new Point(15, 40);
            panelClockReporte.Margin = new Padding(3, 4, 3, 4);
            panelClockReporte.Name = "panelClockReporte";
            panelClockReporte.Size = new Size(171, 53);
            panelClockReporte.TabIndex = 22;
            // 
            // lblClockReporte
            // 
            lblClockReporte.Dock = DockStyle.Fill;
            lblClockReporte.Font = new Font("Consolas", 20F, FontStyle.Bold);
            lblClockReporte.ForeColor = Color.FromArgb(242, 226, 5);
            lblClockReporte.Location = new Point(0, 0);
            lblClockReporte.Name = "lblClockReporte";
            lblClockReporte.Size = new Size(171, 53);
            lblClockReporte.TabIndex = 21;
            lblClockReporte.Text = "00:00:00";
            lblClockReporte.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1081, 17);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(339, 99);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
            // 
            // lblTotalDelDia
            // 
            lblTotalDelDia.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTotalDelDia.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblTotalDelDia.ForeColor = Color.Black;
            lblTotalDelDia.Location = new Point(405, 874);
            lblTotalDelDia.Name = "lblTotalDelDia";
            lblTotalDelDia.Size = new Size(1016, 33);
            lblTotalDelDia.TabIndex = 2;
            lblTotalDelDia.Text = "TOTAL VENTAS: $0.00";
            lblTotalDelDia.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBoxReporte
            // 
            groupBoxReporte.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxReporte.Controls.Add(lstVentasDelDia);
            groupBoxReporte.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxReporte.ForeColor = Color.Black;
            groupBoxReporte.Location = new Point(15, 124);
            groupBoxReporte.Margin = new Padding(3, 4, 3, 4);
            groupBoxReporte.Name = "groupBoxReporte";
            groupBoxReporte.Padding = new Padding(3, 4, 3, 4);
            groupBoxReporte.Size = new Size(1406, 728);
            groupBoxReporte.TabIndex = 21;
            groupBoxReporte.TabStop = false;
            groupBoxReporte.Text = "Movimientos del Día (Doble clic para ver ticket)";
            // 
            // lstVentasDelDia
            // 
            lstVentasDelDia.Dock = DockStyle.Fill;
            lstVentasDelDia.DrawMode = DrawMode.OwnerDrawFixed;
            lstVentasDelDia.Font = new Font("Consolas", 9.75F);
            lstVentasDelDia.FormattingEnabled = true;
            lstVentasDelDia.ItemHeight = 15;
            lstVentasDelDia.Location = new Point(3, 24);
            lstVentasDelDia.Margin = new Padding(3, 4, 3, 4);
            lstVentasDelDia.Name = "lstVentasDelDia";
            lstVentasDelDia.Size = new Size(1400, 700);
            lstVentasDelDia.TabIndex = 2;
            lstVentasDelDia.DoubleClick += lstVentasDelDia_DoubleClick;
            // 
            // timerClock
            // 
            timerClock.Enabled = true;
            timerClock.Interval = 1000;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1445, 961);
            Controls.Add(tabControlPrincipal);
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(912, 784);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Punto de Venta - AnimallForrajería";
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            tabControlPrincipal.ResumeLayout(false);
            tabPageVenta.ResumeLayout(false);
            tabPageVenta.PerformLayout();
            panelClockVenta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBoxDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numImporte).EndInit();
            tabPageSalida.ResumeLayout(false);
            groupBoxSalida.ResumeLayout(false);
            groupBoxSalida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMontoSalida).EndInit();
            panelClockSalida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            tabPageReporte.ResumeLayout(false);
            panelClockReporte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBoxReporte.ResumeLayout(false);
            ResumeLayout(false);

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

