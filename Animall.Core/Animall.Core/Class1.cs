using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using PdfSharp.Fonts;

namespace Animall.Core
{
    // --- FONT RESOLVER (Sin cambios) ---
    public class ReportFontResolver : IFontResolver
    {
        public byte[] GetFont(string faceName)
        {
            var assembly = typeof(ReportFontResolver).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Animall.Core.Fonts." + faceName);
            if (stream == null)
                throw new FileNotFoundException("No se encontró la fuente " + faceName + " como recurso incrustado.");

            using (var reader = new MemoryStream())
            {
                stream.CopyTo(reader);
                return reader.ToArray();
            }
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            string faceName = familyName.ToLowerInvariant();
            switch (faceName)
            {
                case "arial":
                    if (isBold && isItalic) return new FontResolverInfo("arialbi.ttf");
                    if (isBold) return new FontResolverInfo("arialbd.ttf");
                    if (isItalic) return new FontResolverInfo("ariali.ttf");
                    return new FontResolverInfo("arial.ttf");
                case "courier new":
                    if (isBold && isItalic) return new FontResolverInfo("courbi.ttf");
                    if (isBold) return new FontResolverInfo("courbd.ttf");
                    if (isItalic) return new FontResolverInfo("couri.ttf");
                    return new FontResolverInfo("cour.ttf");
            }
            return null;
        }
    }

    // --- ENUMS e INTERFACES ---
    public enum Categoria
    {
        Bazar,
        ComidaParaGatos,
        ComidaParaPerros,
        Plásticos,
        ProductosDeLimpieza,
        Varios
    }
    public enum MetodoPago { Efectivo, ViüMi, Transferencia }
    public enum MotivoSalida { Sueldo, Proveedor, Impuestos, Publicidad, Otro }
    public enum TipoSalida { Caja, NoCaja }
    public interface IMovimientoDiario
    {
        DateTime Fecha { get; }
        string Descripcion { get; }
        decimal Importe { get; }
    }

    // --- CLASES DE DATOS ---
    public class ItemVenta
    {
        public Categoria Categoria { get; }
        public decimal Importe { get; }
        public string NombreCategoria => Venta.ObtenerNombreAmigable(Categoria);
        public ItemVenta(Categoria categoria, decimal importe) { Categoria = categoria; Importe = importe; }
        public override string ToString() => $"{NombreCategoria,-25} {Importe,10:C}";
    }
    public class Venta
    {
        public List<ItemVenta> Items { get; } = new List<ItemVenta>();
        public decimal Total => Items.Sum(i => i.Importe);
        public MetodoPago MetodoPago { get; set; } = MetodoPago.Efectivo;
        public void AgregarItem(ItemVenta item) => Items.Add(item);
        public void RemoverItem(ItemVenta item) => Items.Remove(item);
        public void Limpiar() { Items.Clear(); MetodoPago = MetodoPago.Efectivo; }
        public static string ObtenerNombreAmigable(Categoria cat)
        {
            return cat switch
            {
                Categoria.ComidaParaGatos => "Comida para Gatos",
                Categoria.ComidaParaPerros => "Comida para Perros",
                Categoria.ProductosDeLimpieza => "Productos de Limpieza",
                _ => cat.ToString(),
            };
        }
    }
    public class VentaRegistrada : IMovimientoDiario
    {
        public Guid Id { get; } = Guid.NewGuid();
        public int NumeroVenta { get; } // <-- CAMBIO: Añadido para el ID secuencial del ticket
        public DateTime Fecha { get; } = DateTime.Now;
        public List<ItemVenta> Items { get; }
        public decimal Importe { get; }
        public MetodoPago MetodoPago { get; }
        public string Descripcion => $"Venta ({Items.Count} ítems)";

