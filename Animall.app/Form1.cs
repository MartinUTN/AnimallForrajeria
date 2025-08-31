// Proyecto: Animall.App
// Archivo: Form1.cs

using Animall.Core;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Animall.App
{
    public partial class Form1 : Form
    {
        private Venta _ventaActual;
        private ReporteDiario _reporteDiario;

        public Form1()
        {
            InitializeComponent();
            _ventaActual = new Venta();
            _reporteDiario = new ReporteDiario();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Punto de Venta - AnimallForrajería";

            var friendlyCategories = Enum.GetValues(typeof(Categoria))
                .Cast<Categoria>()
                .Select(cat => new {
                    Display = Venta.ObtenerNombreAmigable(cat),
                    Value = cat
                })
                .ToList();

            cmbCategorias.DataSource = friendlyCategories;
            cmbCategorias.DisplayMember = "Display";
            cmbCategorias.ValueMember = "Value";

            cmbMetodoPago.DataSource = Enum.GetValues(typeof(MetodoPago));

            numImporte.DecimalPlaces = 2;
            numImporte.Maximum = 1000000;
            numImporte.Value = 0;

            ConfigurarSalidaDinero();

            timerClock.Interval = 1000;
            timerClock.Start();

            ActualizarVistaVenta();
            ActualizarVistaReporte();
        }

        #region Venta

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarItemVenta();
        }

        private void AgregarItemVenta()
        {
            if (cmbCategorias.SelectedValue is Categoria categoriaSeleccionada)
            {
                var importe = numImporte.Value;
                if (importe <= 0)
                {
                    MessageBox.Show("El importe debe ser mayor a cero.", "Dato Faltante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var nuevoItem = new ItemVenta(categoriaSeleccionada, importe);
                _ventaActual.AgregarItem(nuevoItem);
                ActualizarVistaVenta();
                cmbCategorias.Focus();
                numImporte.Value = 0;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una categoría válida.", "Categoría no válida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (!_ventaActual.Items.Any())
            {
                MessageBox.Show("No se han agregado ítems a la venta.", "Venta Vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbMetodoPago.SelectedItem is MetodoPago metodoSeleccionado)
            {
                _ventaActual.MetodoPago = metodoSeleccionado;
            }

            var ventaParaRegistrar = new VentaRegistrada(_ventaActual);
            _reporteDiario.AgregarMovimiento(ventaParaRegistrar);
            ActualizarVistaReporte();

            string ticket = ServicioTicket.GenerarTicket(ventaParaRegistrar);
            using (TicketForm ticketForm = new TicketForm(ticket))
            {
                ticketForm.ShowDialog();
            }

            _ventaActual.Limpiar();
            ActualizarVistaVenta();
        }

        private void ActualizarVistaVenta()
        {
            lstItemsVenta.DataSource = null;
            lstItemsVenta.DataSource = _ventaActual.Items;
            lblTotal.Text = $"TOTAL: {_ventaActual.Total:C}";
        }

        private void EliminarItemVenta()
        {
            var selectedItem = lstItemsVenta.SelectedItem as ItemVenta;
            if (selectedItem != null)
            {
                var confirmResult = MessageBox.Show($"¿Está seguro que desea eliminar '{selectedItem}'?",
                                     "Confirmar Eliminación",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    _ventaActual.RemoverItem(selectedItem);
                    ActualizarVistaVenta();
                }
            }
        }

        #endregion

        #region Salida

        private void ConfigurarSalidaDinero()
        {
            var motivos = Enum.GetValues(typeof(MotivoSalida))
                .Cast<MotivoSalida>()
                .Select(m => new { Display = m.ToString(), Value = m })
                .OrderBy(m => m.Display)
                .ToList();

            motivos.Insert(0, new { Display = "<Seleccione motivo>", Value = (MotivoSalida)(-1) });

            cmbMotivoSalida.DataSource = motivos;
            cmbMotivoSalida.DisplayMember = "Display";
            cmbMotivoSalida.ValueMember = "Value";

            numMontoSalida.DecimalPlaces = 2;
            numMontoSalida.Maximum = 1000000;
        }

        private void cmbMotivoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarTodosLosDetalles();

            if (cmbMotivoSalida.SelectedValue is MotivoSalida selectedValue && selectedValue != (MotivoSalida)(-1))
            {
                lblDetalleSalida.Visible = true;
                switch (selectedValue)
                {
                    case MotivoSalida.Sueldo:
                        lblDetalleSalida.Text = "Empleado:";
                        cmbDetalleSalida.DataSource = new[] { "Andrea", "Nicolas" }.OrderBy(x => x).ToList();
                        cmbDetalleSalida.Visible = true;
                        break;
                    case MotivoSalida.Proveedor:
                        lblDetalleSalida.Text = "Nombre Proveedor:";
                        txtProveedor.Visible = true;
                        txtProveedor.Focus();
                        break;
                    case MotivoSalida.Impuestos:
                        lblDetalleSalida.Text = "Impuesto:";
                        cmbDetalleSalida.DataSource = new[] { "Comuna", "Agua", "Luz", "API", "ARCA" }.OrderBy(x => x).ToList();
                        cmbDetalleSalida.Visible = true;
                        break;
                    case MotivoSalida.Publicidad:
                        lblDetalleSalida.Text = "Medio:";
                        cmbDetalleSalida.DataSource = new[] { "Televisión", "Radio", "Redes" }.OrderBy(x => x).ToList();
                        cmbDetalleSalida.Visible = true;
                        break;
                    case MotivoSalida.Otro:
                        lblDetalleSalida.Text = "Motivo (opcional):";
                        txtOtroMotivo.Visible = true;
                        txtOtroMotivo.Focus();
                        break;
                }
            }
        }

        private void cmbDetalleSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDetalleSalida.SelectedIndex != -1)
            {
                numMontoSalida.Focus();
            }
        }

        private void txtProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numMontoSalida.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtOtroMotivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numMontoSalida.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void OcultarTodosLosDetalles()
        {
            lblDetalleSalida.Visible = false;
            cmbDetalleSalida.Visible = false;
            txtProveedor.Visible = false;
            txtOtroMotivo.Visible = false;
            cmbDetalleSalida.DataSource = null;
            txtProveedor.Text = "";
            txtOtroMotivo.Text = "";
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            RegistrarSalida();
        }

        private void RegistrarSalida()
        {
            if (cmbMotivoSalida.SelectedValue == null || (MotivoSalida)cmbMotivoSalida.SelectedValue == (MotivoSalida)(-1))
            {
                MessageBox.Show("Debe seleccionar un motivo.", "Dato Faltante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var motivo = (MotivoSalida)cmbMotivoSalida.SelectedValue;
            var monto = numMontoSalida.Value;
            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero.", "Dato Faltante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string detalle = "";
            switch (motivo)
            {
                case MotivoSalida.Sueldo:
                case MotivoSalida.Impuestos:
                case MotivoSalida.Publicidad:
                    if (cmbDetalleSalida.SelectedItem == null)
                    {
                        MessageBox.Show("Debe seleccionar un detalle.", "Dato Faltante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    detalle = cmbDetalleSalida.SelectedItem.ToString() ?? "";
                    break;
                case MotivoSalida.Proveedor:
                    if (string.IsNullOrWhiteSpace(txtProveedor.Text))
                    {
                        MessageBox.Show("Debe ingresar el nombre del proveedor.", "Dato Faltante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    detalle = txtProveedor.Text;
                    break;
                case MotivoSalida.Otro:
                    detalle = txtOtroMotivo.Text ?? "";
                    break;
            }

            var nuevaSalida = new SalidaDinero(motivo, detalle, monto);
            _reporteDiario.AgregarMovimiento(nuevaSalida);
            ActualizarVistaReporte();
            MessageBox.Show("Salida de dinero registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormularioSalida();
        }

        private void LimpiarFormularioSalida()
        {
            cmbMotivoSalida.SelectedIndex = 0;
            numMontoSalida.Value = 0;
            OcultarTodosLosDetalles();
            cmbMotivoSalida.Focus();
        }

        #endregion

        #region Reporte

        private void ActualizarVistaReporte()
        {
            lstVentasDelDia.DataSource = null;
            lstVentasDelDia.DataSource = _reporteDiario.Movimientos;
            lblTotalDelDia.Text = $"TOTAL VENTAS: {_reporteDiario.TotalVentas:C}";
        }

        private void lstVentasDelDia_DoubleClick(object sender, EventArgs e)
        {
            if (lstVentasDelDia.SelectedItem is VentaRegistrada ventaSeleccionada)
            {
                string ticket = ServicioTicket.GenerarTicket(ventaSeleccionada);
                using (TicketForm ticketForm = new TicketForm(ticket))
                {
                    ticketForm.ShowDialog();
                }
            }
        }

        private void lstVentasDelDia_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var listBox = (ListBox)sender;
            if (listBox.Items.Count == 0) return;

            var item = (IMovimientoDiario)listBox.Items[e.Index];

            Brush backgroundBrush = Brushes.White;
            if (item is SalidaDinero)
            {
                backgroundBrush = new SolidBrush(Color.FromArgb(255, 224, 224)); // Rojo claro
            }

            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);

            Font font = e.Font ?? listBox.Font;
            e.Graphics.DrawString(item.ToString(), font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (!_reporteDiario.Movimientos.Any())
            {
                MessageBox.Show("No hay movimientos para cerrar la caja.", "Caja Vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine("--- RESUMEN DE CIERRE DE CAJA ---");
            sb.AppendLine();
            sb.AppendLine($"Total Ventas Efectivo: {_reporteDiario.TotalPorMetodoPago(MetodoPago.Efectivo):C}");
            sb.AppendLine($"Total Ventas Transferencia: {_reporteDiario.TotalPorMetodoPago(MetodoPago.Transferencia):C}");
            sb.AppendLine($"Total Ventas ViüMi: {_reporteDiario.TotalPorMetodoPago(MetodoPago.ViüMi):C}");
            sb.AppendLine("------------------------------------");
            sb.AppendLine($"Total de Salidas: {_reporteDiario.TotalSalidas:C}");
            sb.AppendLine("------------------------------------");
            sb.AppendLine($"DINERO ESPERADO EN CAJA: {_reporteDiario.TotalCaja:C}");
            sb.AppendLine();
            sb.AppendLine("¿Desea reiniciar la jornada? Se borrarán todos los movimientos.");

            var confirmResult = MessageBox.Show(sb.ToString(),
                                     "Confirmar Cierre de Caja",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                _reporteDiario.Limpiar();
                ActualizarVistaReporte();
                MessageBox.Show("La jornada ha sido reiniciada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDescargarReporte_Click(object sender, EventArgs e)
        {
            if (!_reporteDiario.Movimientos.Any())
            {
                MessageBox.Show("No hay movimientos para generar un reporte.", "Reporte Vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar Reporte del Día";

                DateTime ahora = DateTime.Now;
                string turno = (ahora.Hour >= 5 && ahora.Hour <= 14) ? "mañana" : "tarde";
                saveFileDialog.FileName = $"Reporte-Animall-{ahora:yyyy-MM-dd}-{turno}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ServicioReportePdf.GenerarReporte(_reporteDiario, saveFileDialog.FileName);
                        MessageBox.Show("Reporte PDF guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al guardar el reporte PDF:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Controles Comunes y Atajos

        private void timerClock_Tick(object sender, EventArgs e)
        {
            string timeString = DateTime.Now.ToString("T");
            lblClockVenta.Text = timeString;
            lblClockReporte.Text = timeString;
            lblClockSalida.Text = timeString;
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategorias.SelectedIndex != -1)
            {
                numImporte.Focus();
            }
        }

        private void numImporte_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                numImporte.Select(0, numImporte.Text.Length);
            });
        }

        private void numMontoSalida_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                numMontoSalida.Select(0, numMontoSalida.Text.Length);
            });
        }

        private void cmbCategorias_Validating(object sender, CancelEventArgs e)
        {
            if (cmbCategorias.FindStringExact(cmbCategorias.Text) == -1)
            {
                cmbCategorias.Text = "";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnFinalizar_Click(sender, e);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (lstItemsVenta.Focused && lstItemsVenta.SelectedItem != null)
                {
                    EliminarItemVenta();
                }
            }
        }


        private void numImporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AgregarItemVenta();
                e.SuppressKeyPress = true;
            }
        }

        private void numMontoSalida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RegistrarSalida();
                e.SuppressKeyPress = true;
            }
        }

        #endregion
    }
}

