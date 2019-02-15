namespace Param_RootNamespace.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            Locator.CurrentMutable.RegisterConstant<NavigationServiceEx>(new NavigationServiceEx());
            //^^
            //{[{
            Register<wts.ItemNameViewModel, wts.ItemNamePage>();
            //}]}
        }

        //{[{
        public wts.ItemNameViewModel wts.ItemNameViewModel => Locator.Current.GetService<wts.ItemNameViewModel>();
        //}]}
    }
}
