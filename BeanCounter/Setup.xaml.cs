using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BeanCounter.Model;

namespace BeanCounter
{
    public partial class Setup : PhoneApplicationPage
    {
        public Setup()
        {
            InitializeComponent();

            this.DataContext = App.ViewModel;
        }

        private void appBarOkButton_Click(object sender, EventArgs e)
        {
            // Confirm there is some text in the text box.
            if (beanCountTextBox.Text.Length > 0)
            {
                // Update bucket item in the ViewModel.
                App.ViewModel.UpdateBucket("food drink", Convert.ToInt32(beanCountTextBox.Text));                

                // Return to the main page.
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
            }
        }

        private void appBarCancelButton_Click(object sender, EventArgs e)
        {
            // Return to the main page.
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}