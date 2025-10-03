using System;
using System.Drawing;
using System.Windows.Forms;

namespace Animall.app
{
    public partial class ConfirmacionReinicioForm : Form
    {
        // --- AÑADIDO: Variables para arrastrar el formulario sin bordes ---
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public ConfirmacionReinicioForm()
        {
            InitializeComponent();
            this.Icon = new Icon("logo.ico");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtConfirmacion.Text == "1111")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("El código ingresado no es correcto.", "Error de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmacion.Focus();
                txtConfirmacion.SelectAll();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtConfirmacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void ConfirmacionReinicioForm_Load(object sender, EventArgs e)
        {
            txtConfirmacion.Focus();
        }

        // --- AÑADIDO: Métodos para manejar el arrastre y cierre del formulario ---

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void pnlTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void pnlTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

