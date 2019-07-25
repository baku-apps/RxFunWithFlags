using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace RxFunWithFlags.Demo
{
    class GoodDemo
    {
        public GoodDemo()
        {
            /*
             * 
             * 
            Observable
                .FromEventPattern<TextChangedEventArgs>(
                    h => SearchEntry.TextChanged += h,
                    h => SearchEntry.TextChanged -= h)
                .Select(_ => SearchEntry.Text)
                .StartWith(SearchEntry.Text)
                .Where(search => search.Length > 1)
                .Throttle(TimeSpan.FromMilliseconds(500))
                .DistinctUntilChanged()
                .Select(term => FlagService.GetFlagsTask(term)
                    .ToObservable()
                    .Timeout(TimeSpan.FromSeconds(2)))
                .Switch()
                .Take(15)
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(results =>
                {
                    Countries.ReplaceRange(results);
                });


            Observable
                .FromEventPattern<TextChangedEventArgs>(
                    h => SearchEntry.TextChanged += h,
                    h => SearchEntry.TextChanged -= h)
                .Select(_ => SearchEntry.Text)
                .Where(search => search.Length > 1)
                .Throttle(TimeSpan.FromMilliseconds(500))
                .DistinctUntilChanged()
                .Select(term => FlagService.GetFlagsTask(term))
                .Switch()
                .Take(15)
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(results => Countries.ReplaceRange(results));
             
            */
        }
    }
}
