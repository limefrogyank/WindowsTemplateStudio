﻿//{**
//This code block adds the logic to handle SettingsItem in NavigationView control from ViewModel.
//**}
using ReactiveUI;
using Param_ItemNamespace.Views;
namespace Param_ItemNamespace.ViewModels
{
    public class ShellViewModel : ReactiveObject
    {
        private void OnItemInvoked(NavigationViewItemInvokedEventArgs args)
        {
            //{[{
            if (args.IsSettingsInvoked)
            {
                NavigationService.Navigate(typeof(wts.ItemNameViewModel).FullName);
                return;
            }

            //}]}
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            //{[{
            if (e.SourcePageType == typeof(wts.ItemNamePage))
            {
                Selected = _navigationView.SettingsItem as NavigationViewItem;
                return;
            }

            //}]}
        }
    }
}
