// Proyecto: Animall.app
// Archivo: SelectMethodForm.cs (Restaurado a la lógica original)

using System;
using System.Windows.Forms;

namespace Animall.app
{
    public partial class SelectMethodForm : Form
    {
        public string SelectedMethod { get; private set; }

        public SelectMethodForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.SelectedMethod = "";
        }

        private void SelectMethodForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Carga la imagen desde los recursos del proyecto.
                // Asegúrate de que la imagen se llame 'metodos_pago' en tus Recursos.
                pictureBox1.Image = Properties.Resources.metodos_pago;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo cargar la imagen de métodos de pago.", "Error de Recurso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectMethodForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.E:
                    SelectedMethod = "Efectivo";
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case Keys.V:
                    SelectedMethod = "ViüMi"; // Corregido para coincidir con el Enum
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case Keys.T:
                    SelectedMethod = "Transferencia";
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
            }
        }
    }
}

