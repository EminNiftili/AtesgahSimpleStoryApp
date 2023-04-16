using Atesgah.Commands;
using Atesgah.Commands.WelcomePageCommands;
using Atesgah.Views;

namespace Atesgah.ViewModels.Implement
{
    // Welcome View Model or WelcomeVM
    public class WelcomeVM : PageVM<WelcomePage>
    {
        public WelcomeVM() : base(new WelcomePage())
        {
            View.BindingContext = this;
        }

        public BaseCommand GoToStoryPage => new GoToStoryPageCommand();
    }
}
