using MvvmHelpers;
using RxFunWithFlags.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RxFunWithFlags.Demo
{
    class App_final
    {
        public ObservableRangeCollection<Country> Countries { get; set; } = new ObservableRangeCollection<Country>();



        private CancellationTokenSource _cancellationTokenSource;
        private string searchTerm = string.Empty;

        //Source: https://byteloom.marek-mierzwa.com/mobile/2018/06/18/search-as-you-type-in-xamarin-forms.html

        private async void CountrySearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            _cancellationTokenSource?.Cancel();

            if (e.NewTextValue.Length < 3 && searchTerm == e.NewTextValue)
                return;

            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;

            try
            {
                await Task.Delay(500, cancellationToken);

                searchTerm = e.NewTextValue;

                if (cancellationToken.IsCancellationRequested)
                    return;

                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(30), cancellationToken);
                var countriesTask = Task.Run(async () => await FlagService.GetFlagsTask(e.NewTextValue),
                    cancellationToken);

                if (await Task.WhenAny(countriesTask, timeoutTask) == timeoutTask)
                    throw new TimeoutException();

                if (cancellationToken.IsCancellationRequested)
                    return;

                var countries = await countriesTask;

                Device.BeginInvokeOnMainThread(() =>
                    Countries.ReplaceRange(countries));
            }
            catch (OperationCanceledException)
            {
                // we cancelled so do nothing... (ugly!)
            }
            catch (TimeoutException timeoutEx)
            {
                //Handle timeout here...
                Console.WriteLine("Timeout!");
            }
        }

    }
}
