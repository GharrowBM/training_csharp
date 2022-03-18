﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXO_01
{
    public partial class App : Application
    {
        public static string DatabaseLocation;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaseLocation)
        {
            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