        // <-- CAMBIO: Constructor actualizado para recibir el número de venta
        public VentaRegistrada(Venta venta, int numeroVenta)
        {
            Items = new List<ItemVenta>(venta.Items);
            Importe = venta.Total;
            MetodoPago = venta.MetodoPago;
            NumeroVenta = numeroVenta;
        }
        public override string ToString()
        {
            string metodo = MetodoPago switch
            {
                MetodoPago.ViüMi => "ViüMi",
                MetodoPago.Transferencia => "Transf.",
                _ => "Efectivo"
            };
            return $"{Fecha:HH:mm:ss} | {Descripcion,-30} | {Importe,10:C} | {metodo}";
        }
    }
    public class SalidaDinero : IMovimientoDiario
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime Fecha { get; } = DateTime.Now;
        public MotivoSalida Motivo { get; }
        public string Detalle { get; }
        public decimal Importe { get; }
        public TipoSalida Tipo { get; }
        public string Descripcion => $"{Motivo} - {Detalle}";
        public SalidaDinero(MotivoSalida motivo, string detalle, decimal importe, TipoSalida tipo) { Motivo = motivo; Detalle = detalle; Importe = importe; Tipo = tipo; }
        public static string ObtenerNombreAmigable(TipoSalida tipo)
        {
            return tipo switch
            {
                TipoSalida.NoCaja => "No Caja",
                _ => tipo.ToString(),
            };
        }
        public override string ToString() => $"{Fecha:HH:mm:ss} | {Descripcion,-30} | {-Importe,10:C} | {ObtenerNombreAmigable(Tipo)}";
    }
    public class ReporteDiario
    {
        public List<IMovimientoDiario> Movimientos { get; } = new List<IMovimientoDiario>();
        public decimal DineroInicial { get; set; }
        public decimal TotalVentas => Movimientos.OfType<VentaRegistrada>().Sum(v => v.Importe);
        public decimal TotalSalidas => Movimientos.OfType<SalidaDinero>().Sum(s => s.Importe);
        public decimal TotalSalidasDeCaja => Movimientos.OfType<SalidaDinero>().Where(s => s.Tipo == TipoSalida.Caja).Sum(s => s.Importe);
        public decimal TotalCaja => DineroInicial + TotalPorMetodoPago(MetodoPago.Efectivo) - TotalSalidasDeCaja;
        public void AgregarMovimiento(IMovimientoDiario movimiento) => Movimientos.Add(movimiento);
        public void Limpiar() { Movimientos.Clear(); DineroInicial = 0; }
        public decimal TotalPorMetodoPago(MetodoPago metodo) => Movimientos.OfType<VentaRegistrada>().Where(v => v.MetodoPago == metodo).Sum(v => v.Importe);
    }

    // --- SERVICIO DE TICKET ---
    public static class ServicioTicket
    {
        public static string GenerarTicket(VentaRegistrada venta)
        {
            var sb = new StringBuilder();
            const int totalWidth = 35;
            const int priceWidth = 14;
            const int nameWidth = totalWidth - priceWidth;

            sb.AppendLine("***********************************");
            sb.AppendLine("****** AnimallForrajería ******");
            sb.AppendLine("***********************************");
            sb.AppendLine($"Fecha: {venta.Fecha:dd/MM/yyyy HH:mm:ss}");
            // <-- CAMBIO: Se usa el nuevo número de venta secuencial
            sb.AppendLine($"Ticket Nro: {venta.NumeroVenta}");
            sb.AppendLine($"Método de Pago: {venta.MetodoPago}");
            sb.AppendLine("-----------------------------------");
            sb.AppendLine("DETALLE:");
            sb.AppendLine();

            foreach (var item in venta.Items)
            {
                string nombreCategoria = Venta.ObtenerNombreAmigable(item.Categoria);
                if (nombreCategoria.Length >= nameWidth)
                {
                    nombreCategoria = nombreCategoria.Substring(0, nameWidth - 1);
                }
                string precioFormateado = item.Importe.ToString("C");
                sb.AppendLine(nombreCategoria.PadRight(nameWidth) + precioFormateado.PadLeft(priceWidth));
            }

            sb.AppendLine();
            sb.AppendLine("".PadRight(totalWidth, '-'));
            string totalLabel = "TOTAL:";
            string totalFormateado = venta.Importe.ToString("C");
            sb.AppendLine(totalLabel.PadRight(nameWidth) + totalFormateado.PadLeft(priceWidth));
            sb.AppendLine("-----------------------------------");
            sb.AppendLine();
            sb.AppendLine(" ¡Gracias por su compra! ");
            sb.AppendLine("***********************************");

            return sb.ToString();
        }
    }

    // --- SERVICIO DE REPORTE PDF (Sin cambios) ---
    public static class ServicioReportePdf
    {
        public static void GenerarReporte(ReporteDiario reporte, string filePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            if (GlobalFontSettings.FontResolver == null)
            {
                GlobalFontSettings.FontResolver = new ReportFontResolver();
            }

            PdfDocument document = new PdfDocument();
            document.Info.Title = $"Reporte de Ventas - {DateTime.Now:dd-MM-yyyy}";
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont fontTitulo = new XFont("Arial", 20, XFontStyleEx.Bold);
            XFont fontSubtitulo = new XFont("Arial", 12, XFontStyleEx.Bold);
            XFont fontNormal = new XFont("Courier New", 10, XFontStyleEx.Regular);
            XFont fontTotal = new XFont("Arial", 12, XFontStyleEx.Bold);
            XFont fontHeaderTabla = new XFont("Courier New", 10, XFontStyleEx.Bold);

            double yPoint = 40;

            gfx.DrawString("Reporte de Movimientos del Día", fontTitulo, XBrushes.Black, new XRect(0, yPoint, page.Width.Point, 0), XStringFormats.TopCenter);
            yPoint += 40;
            gfx.DrawString($"Fecha de Generación: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", new XFont("Arial", 10), XBrushes.Gray, new XRect(0, yPoint, page.Width.Point, 0), XStringFormats.TopCenter);
            yPoint += 40;

            var ventas = reporte.Movimientos.OfType<VentaRegistrada>();
            yPoint = DibujarTablaVentas(gfx, "Resumen de Ventas", ventas, yPoint, page, fontSubtitulo, fontHeaderTabla, fontNormal, fontTotal);

            yPoint += 40;

            var salidas = reporte.Movimientos.OfType<SalidaDinero>();
            yPoint = DibujarTablaSalidas(gfx, "Resumen de Salidas", salidas, yPoint, page, fontSubtitulo, fontHeaderTabla, fontNormal, fontTotal);

            document.Save(filePath);
        }

        private static double DibujarTablaVentas(XGraphics gfx, string titulo, IEnumerable<VentaRegistrada> ventas, double yPoint, PdfPage page, XFont fontSubtitulo, XFont fontHeader, XFont fontNormal, XFont fontTotal)
        {
            double leftMargin = 40;
            double idColX = leftMargin;
            double horaColX = 80;
            double descColX = 160;
            double importeAlignX = page.Width.Point - leftMargin;

            gfx.DrawString(titulo, fontSubtitulo, XBrushes.Black, new XRect(leftMargin, yPoint, 0, 0), XStringFormats.BaseLineLeft);
            yPoint += 20;
            gfx.DrawLine(XPens.Black, leftMargin, yPoint, importeAlignX, yPoint);
            yPoint += 15;

            gfx.DrawString("ID", fontHeader, XBrushes.Black, new XRect(idColX, yPoint, 0, 0), XStringFormats.TopLeft);
            gfx.DrawString("Hora", fontHeader, XBrushes.Black, new XRect(horaColX, yPoint, 0, 0), XStringFormats.TopLeft);
            gfx.DrawString("Descripción", fontHeader, XBrushes.Black, new XRect(descColX, yPoint, 0, 0), XStringFormats.TopLeft);
            gfx.DrawString("Monto", fontHeader, XBrushes.Black, new XRect(0, yPoint, importeAlignX, 0), XStringFormats.TopRight);
            yPoint += 15;

            if (!ventas.Any())
            {
                gfx.DrawString("No se registraron ventas.", fontNormal, XBrushes.Black, leftMargin, yPoint);
                yPoint += 15;
            }
            else
            {
                int ventaCounter = 1;
                foreach (var v in ventas)
                {
                    gfx.DrawString(ventaCounter.ToString(), fontNormal, XBrushes.Black, new XRect(idColX, yPoint, 0, 0), XStringFormats.TopLeft);
                    gfx.DrawString(v.Fecha.ToString("HH:mm:ss"), fontNormal, XBrushes.Black, new XRect(horaColX, yPoint, 0, 0), XStringFormats.TopLeft);
                    gfx.DrawString(v.Descripcion, fontNormal, XBrushes.Black, new XRect(descColX, yPoint, 0, 0), XStringFormats.TopLeft);
                    gfx.DrawString(v.Importe.ToString("C"), fontNormal, XBrushes.Black, new XRect(0, yPoint, importeAlignX, 0), XStringFormats.TopRight);
                    yPoint += 15;
                    ventaCounter++;
                }
            }

            yPoint += 10;
            gfx.DrawLine(XPens.Black, descColX, yPoint, importeAlignX, yPoint);
            yPoint += 5;

            var totalVentas = ventas.Sum(v => v.Importe);
            gfx.DrawString("TOTAL VENTAS:", fontTotal, XBrushes.Black, new XRect(0, yPoint, importeAlignX - 80, 0), XStringFormats.TopRight);
            gfx.DrawString(totalVentas.ToString("C"), fontTotal, XBrushes.Black, new XRect(0, yPoint, importeAlignX, 0), XStringFormats.TopRight);
            yPoint += 25;

            return yPoint;
        }

        private static double DibujarTablaSalidas(XGraphics gfx, string titulo, IEnumerable<SalidaDinero> salidas, double yPoint, PdfPage page, XFont fontSubtitulo, XFont fontHeader, XFont fontNormal, XFont fontTotal)
        {
            double leftMargin = 40;
            double idColX = leftMargin;
            double horaColX = 80;
            double descColX = 160;
            double tipoColX = 380;
            double importeAlignX = page.Width.Point - leftMargin;

            gfx.DrawString(titulo, fontSubtitulo, XBrushes.Black, new XRect(leftMargin, yPoint, 0, 0), XStringFormats.BaseLineLeft);
            yPoint += 20;
            gfx.DrawLine(XPens.Black, leftMargin, yPoint, importeAlignX, yPoint);
            yPoint += 15;

            gfx.DrawString("ID", fontHeader, XBrushes.Black, new XRect(idColX, yPoint, 0, 0), XStringFormats.TopLeft);
            gfx.DrawString("Hora", fontHeader, XBrushes.Black, new XRect(horaColX, yPoint, 0, 0), XStringFormats.TopLeft);
            gfx.DrawString("Descripción", fontHeader, XBrushes.Black, new XRect(descColX, yPoint, 0, 0), XStringFormats.TopLeft);
            gfx.DrawString("Tipo", fontHeader, XBrushes.Black, new XRect(tipoColX, yPoint, 0, 0), XStringFormats.TopLeft);
            gfx.DrawString("Monto", fontHeader, XBrushes.Black, new XRect(0, yPoint, importeAlignX, 0), XStringFormats.TopRight);
            yPoint += 15;

            if (!salidas.Any())
            {
                gfx.DrawString("No se registraron salidas.", fontNormal, XBrushes.Black, leftMargin, yPoint);
                yPoint += 15;
            }
            else
            {
                int salidaCounter = 1;
                foreach (var s in salidas)
                {
                    gfx.DrawString(salidaCounter.ToString(), fontNormal, XBrushes.Black, new XRect(idColX, yPoint, 0, 0), XStringFormats.TopLeft);
                    gfx.DrawString(s.Fecha.ToString("HH:mm:ss"), fontNormal, XBrushes.Black, new XRect(horaColX, yPoint, 0, 0), XStringFormats.TopLeft);
                    gfx.DrawString(s.Descripcion, fontNormal, XBrushes.Black, new XRect(descColX, yPoint, 0, 0), XStringFormats.TopLeft);
                    gfx.DrawString(SalidaDinero.ObtenerNombreAmigable(s.Tipo), fontNormal, XBrushes.Black, new XRect(tipoColX, yPoint, 0, 0), XStringFormats.TopLeft);
                    gfx.DrawString(s.Importe.ToString("C"), fontNormal, XBrushes.Black, new XRect(0, yPoint, importeAlignX, 0), XStringFormats.TopRight);
                    yPoint += 15;
                    salidaCounter++;
                }
            }

            yPoint += 10;
            gfx.DrawLine(XPens.Black, descColX, yPoint, importeAlignX, yPoint);
            yPoint += 5;

            var totalSalidas = salidas.Sum(s => s.Importe);
            gfx.DrawString("TOTAL SALIDAS:", fontTotal, XBrushes.Black, new XRect(0, yPoint, importeAlignX - 80, 0), XStringFormats.TopRight);
            gfx.DrawString(totalSalidas.ToString("C"), fontTotal, XBrushes.Black, new XRect(0, yPoint, importeAlignX, 0), XStringFormats.TopRight);
            yPoint += 25;

            return yPoint;
        }
    }
}

