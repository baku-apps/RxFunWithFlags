using Newtonsoft.Json;
using RxFunWithFlags.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmHelpers;
using System.Threading;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace RxFunWithFlags
{
    /// <summary>
    /// Flag Service which fetches the flags from the api
    /// </summary>
    public class FlagService
    {
        static readonly HttpClient client = new HttpClient();
        static readonly string baseFlagsUrl = "https://restcountries.eu/rest/v2/name/";

        public static async Task<List<Country>> GetFlagsTask(string searchText)
        {
            var response = await client.GetAsync(baseFlagsUrl + searchText);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Country>>(json);
                return result;
            }

            return new List<Country>();
        }
    }



    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableRangeCollection<Country> Countries { get; set; } = 
            new ObservableRangeCollection<Country>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SearchEntry.TextChanged += CountrySearch_TextChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SearchEntry.TextChanged -= CountrySearch_TextChanged;
        }

        private async void CountrySearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var countries = await FlagService.GetFlagsTask(e.NewTextValue);

            Device.BeginInvokeOnMainThread(() =>
                    Countries.ReplaceRange(countries));
        }


    }
}
