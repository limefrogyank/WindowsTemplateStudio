using DynamicData;
using DynamicData.Binding;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Param_ItemNamespace.Models;
using Param_ItemNamespace.Services;

namespace Param_ItemNamespace.ViewModels
{
    public class DynamicDataViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        private readonly CompositeDisposable compositeDisposable;

        private string filterText = "";
        public string FilterText
        {
            get => filterText;
            set => Param_Setter(ref filterText, value);
        }

        private (string headerName, DataGridSortDirection? sortDirection) sortOption;
        public (string headerName, DataGridSortDirection? sortDirection) SortOption
        {
            get => sortOption;
            set => Param_Setter(ref sortOption, value);
        }

        // Load all data that contain a unique key into the SourceCache.  Data that doesn't have a unique key can use SourceList instead.
        private SourceCache<SampleOrder, long> orderCache = new SourceCache<SampleOrder, long>(x => x.OrderId);

        // You can pass the public IObservableCache to other classes so that they cannot modify the data within, just manipulate it.  (unused for now)
        public IObservableCache<SampleOrder, long> OrderCache => orderCache.AsObservableCache();

        // Required for binding to XAML controls.  This is just a projection of the underlying data.
        private ReadOnlyObservableCollection<SampleOrder> orders;
        public ReadOnlyObservableCollection<SampleOrder> Orders => orders;

        public DynamicDataViewModel()
        {
            compositeDisposable = new CompositeDisposable();

            

            // Connect to the source data, apply any filtering and/or sorting, and bind results to a readonly observable.
            orderCache.Connect()
                .Filter(filterChanged)
                .Sort(sortOptionChanged)
                .Bind(out orders)
                .Subscribe()
                .DisposeWith(compositeDisposable);


            // Load initial data and receive new data every 5 seconds.  Must be disposed manually since observable never completes.
            SampleDataService.GetDynamicDataObservable()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(order =>
                {
                    orderCache.AddOrUpdate(order);
                })
                .DisposeWith(compositeDisposable);
        }

        public void Dispose()
        {
            // All subscriptions are disposed here in one convenient disposable.
            compositeDisposable.Dispose();
        }
    }
}
