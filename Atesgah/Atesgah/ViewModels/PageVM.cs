using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Atesgah.ViewModels
{

    // View Model for Page Type
    public abstract class PageVM<TPage> : BaseViewModel<TPage> where TPage : Page
    {
        protected PageVM(TPage view) : base(view)
        {
        }
    }
}
