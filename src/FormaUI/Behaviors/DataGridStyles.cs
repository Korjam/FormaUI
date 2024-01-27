using System.Windows;

namespace FormaUI.Behaviors;

public static class DataGridStyles
{
    public static ComponentResourceKey TextBoxStyleKey =
        new(typeof(DataGridStyles), nameof(TextBoxStyleKey));
    public static ComponentResourceKey TextBoxEditingStyleKey =
        new(typeof(DataGridStyles), nameof(TextBoxEditingStyleKey));

    public static ComponentResourceKey ComboBoxStyleKey =
        new(typeof(DataGridStyles), nameof(ComboBoxStyleKey));
    public static ComponentResourceKey ComboBoxEditingStyleKey =
        new(typeof(DataGridStyles), nameof(ComboBoxEditingStyleKey));

    public static ComponentResourceKey CheckBoxStyleKey =
        new(typeof(DataGridStyles), nameof(CheckBoxStyleKey));
    public static ComponentResourceKey CheckBoxEditingStyleKey =
        new(typeof(DataGridStyles), nameof(CheckBoxEditingStyleKey));
}
