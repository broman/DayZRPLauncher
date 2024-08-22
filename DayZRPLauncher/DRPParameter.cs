/**
 * DRPParameter.cs
 * Observable parameter for k/v storage
 * Ryan Broman
 * 2024-08-21
 */

using System.ComponentModel;

namespace DayZRPLauncher {
    public class DRPParameter: INotifyPropertyChanged {
        public object? _value;
        public required string Label { get; set; }
        public Object Value {
            get => _value ?? "";
            set {
                if (!Equals(value, _value)) {
                    _value = value;
                    OnPropertyChanged(nameof(Value));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
