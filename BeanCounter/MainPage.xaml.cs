using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BeanCounter.Resources;
using BeanCounter.Model;
using BeanCounter.ViewModel;

namespace BeanCounter
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the page DataContext property to the ViewModel.
            this.DataContext = App.ViewModel;

            PopulateBeanCount();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            PopulateBeanCount();
        }


        private void bean_1_Click(object sender, RoutedEventArgs e)
        {
            App.ViewModel.RemoveBeansFromBucket("food drink", 1);
            PopulateBeanCount();
        }

        private void bean_3_Click(object sender, RoutedEventArgs e)
        {
            App.ViewModel.RemoveBeansFromBucket("food drink", 3);
            PopulateBeanCount();
        }

        private void bean_5_Click(object sender, RoutedEventArgs e)
        {
            App.ViewModel.RemoveBeansFromBucket("food drink", 5);
            PopulateBeanCount();
        }

        private void bean_10_Click(object sender, RoutedEventArgs e)
        {
            App.ViewModel.RemoveBeansFromBucket("food drink", 10);
            PopulateBeanCount();
        }

        private void bean_custom_Click(object sender, RoutedEventArgs e)
        {
            App.ViewModel.RemoveBeansFromBucket("food drink", 100);
            PopulateBeanCount();
        }

        private void setupAppBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Setup.xaml", UriKind.Relative));
        }

        private void PopulateBeanCount()
        {
            int beanCount = App.ViewModel.GetBucketBeanCount("food drink");
            this.remaining_beans.Text = String.Format("remaining beans {0}", beanCount);
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}