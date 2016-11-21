using System.Windows;

namespace StandardTools.ViewHandler
{
    public class WindowCloseBehaviour
    {
        public static void SetCloseWindow(DependencyObject target, bool value)
        {
            target.SetValue(CloseProperty, value);
        }
        public static DependencyProperty CloseProperty =
        DependencyProperty.RegisterAttached(
        "CloseWindow",
        typeof(bool),
        typeof(WindowCloseBehaviour),
        new UIPropertyMetadata(false, OnCloseWindow));

        public static bool GetCloseWindow(DependencyObject obj)
        {
            return (bool)obj.GetValue(CloseProperty);
        }

        private static void OnCloseWindow(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool && ((bool)e.NewValue))
            {
                Window window = GetWindow(sender);
                if (window != null)
                    window.Close();
            }
        }
        private static Window GetWindow(DependencyObject sender)
        {
            Window window = null;
            if (sender is Window)
                window = (Window)sender;
            if (window == null)
                window = Window.GetWindow(sender);
            return window;
        }
    }
}
