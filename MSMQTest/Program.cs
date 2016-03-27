using System;
using System.Windows.Forms;

namespace MSMQTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public struct Payment
        {
            public string Payor, Payee;
            public int Amount;
            public string DueDate;
        }

        public struct MessageData
        {
            public string Message, Queue;
            public int testNum;
        }
    }
}
