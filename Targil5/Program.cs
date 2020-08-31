using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Targil5
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StartGame();
        }

        public static void StartGame()
        {
            int row, col;
            string nameOfFirst, nameOfSecond;
            eGameType gameType;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormReg form = new FormReg();
            form.ShowDialog();
            form.GetEnteredInfo(out row, out col, out nameOfFirst, out nameOfSecond, out gameType);
            MemoryGameForm memoryGameForm = new MemoryGameForm(row, col, nameOfFirst, nameOfSecond, gameType);
            memoryGameForm.ShowDialog();
        }
    }
}
