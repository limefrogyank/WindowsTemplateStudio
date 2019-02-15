//{**
// This code block adds the method `GetChartSampleData()` to the SampleDataService of your project.
//**}
//{[{
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
//}]}

namespace Param_ItemNamespace.Services
{
    public static class SampleDataService
    {
//^^
//{[{

        private static int Counter = 1;
        private static Random random = new Random();

        private static string RandomString(int length)
        {
            const string pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var chars = Enumerable.Range(0, length)
                .Select(x => pool[random.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }

        private static IList<string> Statuses = new List<string>() { "Closed", "Shipped", "New" };
        private static IList<char> Symbols = new List<char>() { (char)57643, (char)57737, (char)57620 };


        /// <summary>
        /// Observable that generates a large initial order set and then generates a new order every 5 seconds. 
        /// This Observable never completes and must be DISPOSED manually!
        /// </summary>
        /// <returns></returns>
        public static IObservable<SampleOrder> GetDynamicDataObservable()
        {
            // First, generate 100 orders and send it immediately.
            var initialResult = Observable.Create<SampleOrder>(observer =>
            {
                foreach (var order in GenerateData(100))
                    observer.OnNext(order);

                observer.OnCompleted();

                return Disposable.Empty;
            });

            // For every 5 seconds, generate an order record.
            var timedResults = Observable.Interval(TimeSpan.FromSeconds(5)).Select(interval =>
            {
                var orders = GenerateData(1);
                return orders.Single();
            });

            // Combine the two observables so that the second starts when the first one completes.
            return initialResult.Concat(timedResults);

        }

        private static IEnumerable<SampleOrder> GenerateData(int quantity)
        {
            List<SampleOrder> orders = new List<SampleOrder>();
            for (var i = 0; i < quantity; i++)
            {
                var order = new SampleOrder()
                {
                    OrderId = Counter,
                    Company = $"Company {RandomString(1)}",
                    OrderDate = new DateTime(random.Next(2015, 2018), random.Next(1, 12), random.Next(1, 28)),
                    OrderTotal = random.NextDouble() * 5000,
                    ShipTo = $"Company {RandomString(1)}",
                    Status = Statuses[random.Next(3)],
                    Symbol = Symbols[random.Next(3)]
                };
                orders.Add(order);
                Counter++;
            }
            return orders;
        }
//}]}
    }
}
