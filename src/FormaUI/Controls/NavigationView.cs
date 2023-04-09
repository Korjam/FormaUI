using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace FormaUI.Controls;

[TemplatePart(Name = MenuItemsPart, Type = typeof(Selector))]
[TemplatePart(Name = FooterItemsPart, Type = typeof(Selector))]
public class NavigationView : ContentControl
{
    private const string MenuItemsPart = "PART_MenuItems";
    private const string FooterItemsPart = "PART_FooterItems";

    static NavigationView()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationView), new FrameworkPropertyMetadata(typeof(NavigationView)));
    }

    public ObservableCollection<NavigationViewItemBase> MenuItems { get; }
    public ObservableCollection<NavigationViewItemBase> FooterItems { get; }

    public NavigationView()
    {
        MenuItems = new ObservableCollection<NavigationViewItemBase>();
        FooterItems = new ObservableCollection<NavigationViewItemBase>();
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

    private Selector? _menuItemsList;
    private Selector? _footerItemsList;

    private bool _suppressSelectionEvent = false;

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        _menuItemsList = (Selector)GetTemplateChild(MenuItemsPart);
        _footerItemsList = (Selector)GetTemplateChild(FooterItemsPart);

        _menuItemsList.SetCurrentValue(ItemsControl.ItemsSourceProperty, MenuItems);
        _footerItemsList.SetCurrentValue(ItemsControl.ItemsSourceProperty, FooterItems);

        _menuItemsList.SelectionChanged += MenuItemsList_SelectionChanged;
        _footerItemsList.SelectionChanged += FooterItemsList_SelectionChanged;
    }

    private void MenuItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_suppressSelectionEvent)
        {
            return;
        }
        
        _suppressSelectionEvent = true;

        SetCurrentValue(SelectedItemProperty, (NavigationViewItem)_menuItemsList.SelectedItem);
        _footerItemsList.SetCurrentValue(Selector.SelectedItemProperty, null);

        _suppressSelectionEvent = false;
    }

    private void FooterItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_suppressSelectionEvent)
        {
            return;
        }

        _suppressSelectionEvent = true;

        SetCurrentValue(SelectedItemProperty, (NavigationViewItem)_footerItemsList.SelectedItem);
        _menuItemsList.SetCurrentValue(Selector.SelectedItemProperty, null);

        _suppressSelectionEvent = false;
    }
}
