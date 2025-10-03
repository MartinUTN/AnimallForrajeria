using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Animall.app
{
    public partial class TicketForm : Form
    {
        public TicketForm(string ticketContent)
        {
            InitializeComponent();
            txtTicket.Text = ticketContent;
            this.KeyPreview = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirTicket();
        }

        private void ImprimirTicket()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                ev.Graphics.DrawString(txtTicket.Text, txtTicket.Font, System.Drawing.Brushes.Black,
                    ev.MarginBounds, StringFormat.GenericTypographic);
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void TicketForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.I)
            {
                ImprimirTicket();
            }
        }
    }
}

