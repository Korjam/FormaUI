using Microsoft.Xaml.Behaviors;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace FormaUI.Behaviors;

public sealed class DataGridFluentStylesBehavior : Behavior<DataGrid>
{
    protected override void OnAttached()
    {
        base.OnAttached();

        AssociatedObject.Columns.CollectionChanged += OnColumnsCollectionChanged;

        foreach (var column in AssociatedObject.Columns)
        {
            SetColumnStyles(column);
        }
    }

    protected override void OnDetaching()
    {
        AssociatedObject.Columns.CollectionChanged -= OnColumnsCollectionChanged;

        base.OnDetaching();
    }

    private void OnColumnsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                foreach (var column in e.NewItems!.OfType<DataGridColumn>())
                {
                    SetColumnStyles(column);
                }
                break;
            case NotifyCollectionChangedAction.Replace:
                foreach (var column in e.NewItems!.OfType<DataGridColumn>())
                {
                    SetColumnStyles(column);
                }
                break;
            case NotifyCollectionChangedAction.Remove:
            case NotifyCollectionChangedAction.Move:
            case NotifyCollectionChangedAction.Reset:
            default:
                break;
        }
    }

    private void SetColumnStyles(DataGridColumn column)
    {
        switch (column)
        {
            case DataGridTextColumn textColumn:
                textColumn.EditingElementStyle = (Style)AssociatedObject.FindResource(DataGridStyles.TextBoxEditingStyleKey);
                textColumn.ElementStyle = (Style)AssociatedObject.FindResource(DataGridStyles.TextBoxStyleKey);
                break;
            case DataGridComboBoxColumn comboBoxColumn:
                comboBoxColumn.EditingElementStyle = (Style)AssociatedObject.FindResource(DataGridStyles.ComboBoxEditingStyleKey);
                comboBoxColumn.ElementStyle = (Style)AssociatedObject.FindResource(DataGridStyles.ComboBoxStyleKey);
                break;
            case DataGridCheckBoxColumn checkBoxColumn:
                checkBoxColumn.EditingElementStyle = (Style)AssociatedObject.FindResource(DataGridStyles.CheckBoxEditingStyleKey);
                checkBoxColumn.ElementStyle = (Style)AssociatedObject.FindResource(DataGridStyles.CheckBoxStyleKey);
                break;
            case DataGridHyperlinkColumn hyperlinkColumn:
                hyperlinkColumn.EditingElementStyle = (Style)AssociatedObject.FindResource(DataGridStyles.TextBoxEditingStyleKey);
                hyperlinkColumn.ElementStyle = (Style)AssociatedObject.FindResource(DataGridStyles.TextBoxStyleKey);
                break;
            default:
                break;
        }
    }
}
