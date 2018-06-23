using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SRFramework.WPF.MVVM
{
    public enum DockType
    {
        None=0,
        TopLeft,TopMiddle,TopRight,
        LeftMiddle,
        BottomLeft,BottomMiddle,BottomRight,
        RightMiddle,
    }
    public class DockedMetroWindow: MetroWindow
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
            ChangeDocking(d as DockedMetroWindow, (bool)e.NewValue);

        }



        public DockType DockingType
        {
            get { return (DockType)GetValue(DockingTypeProperty); }
            set { SetValue(DockingTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DockingType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DockingTypeProperty =
            DependencyProperty.Register("DockingType", typeof(DockType), typeof(DockedMetroWindow), new PropertyMetadata(DockType.TopLeft, DocTypeChanged));

        private static void DocTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ChangeDocking(d as DockedMetroWindow,(DockType)e.OldValue,(DockType)e.NewValue);
        }



        private static void ChangeDocking(DockedMetroWindow dockWindow, DockType oldValue, DockType newValue)
        {
            if(dockWindow != null && dockWindow.IsDocked)
            {
                SetDocking(dockWindow, newValue);
            }
        }


        private static void ChangeDocking(DockedMetroWindow dockWindow, bool isDocked)
        {

            if (dockWindow != null && dockWindow.IsDocked)
            {
                SetDocking(dockWindow, dockWindow.DockingType);
            }
        }


        private static void SetDocking(DockedMetroWindow dockWindow, DockType docType)
        {
            switch (dockWindow.DockingType)
            {
                case DockType.TopLeft:
                    SetDockingLeftTop(dockWindow);
                    break;
                case DockType.BottomRight:
                    SetDockingBottomRight(dockWindow);
                    break;
                case DockType.BottomLeft:
                    SetDockingBottomLeft(dockWindow);
                    break;
            }
        }

        private static void SetDockingBottomLeft(DockedMetroWindow dockWindow)
        {
            dockWindow.Top = SystemParameters.PrimaryScreenHeight - dockWindow.ActualHeight;
            dockWindow.Left = 0;
        }

        private static void SetDockingBottomRight(DockedMetroWindow dockWindow)
        {
            dockWindow.Top = SystemParameters.PrimaryScreenHeight - dockWindow.ActualHeight;
            dockWindow.Left = SystemParameters.PrimaryScreenWidth - dockWindow.ActualWidth;
        }

        private static void SetDockingLeftTop(DockedMetroWindow dockWindow)
        {
            dockWindow.Top = 0;
            dockWindow.Left = SystemParameters.PrimaryScreenWidth - dockWindow.ActualWidth;
        }
    }
}
