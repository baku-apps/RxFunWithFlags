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
    class App1
    {
        public ObservableRangeCollection<Country> Countries { get; set; } = new ObservableRangeCollection<Country>();



        private CancellationTokenSource _cancellationTokenSource;
        private string searchTerm = string.Empty;


        private async void CountrySearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            await Task.Delay(500);

            var countries = await FlagService.GetFlagsTask(e.NewTextValue);

            Device.BeginInvokeOnMainThread(() =>
                Countries.ReplaceRange(countries));
        }
    }
}
