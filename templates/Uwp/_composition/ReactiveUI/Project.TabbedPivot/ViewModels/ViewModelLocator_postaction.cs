namespace Param_RootNamespace.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
//^^
//{[{
            RegisterConstant<PivotViewModel, PivotPage>();
//}]}
        }

//{[{
        public PivotViewModel PivotViewModel => Locator.Current.GetService<PivotViewModel>();
//}]}
    }
}
