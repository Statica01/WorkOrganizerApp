﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkOrganizerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public async void NavigateToDashboardPage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DashboardPage());
        }
    }
}