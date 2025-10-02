using System;
using System.Windows.Forms;

namespace Animall.app
{
    // La corrección clave es asegurar que herede de Form -> ": Form"
    public partial class DineroInicialForm : Form
    {
        public decimal DineroInicial { get; private set; }

        public DineroInicialForm()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DineroInicial = numDineroInicial.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void numDineroInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Suprime el sonido de Windows al presionar Enter
                e.SuppressKeyPress = true;
                // Llama al evento del botón Aceptar para cerrar el formulario
                btnAceptar_Click(sender, e);
            }
        }

        private void DineroInicialForm_Load(object sender, EventArgs e)
        {
            // Pone el foco en el campo numérico cuando se carga el formulario
            numDineroInicial.Focus();
        }
    }
}
