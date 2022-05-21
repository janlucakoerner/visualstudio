using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashsystem.Forms
{
    internal class FormSingleton
    {
        private static FormStart? formStart;
        private static FormCashSystem? formCashSystem;
        private static FormSingleton? formSingelton;

        private FormSingleton()
        {
            // Create from every form one instance
            formStart = new FormStart();
            formCashSystem = new FormCashSystem();

            // Hide all other instances
            formCashSystem.Hide();
        }
        #pragma warning disable CS8603 // Mögliche Nullverweisrückgabe.
        public static FormSingleton GetInstance()
        {
            if (formStart == null &&
                formCashSystem == null) formSingelton = new FormSingleton();
            return formSingelton;  
        }
        public FormStart FormStart
        {
            get { return formStart; }
            private set { formStart = value; }
        }
        public FormCashSystem FormCashSystem
        {
            get { return formCashSystem; }
            private set { formCashSystem = value; }
        }
        #pragma warning restore CS8603 // Mögliche Nullverweisrückgabe.
    }
}
