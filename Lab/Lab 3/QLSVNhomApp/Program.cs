﻿using System;
using System.Windows.Forms;
using QLSVNhomApp.Forms;

namespace QLSVNhomApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
