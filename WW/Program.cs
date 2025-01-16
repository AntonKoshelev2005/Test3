using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WW
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Обработка глобального события выхода из приложения
            Application.ApplicationExit += new EventHandler(OnApplicationExit);

            Application.Run(new Log());
        }

        static void OnApplicationExit(object sender, EventArgs e)
        {
            // Показать подтверждение только один раз при выходе из приложения
            DialogResult result = MessageBox.Show("Вы точно хотите выйти?", "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                // Прерываем процесс выхода
                Application.ExitThread();
            }
        }
    }
}
