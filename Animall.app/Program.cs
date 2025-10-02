using System;
using System.Windows.Forms;

// --- Corregido aqu�: de "App" a "app" ---
namespace Animall.app
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            decimal dineroInicial = 0;
            using (var formDineroInicial = new DineroInicialForm())
            {
                if (formDineroInicial.ShowDialog() == DialogResult.OK)
                {
                    dineroInicial = formDineroInicial.DineroInicial;
                }
                else
                {
                    // Si el usuario cierra el formulario de dinero inicial, se cierra la aplicaci�n.
                    return;
                }
            }

            // Ahora 'Form1' ser� encontrado porque est� en el mismo namespace.
            Application.Run(new Form1(dineroInicial));
        }
    }
}
