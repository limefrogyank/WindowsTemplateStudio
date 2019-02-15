//{[{
using Param_ItemNamespace.ViewModels;
using Windows.UI.Xaml.Navigation;
//}]}
namespace Param_ItemNamespace.Views
{
    public sealed partial class wts.ItemNamePage : Page
    {
        //{[{
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            ViewModel.Dispose();
        }

    //}]}
}
}
