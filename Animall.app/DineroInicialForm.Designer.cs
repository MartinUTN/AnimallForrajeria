namespace Animall.app
{
    partial class DineroInicialForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DineroInicialForm));
            numDineroInicial = new NumericUpDown();
            btnAceptar = new Button();
            imageListIcons = new ImageList(components);
            panelCentral = new Panel();
            lblInstruccion = new Label();
            ((System.ComponentModel.ISupportInitialize)numDineroInicial).BeginInit();
            panelCentral.SuspendLayout();
            SuspendLayout();
            // 
            // numDineroInicial
            // 
            numDineroInicial.DecimalPlaces = 2;
            numDineroInicial.Font = new Font("Segoe UI", 12F);
            numDineroInicial.Location = new Point(40, 58);
            numDineroInicial.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numDineroInicial.Name = "numDineroInicial";
            numDineroInicial.Size = new Size(240, 29);
            numDineroInicial.TabIndex = 1;
            numDineroInicial.TextAlign = HorizontalAlignment.Center;
            numDineroInicial.KeyDown += numDineroInicial_KeyDown;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(242, 174, 212);
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnAceptar.ForeColor = Color.Black;
            btnAceptar.ImageKey = "check.png";
            btnAceptar.ImageList = imageListIcons;
            btnAceptar.Location = new Point(100, 112);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Padding = new Padding(10, 0, 0, 0);
            btnAceptar.Size = new Size(120, 35);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = " Aceptar";
            btnAceptar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // imageListIcons
            // 
            imageListIcons.ColorDepth = ColorDepth.Depth32Bit;
            imageListIcons.ImageStream = (ImageListStreamer)resources.GetObject("imageListIcons.ImageStream");
            imageListIcons.TransparentColor = Color.Transparent;
            imageListIcons.Images.SetKeyName(0, "add.png");
            imageListIcons.Images.SetKeyName(1, "cart.png");
            imageListIcons.Images.SetKeyName(2, "cash.png");
            imageListIcons.Images.SetKeyName(3, "check.png");
            imageListIcons.Images.SetKeyName(4, "download.png");
            imageListIcons.Images.SetKeyName(5, "money.png");
            imageListIcons.Images.SetKeyName(6, "report.png");
            // 
            // panelCentral
            // 
            panelCentral.BackColor = Color.FromArgb(255, 250, 240);
            panelCentral.BorderStyle = BorderStyle.FixedSingle;
            panelCentral.Controls.Add(lblInstruccion);
            panelCentral.Controls.Add(btnAceptar);
            panelCentral.Controls.Add(numDineroInicial);
            panelCentral.Location = new Point(12, 12);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(320, 177);
            panelCentral.TabIndex = 3;
            // 
            // lblInstruccion
            // 
            lblInstruccion.AutoSize = true;
            lblInstruccion.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblInstruccion.Location = new Point(37, 29);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new Size(232, 17);
            lblInstruccion.TabIndex = 0;
            lblInstruccion.Text = "Ingrese el monto inicial para la caja:";
            // 
            // DineroInicialForm
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 224, 133);
            ClientSize = new Size(344, 201);
            Controls.Add(panelCentral);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DineroInicialForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de Jornada";
            Load += DineroInicialForm_Load;
            ((System.ComponentModel.ISupportInitialize)numDineroInicial).EndInit();
            panelCentral.ResumeLayout(false);
            panelCentral.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numDineroInicial;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.ImageList imageListIcons;
    }
}

