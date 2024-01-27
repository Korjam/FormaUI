using System.Windows.Controls;

namespace FormaUI;

public static class FrameExtensions
{
    public static void NavigateToType(this Frame frame, Type type) => frame.Navigate(Activator.CreateInstance(type));
}
