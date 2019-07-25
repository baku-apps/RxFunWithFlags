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
    class App2
    {
        public ObservableRangeCollection<Country> Countries { get; set; } = new ObservableRangeCollection<Country>();



        private CancellationTokenSource _cancellationTokenSource;

        private async void CountrySearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            _cancellationTokenSource?.Cancel();

            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;

            try
            {
                await Task.Delay(500, cancellationToken);

                if (cancellationToken.IsCancellationRequested)
                    return;

                var countries = await Task.Run(async () => 
                    await FlagService.GetFlagsTask(e.NewTextValue), cancellationToken);

                if (cancellationToken.IsCancellationRequested)
                    return;

                Device.BeginInvokeOnMainThread(() =>
                    Countries.ReplaceRange(countries));
            }
            catch (OperationCanceledException)
            {
                // we cancelled so do nothing... (ugly!)
            }
        }

    }
}
