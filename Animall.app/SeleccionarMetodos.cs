using System;
using System.Windows.Forms;

namespace Animall.app
{
    public partial class SeleccionarMetodos : Form
    {
        public string SelectedMethod { get; private set; }

        public SeleccionarMetodos()
        {
            InitializeComponent();
            SelectedMethod = "";
        }

        private void SelectMethodForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void SelectMethodForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.E:
                    SelectedMethod = "E";
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case Keys.V:
                    SelectedMethod = "V";
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case Keys.T:
                    SelectedMethod = "T";
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
