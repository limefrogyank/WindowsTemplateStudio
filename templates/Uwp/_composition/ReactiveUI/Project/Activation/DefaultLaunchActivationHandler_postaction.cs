namespace Param_RootNamespace.Activation
{
    internal class DefaultLaunchActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
    {
//{[{
        private readonly string _navElement;

        private NavigationServiceEx NavigationService
        {
            get
            {
                return ViewModels.ViewModelLocator.Current.NavigationService;
            }
        }

        public DefaultLaunchActivationHandler(Type navElement)
        {
            _navElement = navElement.FullName;
        }

//}]}
    }
}
