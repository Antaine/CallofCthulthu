using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CallofCthulthu.Models;
using CallofCthulthu.ViewModels;

namespace CallofCthulthu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Name = "Quaff",
                Player = "Rex"
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        Random dice = new Random();

        //D100 Roll
        private void RollD100(object sender, EventArgs e)
        {
            int d100 = dice.Next(1, 101);
            D100.Text = d100.ToString();
            
        }
        //D10 Roll
        private void RollD10(object sender, EventArgs e)
        {
            int d10 = dice.Next(1, 11);
            D10.Text = d10.ToString();

        }
        //D6 Roll
        private void RollD6(object sender, EventArgs e)
        {
            int d6 = dice.Next(1, 7);
            D6.Text = d6.ToString();

        }
    }
}