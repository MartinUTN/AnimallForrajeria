using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Animall.Core;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Animall.app
{
    public partial class MainForm : Form
    {
        private Venta _ventaActual;
        private ReporteDiario _reporteDiario;
        private decimal _dineroInicial;
        private MetodoPago _currentPaymentMethod = MetodoPago.Efectivo;

        public MainForm(decimal dineroInicial)
        {
            InitializeComponent();
            _dineroInicial = dineroInicial;
            _ventaActual = new Venta();
            _reporteDiario = new ReporteDiario { DineroInicial = _dineroInicial };
            this.Icon = new Icon("logo.ico");

            this.WindowState = FormWindowState.Maximized;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
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

            numImporte.DecimalPlaces = 2;
            numImporte.Maximum = 1000000;
            numImporte.Value = 0;

            ConfigurarSalidaDinero();

            timerClock.Interval = 1000;
            timerClock.Start();
            timerClock.Tick += timerClock_Tick;

            lstVentasDelDia.DrawItem += lstVentasDelDia_DrawItem;

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

                // // Actualiza la UI y prepara para el siguiente item.
                ActualizarVistaVenta();
                numImporte.Value = 0; // // Limpia el importe
                cmbCategorias.Focus(); // // Pone el foco de vuelta en la categoría
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

            _ventaActual.MetodoPago = _currentPaymentMethod;

            int numeroDeVenta = _reporteDiario.Movimientos.OfType<VentaRegistrada>().Count() + 1;
            var ventaParaRegistrar = new VentaRegistrada(_ventaActual, numeroDeVenta);

            _reporteDiario.AgregarMovimiento(ventaParaRegistrar);
            ActualizarVistaReporte();

            string ticket = ServicioTicket.GenerarTicket(ventaParaRegistrar);
            using (TicketForm ticketForm = new TicketForm(ticket))
            {
                ticketForm.ShowDialog();
            }

            _ventaActual.Limpiar();
            ActualizarVistaVenta();

            _currentPaymentMethod = MetodoPago.Efectivo;
            lblMetodoPagoActual.Text = "Método de Pago: Efectivo (CTRL)";
        }

        private void ActualizarVistaVenta()
        {
            lstItemsVenta.DataSource = null;
            lstItemsVenta.DataSource = _ventaActual.Items;
            lblTotal.Text = $"TOTAL: {_ventaActual.Total:C}";
        }

        private void EliminarItemVenta()
        {
            if (lstItemsVenta.SelectedItem is ItemVenta selectedItem)
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
            cmbMotivoSalida.SelectedIndexChanged += cmbMotivoSalida_SelectedIndexChanged;


            var tiposSalida = Enum.GetValues(typeof(TipoSalida))
                .Cast<TipoSalida>()
                .Select(t => new { Display = SalidaDinero.ObtenerNombreAmigable(t), Value = t })
                .ToList();

            cmbTipoSalida.DataSource = tiposSalida;
            cmbTipoSalida.DisplayMember = "Display";
            cmbTipoSalida.ValueMember = "Value";

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
            if (cmbMotivoSalida.SelectedValue is not MotivoSalida motivo || motivo == (MotivoSalida)(-1))
            {
                MessageBox.Show("Debe seleccionar un motivo.", "Dato Faltante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var monto = numMontoSalida.Value;
            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero.", "Dato Faltante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tipoSalida = (TipoSalida)cmbTipoSalida.SelectedValue;
            string detalle = "";

            switch (motivo)
            {
                case MotivoSalida.Sueldo:
                case MotivoSalida.Impuestos:
                case MotivoSalida.Publicidad:
                    detalle = cmbDetalleSalida.SelectedItem?.ToString() ?? string.Empty;
                    if (string.IsNullOrEmpty(detalle))
                    {
                        MessageBox.Show("Debe seleccionar un detalle.", "Dato Faltante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
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
                    detalle = txtOtroMotivo.Text;
                    break;
            }

            var nuevaSalida = new SalidaDinero(motivo, detalle, monto, tipoSalida);
            _reporteDiario.AgregarMovimiento(nuevaSalida);
            ActualizarVistaReporte();
            MessageBox.Show("Salida de dinero registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormularioSalida();
        }

        private void LimpiarFormularioSalida()
        {
            cmbMotivoSalida.SelectedIndex = 0;
            numMontoSalida.Value = 0;
            cmbTipoSalida.SelectedIndex = 0;
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
            if (e.Index < 0 || e.Index >= lstVentasDelDia.Items.Count) return;

            var item = (IMovimientoDiario)lstVentasDelDia.Items[e.Index];

            Brush backgroundBrush = Brushes.White;
            if (item is SalidaDinero)
            {
                backgroundBrush = new SolidBrush(Color.FromArgb(255, 224, 224));
            }

            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);

            Font? font = e.Font;
            if (font == null) font = lstVentasDelDia.Font;

            e.Graphics.DrawString(item.ToString(), font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (!_reporteDiario.Movimientos.Any() && _reporteDiario.DineroInicial == 0)
            {
                MessageBox.Show("No hay movimientos para cerrar la caja.", "Caja Vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine("--- RESUMEN DE CIERRE DE CAJA ---");
            sb.AppendLine();
            sb.AppendLine($"Dinero Inicial en Caja: {_reporteDiario.DineroInicial:C}");
            sb.AppendLine($" + Ventas en Efectivo: {_reporteDiario.TotalPorMetodoPago(MetodoPago.Efectivo):C}");
            sb.AppendLine($" - Salidas de Caja: {_reporteDiario.TotalSalidasDeCaja:C}");
            sb.AppendLine("------------------------------------");
            sb.AppendLine($"DINERO ESPERADO EN CAJA: {_reporteDiario.TotalCaja:C}");
            sb.AppendLine();
            sb.AppendLine("--- Otros Medios de Pago ---");
            sb.AppendLine($"Total Ventas Transferencia: {_reporteDiario.TotalPorMetodoPago(MetodoPago.Transferencia):C}");
            sb.AppendLine($"Total Ventas ViüMi: {_reporteDiario.TotalPorMetodoPago(MetodoPago.ViüMi):C}");
            sb.AppendLine();
            sb.AppendLine("¿Desea reiniciar la jornada? Se borrarán todos los movimientos.");

            var confirmResult = MessageBox.Show(sb.ToString(),
                                              "Confirmar Cierre de Caja",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                using (var formConfirmacion = new ConfirmacionReinicioForm())
                {
                    if (formConfirmacion.ShowDialog() == DialogResult.OK)
                    {
                        ReiniciarJornada();
                    }
                }
            }
        }

        private void ReiniciarJornada()
        {
            this.Hide();
            using (var formDineroInicial = new DineroInicialForm())
            {
                if (formDineroInicial.ShowDialog() == DialogResult.OK)
                {
                    _dineroInicial = formDineroInicial.DineroInicial;
                    _reporteDiario.Limpiar();
                    _reporteDiario.DineroInicial = _dineroInicial;
                    ActualizarVistaReporte();
                    MessageBox.Show("La jornada ha sido reiniciada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void btnDescargarReporte_Click(object sender, EventArgs e)
        {
            if (!_reporteDiario.Movimientos.Any())
            {
                MessageBox.Show("No hay movimientos para generar un reporte.", "Reporte Vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string reportesPath = Path.Combine(desktopPath, "ReportesAnimall");

                Directory.CreateDirectory(reportesPath);

                DateTime ahora = DateTime.Now;
                string turno = (ahora.Hour >= 5 && ahora.Hour <= 14) ? "mañana" : "tarde";
                string fileName = $"Reporte-Animall-{ahora:yyyy-MM-dd}-{turno}.pdf";

                string fullPath = Path.Combine(reportesPath, fileName);

                ServicioReportePdf.GenerarReporte(_reporteDiario, fullPath);

                var result = MessageBox.Show(
                    $"Reporte PDF guardado exitosamente en:\n{fullPath}\n\n¿Desea abrir la carpeta?",
                    "Éxito",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", reportesPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar el reporte PDF:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // // El foco ya no se cambia automáticamente.
            // // El usuario debe presionar Enter para confirmar la selección y avanzar.
        }

        private void cmbCategorias_KeyDown(object sender, KeyEventArgs e)
        {
            // // Si la tecla presionada es Enter...
            if (e.KeyCode == Keys.Enter)
            {
                // // ...y hay una categoría válida seleccionada...
                if (cmbCategorias.SelectedValue != null)
                {
                    // // ...movemos el foco al campo de importe.
                    numImporte.Focus();
                    // // Suprimimos el sonido "ding" de Windows.
                    e.SuppressKeyPress = true;
                }
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

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControlPrincipal.SelectedTab != tabPageVenta)
            {
                return;
            }

            if (e.Control && !e.Alt && !e.Shift)
            {
                using (var seleccionarMetodosForm = new SeleccionarMetodos())
                {
                    if (seleccionarMetodosForm.ShowDialog() == DialogResult.OK)
                    {
                        char selected = 'E';
                        if (!string.IsNullOrEmpty(seleccionarMetodosForm.SelectedMethod))
                        {
                            selected = seleccionarMetodosForm.SelectedMethod[0];
                        }

                        switch (selected)
                        {
                            case 'V':
                                _currentPaymentMethod = MetodoPago.ViüMi;
                                lblMetodoPagoActual.Text = "Método de Pago: ViüMi (CTRL)";
                                break;
                            case 'T':
                                _currentPaymentMethod = MetodoPago.Transferencia;
                                lblMetodoPagoActual.Text = "Método de Pago: Transferencia (CTRL)";
                                break;
                            case 'E':
                            default:
                                _currentPaymentMethod = MetodoPago.Efectivo;
                                lblMetodoPagoActual.Text = "Método de Pago: Efectivo (CTRL)";
                                break;
                        }
                    }
                }
                e.Handled = true;
            }
            else if (e.Alt && !e.Control && !e.Shift)
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

