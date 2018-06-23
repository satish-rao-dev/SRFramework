using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SRFramework.WPF.MVVM
{
    public class DockedWindow: Window
    {
        public bool IsDocked
        {
            get { return (bool)GetValue(IsDockedProperty); }
            set { SetValue(IsDockedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDocked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDockedProperty =
            DependencyProperty.Register("IsDocked", typeof(bool), typeof(Window), new PropertyMetadata(false, IsDockedChanged));

        private static void IsDockedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DockedWindow mainWin = d as DockedWindow;
            if (mainWin.IsDocked)
            {
                mainWin.Top = 0;
                mainWin.Left = SystemParameters.PrimaryScreenWidth - mainWin.ActualWidth;
            }

        }

    }
}
