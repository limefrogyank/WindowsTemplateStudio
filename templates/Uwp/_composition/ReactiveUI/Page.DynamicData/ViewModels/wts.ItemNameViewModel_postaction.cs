

using Param_ItemNamespace.Services;
namespace Param_ItemNamespace.ViewModels
{
    public class wts.ItemNameViewModel : ReactiveObject
    {

        public wts.ItemNameViewModel()
        {
            compositeDisposable = new CompositeDisposable();
    //{[{

        // Observable to apply dynamic sorting.  When the SortOption changes, sort expression comparer is updated and sent out to observers.
        var sortOptionChanged = this.WhenValueChanged(@this => @this.SortOption)
            .Select(opt =>
            {
                if (opt.headerName == "OrderId")
                {
                    if (opt.sortDirection == DataGridSortDirection.Descending)
                        return SortExpressionComparer<SampleOrder>.Descending(x => x.OrderId);
                    else
                        return SortExpressionComparer<SampleOrder>.Ascending(x => x.OrderId);
                }
                else if (opt.headerName == "OrderDate")
                {
                    if (opt.sortDirection == DataGridSortDirection.Descending)
                        return SortExpressionComparer<SampleOrder>.Descending(x => x.OrderDate);
                    else
                        return SortExpressionComparer<SampleOrder>.Ascending(x => x.OrderDate);
                }
                else if (opt.headerName == "Company")
                {
                    if (opt.sortDirection == DataGridSortDirection.Descending)
                        return SortExpressionComparer<SampleOrder>.Descending(x => x.Company);
                    else
                        return SortExpressionComparer<SampleOrder>.Ascending(x => x.Company);
                }
                else if (opt.headerName == "ShipTo")
                {
                    if (opt.sortDirection == DataGridSortDirection.Descending)
                        return SortExpressionComparer<SampleOrder>.Descending(x => x.ShipTo);
                    else
                        return SortExpressionComparer<SampleOrder>.Ascending(x => x.ShipTo);
                }
                else if (opt.headerName == "OrderTotal")
                {
                    if (opt.sortDirection == DataGridSortDirection.Descending)
                        return SortExpressionComparer<SampleOrder>.Descending(x => x.OrderTotal);
                    else
                        return SortExpressionComparer<SampleOrder>.Ascending(x => x.OrderTotal);
                }
                else if (opt.headerName == "Status")
                {
                    if (opt.sortDirection == DataGridSortDirection.Descending)
                        return SortExpressionComparer<SampleOrder>.Descending(x => x.Status);
                    else
                        return SortExpressionComparer<SampleOrder>.Ascending(x => x.Status);
                }
                else if (opt.headerName == "Symbol")
                {
                    if (opt.sortDirection == DataGridSortDirection.Descending)
                        return SortExpressionComparer<SampleOrder>.Descending(x => x.Symbol);
                    else
                        return SortExpressionComparer<SampleOrder>.Ascending(x => x.Symbol);
                }
                else
                {
                    return SortExpressionComparer<SampleOrder>.Descending(x => x.OrderId);
                }
            });

            // Observable to apply dynamic filtering.  When the FilterText changes, filter predicate is updated and sent out to observers.
            var filterChanged = this.WhenValueChanged(@this => @this.FilterText)
                .Select((txt) =>
                {
                    var trimCaps = txt.Trim().ToUpper();
                    bool Predicate(SampleOrder order)
                    {
                        if (order.ShipTo.ToUpper().Contains(trimCaps) || order.Status.ToUpper().Contains(trimCaps) || order.Company.ToUpper().Contains(trimCaps))
                            return true;
                        else
                            return false;
                    }
                    return (Func<SampleOrder, bool>)Predicate;
                });

        //}]}
        }


    }
}
