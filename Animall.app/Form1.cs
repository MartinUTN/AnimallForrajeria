using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing; // Directiva using necesaria para la clase Ticket
using System.Linq;
using System.Windows.Forms;

namespace Animall.app
{
    public partial class Form1 : Form
    {
        private string metodoPago = "Efectivo";
        private List<VentaItem> ventaActual = new List<VentaItem>();
        private decimal dineroInicialCaja; // Variable para guardar el dinero inicial.

        // Constructor por defecto
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        // Constructor que recibe el dinero inicial
        public Form1(decimal dineroInicial) : this()
        {
            this.dineroInicialCaja = dineroInicial;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblMetodoPagoActual.Text = "Método de Pago: " + metodoPago;
            // Aquí puedes cargar tus categorías, etc.
        }

        private void LimpiarVenta()
        {
            ventaActual.Clear();
            ActualizarListaVenta();
            this.metodoPago = "Efectivo";
            lblMetodoPagoActual.Text = "Método de Pago: " + metodoPago;
            cmbCategorias.Focus();
        }

        private void ActualizarListaVenta()
        {
            lstItemsVenta.Items.Clear();
            lstItemsVenta.Items.Add($"{"PRODUCTO",-30} {"IMPORTE",10}"); // Cabecera
            foreach (var item in ventaActual)
            {
                lstItemsVenta.Items.Add(item.ToString());
            }
            double total = ventaActual.Sum(item => item.Importe);
            lblTotal.Text = $"TOTAL: {total:C2}";
        }

        private void FinalizarVenta()
        {
            double totalVenta = ventaActual.Sum(item => item.Importe);

            if (totalVenta > 0)
            {
                Ticket ticket = new Ticket();
                ticket.AddHeaderLine("Animall Forrajeria");
                ticket.AddSubHeaderLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                ticket.AddSubHeaderLine("--------------------------------");

                foreach (var item in ventaActual)
                {
                    ticket.AddItem("1", item.Categoria, item.Importe.ToString("C"));
                }

                ticket.AddFooterLine("--------------------------------");
                ticket.AddFooterLine("TOTAL: " + totalVenta.ToString("C"));
                ticket.AddFooterLine("Metodo de pago: " + this.metodoPago);
                ticket.AddFooterLine("");
                ticket.AddFooterLine("Gracias por su compra!");

                // ticket.Print(); // Descomentar para impresión real.

                MessageBox.Show("Ticket generado con éxito.", "Venta Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarVenta();
            }
            else
            {
                MessageBox.Show("No hay artículos en la venta para finalizar.", "Venta Vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            FinalizarVenta();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                using (SelectMethodForm selectForm = new SelectMethodForm())
                {
                    if (selectForm.ShowDialog() == DialogResult.OK)
                    {
                        this.metodoPago = selectForm.SelectedMethod;
                        lblMetodoPagoActual.Text = "Método de Pago: " + this.metodoPago;
                    }
                }
            }
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                FinalizarVenta();
            }
        }

        #region Eventos de Controles UI

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategorias.SelectedItem != null && cmbCategorias.SelectedItem.ToString() == "Varios")
            {
                numImporte.Enabled = true;
                numImporte.Focus();
            }
            else
            {
                numImporte.Enabled = false;
                numImporte.Value = 0;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string categoria = cmbCategorias.Text;
            decimal importe = numImporte.Value;

            if (string.IsNullOrWhiteSpace(categoria))
            {
                MessageBox.Show("Por favor, seleccione o ingrese una categoría.");
                return;
            }

            if (importe > 0)
            {
                ventaActual.Add(new VentaItem { Categoria = categoria, Importe = (double)importe });
                ActualizarListaVenta();
                cmbCategorias.Focus();
                cmbCategorias.Text = "";
                numImporte.Value = 0;
            }
        }

        private void lstItemsVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lstItemsVenta.SelectedIndex > 0)
            {
                // El índice 0 es la cabecera, por eso restamos 1.
                ventaActual.RemoveAt(lstItemsVenta.SelectedIndex - 1);
                ActualizarListaVenta();
            }
        }
        private void numImporte_Enter(object sender, EventArgs e)
        {
            numImporte.Select(0, numImporte.Text.Length);
        }

        private void numImporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAgregar_Click(sender, e);
                e.SuppressKeyPress = true; // Evita el sonido 'ding' al presionar Enter.
            }
        }
        #endregion
    }

    public class VentaItem
    {
        public string Categoria { get; set; }
        public double Importe { get; set; }

        public override string ToString()
        {
            return $"{Categoria,-30} {Importe,10:C2}";
        }
    }

    // --- CLASE TICKET COMPLETA INCLUIDA AQUÍ ---
    public class Ticket
    {
        private List<string> headerLines = new List<string>();
        private List<string> subHeaderLines = new List<string>();
        private List<string> items = new List<string>();
        private List<string> footerLines = new List<string>();
        private int maxChars = 40; // Ancho del ticket
        private Font printFont = new Font("Courier New", 10);
        private Graphics gfx;

        public void AddHeaderLine(string line)
        {
            headerLines.Add(line);
        }

        public void AddSubHeaderLine(string line)
        {
            subHeaderLines.Add(line);
        }

        public void AddItem(string qty, string name, string price)
        {
            int nameWidth = maxChars - qty.Length - price.Length - 2; // -2 for spaces
            if (name.Length > nameWidth)
            {
                name = name.Substring(0, nameWidth);
            }
            else
            {
                name = name.PadRight(nameWidth, ' ');
            }
            items.Add($"{qty} {name} {price}");
        }

        public void AddFooterLine(string line)
        {
            footerLines.Add(line);
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            gfx = e.Graphics;
            float yPos = 0;
            float leftMargin = 0; // Iniciar en 0 para impresoras de tickets
            float topMargin = 0; // Iniciar en 0
            int count = 0;

            // Header
            foreach (string headerLine in headerLines)
            {
                yPos = topMargin + (count * printFont.GetHeight(gfx));
                gfx.DrawString(Center(headerLine), printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            // SubHeader
            foreach (string subHeaderLine in subHeaderLines)
            {
                yPos = topMargin + (count * printFont.GetHeight(gfx));
                gfx.DrawString(subHeaderLine, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            // Items
            foreach (string item in items)
            {
                yPos = topMargin + (count * printFont.GetHeight(gfx));
                gfx.DrawString(item, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            // Footer
            foreach (string footerLine in footerLines)
            {
                yPos = topMargin + (count * printFont.GetHeight(gfx));
                gfx.DrawString(Center(footerLine), printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }
        }

        private string Center(string text)
        {
            if (text.Length >= maxChars)
                return text;

            int spaces = (maxChars - text.Length) / 2;
            return new string(' ', spaces) + text;
        }

        public void Print()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            // Puedes especificar el nombre de tu impresora de tickets aquí:
            // printDocument.PrinterSettings.PrinterName = "POS-80C"; 
            try
            {
                if (printDocument.PrinterSettings.IsValid)
                {
                    printDocument.Print();
                }
                else
                {
                    MessageBox.Show("No se encontró una impresora válida.", "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar imprimir: {ex.Message}", "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

