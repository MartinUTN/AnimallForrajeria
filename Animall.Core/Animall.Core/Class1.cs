// Proyecto: Animall.Core
// Archivo: Class1.cs

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
            return new FontResolverInfo("arial.ttf");
        }
    }

    public enum Categoria { Bazar, ComidaParaGatos, ComidaParaPerro, Plasticos, ProductosDeLimpieza, Varios }
    public enum MetodoPago { Efectivo, Transferencia, ViüMi }
    public enum MotivoSalida { Impuestos, Otro, Proveedor, Publicidad, Sueldo }

    public class ItemVenta
    {
        public Categoria Categoria { get; set; }
        public decimal Importe { get; set; }

        public ItemVenta(Categoria categoria, decimal importe)
        {
            Categoria = categoria;
            Importe = importe;
        }

        public override string ToString()
        {
            string nombre = Venta.ObtenerNombreAmigable(Categoria);
            return string.Format("{0,-30}{1,15:C}", nombre, Importe);
        }
    }

    public class Venta
    {
        private readonly List<ItemVenta> _items = new List<ItemVenta>();
        public IReadOnlyList<ItemVenta> Items => _items;
        public decimal Total => _items.Sum(item => item.Importe);
        public MetodoPago MetodoPago { get; set; }

        public void AgregarItem(ItemVenta item)
        {
            _items.Add(item);
        }

        public void RemoverItem(ItemVenta item)
        {
            _items.Remove(item);
        }

        public void Limpiar()
        {
            _items.Clear();
        }

        public static string ObtenerNombreAmigable(Categoria categoria)
        {
            switch (categoria)
            {
                case Categoria.ComidaParaGatos: return "Comida para gatos";
                case Categoria.ComidaParaPerro: return "Comida para perro";
                case Categoria.ProductosDeLimpieza: return "Productos de limpieza";
                default: return categoria.ToString();
            }
        }
    }

    public interface IMovimientoDiario
    {
        int Id { get; }
        DateTime Fecha { get; }
        string Descripcion { get; }
        decimal Monto { get; }
    }

    public class VentaRegistrada : IMovimientoDiario
    {
        private static int _nextId = 1;
        public int Id { get; }
        public DateTime Fecha { get; }
        public decimal Total { get; }
        public MetodoPago MetodoPago { get; }
        public IReadOnlyList<ItemVenta> Items { get; }
        public string Descripcion => $"Venta - {MetodoPago}";
        public decimal Monto => Total;

        public VentaRegistrada(Venta venta)
        {
            Id = _nextId++;
            Fecha = DateTime.Now;
            Total = venta.Total;
            MetodoPago = venta.MetodoPago;
            Items = new List<ItemVenta>(venta.Items);
        }

        public override string ToString()
        {
            return $"Venta #{Id} - {Fecha:HH:mm:ss} - {MetodoPago} - Total: {Total:C}";
        }
    }

    public class SalidaDinero : IMovimientoDiario
    {
        private static int _nextId = 1;
        public int Id { get; }
        public DateTime Fecha { get; }
        public MotivoSalida Motivo { get; }
        public string Detalle { get; }
        public decimal Importe { get; }
        public string Descripcion => $"{Motivo} - {Detalle}";
        public decimal Monto => -Importe;

        public SalidaDinero(MotivoSalida motivo, string detalle, decimal importe)
        {
            Id = _nextId++;
            Fecha = DateTime.Now;
            Motivo = motivo;
            Detalle = detalle;
            Importe = importe;
        }

        public override string ToString()
        {
            return $"Salida #{Id} - {Fecha:HH:mm:ss} - {Motivo}: {Detalle} - Monto: ({Importe:C})";
        }
    }

    public class ReporteDiario
    {
        private readonly List<IMovimientoDiario> _movimientos = new List<IMovimientoDiario>();
        public IReadOnlyList<IMovimientoDiario> Movimientos => _movimientos;

        public decimal TotalVentas => _movimientos.OfType<VentaRegistrada>().Sum(v => v.Total);
        public decimal TotalSalidas => _movimientos.OfType<SalidaDinero>().Sum(s => s.Importe);
        public decimal TotalCaja => TotalPorMetodoPago(MetodoPago.Efectivo) - TotalSalidas;

        public decimal TotalPorMetodoPago(MetodoPago metodo)
        {
            return _movimientos.OfType<VentaRegistrada>().Where(v => v.MetodoPago == metodo).Sum(v => v.Total);
        }

        public void AgregarMovimiento(IMovimientoDiario movimiento)
        {
            _movimientos.Add(movimiento);
        }

        public void Limpiar()
        {
            _movimientos.Clear();
        }
    }

    public static class ServicioTicket
    {
        public static string GenerarTicket(VentaRegistrada venta)
        {
            var sb = new StringBuilder();
            const int totalWidth = 35;
            const int priceWidth = 14;
            const int nameWidth = totalWidth - priceWidth;

            sb.AppendLine("***********************************");
            sb.AppendLine("****** AnimallForrajería   ******");
            sb.AppendLine("***********************************");
            sb.AppendLine($"Fecha: {venta.Fecha:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine($"Ticket ID: {venta.Id}");
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
            string totalFormateado = venta.Total.ToString("C");
            sb.AppendLine(totalLabel.PadRight(nameWidth) + totalFormateado.PadLeft(priceWidth));
            sb.AppendLine("-----------------------------------");
            sb.AppendLine();
            sb.AppendLine("      ¡Gracias por su compra!      ");
            sb.AppendLine("***********************************");

            return sb.ToString();
        }
    }

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
            XFont fontTotal = new XFont("Arial", 14, XFontStyleEx.Bold);
            XFont fontHeaderTabla = new XFont("Courier New", 10, XFontStyleEx.Bold);

            double yPoint = 40;
            double leftMargin = 40;
            double pageLimit = page.Width.Point - leftMargin;

            gfx.DrawString("Reporte de Movimientos del Día", fontTitulo, XBrushes.Black, new XRect(0, yPoint, page.Width.Point, 0), XStringFormats.TopCenter);
            yPoint += 40;
            gfx.DrawString($"Fecha de Generación: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", new XFont("Arial", 10), XBrushes.Gray, new XRect(0, yPoint, page.Width.Point, 0), XStringFormats.TopCenter);
            yPoint += 40;

            yPoint = DibujarSeccionMovimientos(gfx, "Resumen de Ventas", reporte.Movimientos.OfType<VentaRegistrada>(), yPoint, page, fontSubtitulo, fontHeaderTabla, fontNormal);

            yPoint += 40;
            yPoint = DibujarSeccionMovimientos(gfx, "Resumen de Salidas", reporte.Movimientos.OfType<SalidaDinero>(), yPoint, page, fontSubtitulo, fontHeaderTabla, fontNormal);

            yPoint += 40;
            gfx.DrawLine(XPens.Black, leftMargin, yPoint, pageLimit, yPoint);
            yPoint += 40;

            gfx.DrawString($"TOTAL VENTAS: {reporte.TotalVentas:C}", fontTotal, XBrushes.Black, new XRect(0, yPoint, pageLimit, 0), XStringFormats.TopRight);
            yPoint += 25;
            gfx.DrawString($"TOTAL SALIDAS: {reporte.TotalSalidas:C}", fontTotal, XBrushes.Black, new XRect(0, yPoint, pageLimit, 0), XStringFormats.TopRight);
            yPoint += 25;
            gfx.DrawString($"TOTAL CAJA: {reporte.TotalCaja:C}", fontTotal, XBrushes.Black, new XRect(0, yPoint, pageLimit, 0), XStringFormats.TopRight);

            document.Save(filePath);
        }

        private static double DibujarSeccionMovimientos<T>(XGraphics gfx, string titulo, IEnumerable<T> movimientos, double yPoint, PdfPage page, XFont fontSubtitulo, XFont fontHeader, XFont fontNormal) where T : IMovimientoDiario
        {
            double leftMargin = 40;
            double pageLimit = page.Width.Point - leftMargin;
            double idColX = leftMargin;
            double horaColX = 100;
            double descColX = 220;

            gfx.DrawString(titulo, fontSubtitulo, XBrushes.Black, new XRect(leftMargin, yPoint, 0, 0), XStringFormats.BaseLineLeft);
            yPoint += 20;
            gfx.DrawLine(XPens.Black, leftMargin, yPoint, pageLimit, yPoint);
            yPoint += 20;

            gfx.DrawString("ID", fontHeader, XBrushes.Black, idColX, yPoint);
            gfx.DrawString("Hora", fontHeader, XBrushes.Black, horaColX, yPoint);
            gfx.DrawString("Descripción", fontHeader, XBrushes.Black, descColX, yPoint);
            gfx.DrawString("Monto", fontHeader, XBrushes.Black, new XRect(0, yPoint, pageLimit, 0), XStringFormats.TopRight);
            yPoint += 15;

            if (!movimientos.Any())
            {
                gfx.DrawString("No se registraron movimientos.", fontNormal, XBrushes.Black, leftMargin, yPoint);
                yPoint += 15;
            }
            else
            {
                foreach (var m in movimientos)
                {
                    gfx.DrawString(m.Id.ToString(), fontNormal, XBrushes.Black, idColX, yPoint);
                    gfx.DrawString(m.Fecha.ToString("HH:mm:ss"), fontNormal, XBrushes.Black, horaColX, yPoint);
                    gfx.DrawString(m.Descripcion, fontNormal, XBrushes.Black, descColX, yPoint);
                    gfx.DrawString(m.Monto.ToString("C"), fontNormal, XBrushes.Black, new XRect(0, yPoint, pageLimit, 0), XStringFormats.TopRight);
                    yPoint += 15;
                }
            }
            return yPoint;
        }
    }
}

