﻿
using Param_ItemNamespace.Helpers;
using Param_ItemNamespace.Services;
namespace Param_ItemNamespace.ViewModels
{
    public class wts.ItemNameViewModel : ReactiveObject
    {

        //{[{
        public NavigationServiceEx NavigationService
        {
            get
            {
                return ViewModelLocator.Current.NavigationService;
            }
        }
        //}]}

        //^^
        //{[{
        private void OnsItemSelected(ItemClickEventArgs args)
        {
            var selected = args.ClickedItem as SampleImage;
            _imagesGridView.PrepareConnectedAnimation(wts.ItemNameAnimationOpen, selected, "galleryImage");
            NavigationService.Navigate(typeof(wts.ItemNameDetailViewModel).FullName, selected.ID);
        }
        //}]}
    }
}
