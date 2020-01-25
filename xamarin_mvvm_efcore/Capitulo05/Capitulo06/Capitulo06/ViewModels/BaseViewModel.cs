using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo06.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public bool IsBusy { get; set; } = false;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected T SetProperty<T>(T backingStore, T value, Command onChanged = null, [CallerMemberName]string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return backingStore;

            onChanged?.ChangeCanExecute();
            OnPropertyChanged(propertyName);
            return value;
        }

    }
}
