﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NEXP.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        private DateTime downTime;
        private object downSender;
        private Point downPosition;

        public Home()
        {
            InitializeComponent();
        }

        private void OpaqueClickableImage_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.downSender = sender;
                this.downTime = DateTime.Now;
                this.downPosition = e.GetPosition(sender as Image);
            }
        }

        private void OpaqueClickableImage_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released && sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {
                    //MessageBox.Show("Image Click");
                    NavigationCommands.GoToPage.Execute("/Pages/Test.xaml", this);   // http://mui.codeplex.com/discussions/434905
                }
            }
        }
    }
}
