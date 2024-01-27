using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FormaUI.Controls;

public class NavigationView : ContentControl
{
    static NavigationView()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationView), new FrameworkPropertyMetadata(typeof(NavigationView)));
    }

    //private static readonly DependencyPropertyKey MenuItemsPropertyKey = DependencyProperty.RegisterReadOnly(
    //    nameof(MenuItems),
    //    typeof(IList<NavigationViewItemBase>),
    //    typeof(NavigationView),
    //    new PropertyMetadata(null));
    //public static readonly DependencyProperty MenuItemsProperty = MenuItemsPropertyKey.DependencyProperty;

    //public IList<NavigationViewItemBase> MenuItems
    //{
    //    get => (IList<NavigationViewItemBase>)GetValue(MenuItemsProperty);
    //    set => SetValue(MenuItemsPropertyKey, value);
    //}

    public ObservableCollection<NavigationViewItemBase> MenuItems { get; }

    public NavigationView()
    {
        MenuItems = new ObservableCollection<NavigationViewItemBase>();
    }

    public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
        nameof(SelectedItem),
        typeof(NavigationViewItemBase),
        typeof(NavigationView),
        new FrameworkPropertyMetadata(null, OnSelectedItemChanged));

    public NavigationViewItemBase? SelectedItem
    {
        get => (NavigationViewItemBase?)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((NavigationView)d).OnSelectedItemChanged((NavigationViewItemBase?)e.NewValue);
    }

    private void OnSelectedItemChanged(NavigationViewItemBase? newValue)
    {
        if (ContentElement is null)
        {
            return;
        }

        if (newValue is not NavigationViewItem item)
        {
            return;
        }

        if (item.NavigationType is not null)
        {
            ContentElement.NavigateToType(item.NavigationType);
        }
    }

    public static readonly DependencyProperty ContentElementProperty = DependencyProperty.Register(
        nameof(ContentElement),
        typeof(Frame),
        typeof(NavigationView),
        new PropertyMetadata(null));

    public Frame? ContentElement
    {
        get => (Frame?)GetValue(ContentElementProperty);
        set => SetValue(ContentElementProperty, value);
    }

    public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register(
        nameof(IsOpen),
        typeof(bool),
        typeof(NavigationView),
        new PropertyMetadata(true));

    public bool IsOpen
    {
        get => (bool)GetValue(IsOpenProperty);
        set => SetValue(IsOpenProperty, value);
    }
}
