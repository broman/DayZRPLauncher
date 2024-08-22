/**
 * Parameters.xaml.cs
 * Interaction logic for the Parameters window
 * Ryan Broman <ryan@broman.dev>
 * 2024-08-21
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.IO;

using Microsoft.Win32;

namespace DayZRPLauncher {
    public partial class Parameters: Window {
        public Parameters() {
            InitializeComponent();
            DataContext = MainWindow.parameters;
        }

        private void LocateDayZButton_Click(object sender, RoutedEventArgs e) {
            // try to locate DayZ installation directory
            var key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
            string path = "";
            if(key != null) {
                path = key.GetValue("SteamPath") as string;
            } else {
                throw new NotSupportedException();
            }



            var viewModel = (DRPParameters)DataContext;
            var textBox = viewModel.Params.FirstOrDefault(x => x.Label == Constants.INSTALLATION_DIRECTORY);
            if(textBox != null) {
                // GetFullPath prevents issues between forward and backslash          
                textBox.Value = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, "steamapps/common/dayz"));
            }

            textBox = viewModel.Params.FirstOrDefault(x => x.Label == Constants.MOD_DIRECTORY);
            if(textBox != null) {
                textBox.Value = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, "steamapps/workshop/content/21100"));
            }
        }
    }
}
