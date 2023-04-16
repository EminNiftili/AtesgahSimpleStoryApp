using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Atesgah.ViewModels
{

    // View Model for All Content View type
    public abstract class ViewVM<TView,TParent> : BaseViewModel<TView> where TView : ContentView where TParent : Page
    {
        public TParent Parent;
        protected ViewVM(TView view, TParent parentPage) : base(view)
        {
            Parent = parentPage;
        }
    }
}
