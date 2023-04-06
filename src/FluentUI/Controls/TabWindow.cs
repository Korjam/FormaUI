using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace FluentUI.Controls;

public class TabWindow : FluentWindow
{
    public static readonly DependencyProperty TabItemsProperty =
        DependencyProperty.Register(
            nameof(TabItems),
            typeof(ObservableCollection<TabItem>),
            typeof(TabWindow),
            new FrameworkPropertyMetadata(new ObservableCollection<TabItem>()));
    public ObservableCollection<TabItem> TabItems => (ObservableCollection<TabItem>)GetValue(TabItemsProperty);

    static TabWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(TabWindow), new FrameworkPropertyMetadata(typeof(TabWindow)));
    }

    public TabWindow()
    {
        SetResourceReference(StyleProperty, typeof(TabWindow));
    }

    private static readonly DependencyPropertyKey SelectedContentPropertyKey =
        DependencyProperty.RegisterReadOnly("SelectedContent",
            typeof(object),
            typeof(TabWindow),
            new FrameworkPropertyMetadata(null));

    /// <summary>
    ///     The DependencyProperty for the SelectedContent property.
    ///     Flags:              None
    ///     Default Value:      null
    /// </summary>
    public static readonly DependencyProperty SelectedContentProperty = SelectedContentPropertyKey.DependencyProperty;

    /// <summary>
    ///     SelectedContent is the Content of current SelectedItem.
    /// This property is updated whenever the selection is changed.
    /// It always keeps a reference to active TabItem.Content
    /// Used for aliasing in default TabWindow Style
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object SelectedContent
    {
        get => GetValue(SelectedContentProperty);
        internal set => SetValue(SelectedContentPropertyKey, value);
    }

    private static readonly DependencyPropertyKey SelectedContentTemplatePropertyKey =
        DependencyProperty.RegisterReadOnly("SelectedContentTemplate",
            typeof(DataTemplate),
            typeof(TabWindow),
            new FrameworkPropertyMetadata(null));

    /// <summary>
    ///     The DependencyProperty for the SelectedContentTemplate property.
    ///     Flags:              None
    ///     Default Value:      null
    /// </summary>
    public static readonly DependencyProperty SelectedContentTemplateProperty = SelectedContentTemplatePropertyKey.DependencyProperty;

    /// <summary>
    ///     SelectedContentTemplate is the ContentTemplate of current SelectedItem.
    /// This property is updated whenever the selection is changed.
    /// It always keeps a reference to active TabItem.ContentTemplate
    /// It is used for aliasing in default TabWindow Style
    /// </summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataTemplate SelectedContentTemplate
    {
        get => (DataTemplate)GetValue(SelectedContentTemplateProperty);
        internal set => SetValue(SelectedContentTemplatePropertyKey, value);
    }

    private static readonly DependencyPropertyKey SelectedContentTemplateSelectorPropertyKey =
        DependencyProperty.RegisterReadOnly("SelectedContentTemplateSelector",
            typeof(DataTemplateSelector),
            typeof(TabWindow),
            new FrameworkPropertyMetadata(null));

    /// <summary>
    ///     The DependencyProperty for the SelectedContentTemplateSelector property.
    ///     Flags:              None
    ///     Default Value:      null
    /// </summary>
    public static readonly DependencyProperty SelectedContentTemplateSelectorProperty = SelectedContentTemplateSelectorPropertyKey.DependencyProperty;

    /// <summary>
    ///     SelectedContentTemplateSelector allows the app writer to provide custom style selection logic.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DataTemplateSelector SelectedContentTemplateSelector
    {
        get => (DataTemplateSelector)GetValue(SelectedContentTemplateSelectorProperty);
        internal set => SetValue(SelectedContentTemplateSelectorPropertyKey, value);
    }

    private static readonly DependencyPropertyKey SelectedContentstringFormatPropertyKey =
        DependencyProperty.RegisterReadOnly(nameof(SelectedContentstringFormat),
            typeof(string),
            typeof(TabWindow),
            new FrameworkPropertyMetadata(null));

    /// <summary>
    ///     The DependencyProperty for the SelectedContentstringFormat property.
    ///     Flags:              None
    ///     Default Value:      null
    /// </summary>
    public static readonly DependencyProperty SelectedContentstringFormatProperty =
            SelectedContentstringFormatPropertyKey.DependencyProperty;


    /// <summary>
    ///     ContentstringFormat is the format used to display the content of
    ///     the control as a string.  This arises only when no template is
    ///     available.
    /// </summary>
    public string SelectedContentstringFormat
    {
        get => (string)GetValue(SelectedContentstringFormatProperty);
        internal set => SetValue(SelectedContentstringFormatPropertyKey, value);
    }
}
