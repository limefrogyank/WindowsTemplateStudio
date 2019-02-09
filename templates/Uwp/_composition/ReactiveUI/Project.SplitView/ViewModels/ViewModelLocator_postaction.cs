namespace Param_RootNamespace.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            //^^
            //{[{
            Locator.CurrentMutable.RegisterConstant<ShellViewModel>(new ShellViewModel());
            //}]}
        }

//{[{
        public ShellViewModel ShellViewModel => Locator.Current.GetService<ShellViewModel>(); 
//}]}
    }
}
