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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.numDineroInicial = new System.Windows.Forms.NumericUpDown();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.panelCentral = new System.Windows.Forms.Panel();
            this.lblInstruccion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDineroInicial)).BeginInit();
            this.panelCentral.SuspendLayout();
            this.SuspendLayout();
            // 
            // numDineroInicial
            // 
            this.numDineroInicial.DecimalPlaces = 2;
            this.numDineroInicial.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDineroInicial.Location = new System.Drawing.Point(40, 50);
            this.numDineroInicial.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numDineroInicial.Name = "numDineroInicial";
            this.numDineroInicial.Size = new System.Drawing.Size(220, 33);
            this.numDineroInicial.TabIndex = 0;
            this.numDineroInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numDineroInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numDineroInicial_KeyDown);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.ImageKey = "check.png";
            this.btnAceptar.ImageList = this.imageListIcons;
            this.btnAceptar.Location = new System.Drawing.Point(90, 100);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAceptar.Size = new System.Drawing.Size(120, 40);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
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
            // panelCentral
            // 
            this.panelCentral.Controls.Add(this.lblInstruccion);
            this.panelCentral.Controls.Add(this.numDineroInicial);
            this.panelCentral.Controls.Add(this.btnAceptar);
            this.panelCentral.Location = new System.Drawing.Point(22, 12);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(300, 177);
            this.panelCentral.TabIndex = 3;
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruccion.Location = new System.Drawing.Point(42, 20);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(216, 17);
            this.lblInstruccion.TabIndex = 2;
            this.lblInstruccion.Text = "Ingrese el dinero inicial en la caja";
            // 
            // DineroInicialForm
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(224)))), ((int)(((byte)(133)))));
            this.ClientSize = new System.Drawing.Size(344, 201);
            this.Controls.Add(this.panelCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DineroInicialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Jornada";
            this.Load += new System.EventHandler(this.DineroInicialForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDineroInicial)).EndInit();
            this.panelCentral.ResumeLayout(false);
            this.panelCentral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numDineroInicial;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.ImageList imageListIcons;
    }
}
