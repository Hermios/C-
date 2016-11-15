using System;
using System.Windows;

namespace StandardTools.ViewHandler
{
    public class WindowHandler
    {
        public static void OpenWindow<T>(ViewModelBase viewModelBase,bool asyncShow) where T : Window
        {
            T view = (T)Activator.CreateInstance(typeof(T));
            view.DataContext = viewModelBase;
            if (asyncShow) view.Show();
            else view.ShowDialog();
        }
    }
}
