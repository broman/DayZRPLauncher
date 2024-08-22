/**
 * MainWindow.xaml.cs
 * Interaction logic for MainWindow
 * Ryan Broman <ryan@broman.dev>
 * 2024-08-21
 */

using System.Windows;

namespace DayZRPLauncher {
    public partial class MainWindow {
        public static DRPParameters parameters { get; private set; } = new DRPParameters();
        public MainWindow() {
            InitializeComponent();
        }

        private void ParametersMenu_Click(object sender, RoutedEventArgs e) {
            var parameterModal = new Parameters {
                Owner = this
            };
            parameterModal.ShowDialog();
        }

        private void ValidateButton_Click(object sender, RoutedEventArgs e) {
            SteamController.Instance.VerifyMods();
        }
    }
}