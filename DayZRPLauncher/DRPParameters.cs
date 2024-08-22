using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayZRPLauncher {
    public class DRPParameters {
        public ObservableCollection<DRPParameter> Params { get; set; }

        public DRPParameters() {
            Params = [
                new() {Label=Constants.MOD_DIRECTORY, Value="Default"},
                new() {Label=Constants.INSTALLATION_DIRECTORY, Value="Default"},
                new() {Label=Constants.API_KEY, Value="Default"},
                new() {Label=Constants.CHARACTER_NAME, Value="Default"},
            ];
        }
    }
}
