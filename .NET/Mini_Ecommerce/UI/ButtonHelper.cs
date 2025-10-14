using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace UI
{
    public static class ButtonHelper
    {
        public static readonly DependencyProperty IconSourceProperty = DependencyProperty.RegisterAttached(
            "IconSource",
            typeof(string),
            typeof(ButtonHelper), 
            new PropertyMetadata(null));

        public static void SetIconSource(UIElement element, string iconSource)
        {
            element.SetValue(IconSourceProperty, iconSource);
        }

        public static string GetIconSource(UIElement element)
        {
            return (string)element.GetValue(IconSourceProperty);
        }

        // This code is for when user hover to button
        public static readonly DependencyProperty HoverIconSourceProperty =
            DependencyProperty.RegisterAttached(
                "HoverIconSource",
                typeof(string),
                typeof(ButtonHelper),
                new PropertyMetadata(null));

        public static void SetHoverIconSource(UIElement element, string value)
        {
            element.SetValue(HoverIconSourceProperty, value);
        }

        public static string GetHoverIconSource(UIElement element)
        {
            return (string)element.GetValue(HoverIconSourceProperty);
        }
    }
}
