using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Atesgah.ViewModels
{

    // asbtract BaseViewModel
    public abstract class BaseViewModel<TView> : INotifyPropertyChanged
    {
        public BaseViewModel(TView view)
        {
            View = view;
        }

        public TView View { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        protected void PropertyChange(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
