using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DistributionApp.Utilities
{
    public sealed class Utils
    {
        private static Utils instance = null;

        public static Utils Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Utils();
                }
                return instance;
            }
        }


        public Window GetMainWindowView()
        {
            return Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        }

    }
}
