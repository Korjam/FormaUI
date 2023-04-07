using FluentUI.Common;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FluentUI.Dialogs;

/// <summary>
/// Interaction logic for MessageBoxDialog.xaml
/// </summary>
public partial class MessageBoxDialog : INotifyPropertyChanged
{
    private string _message = string.Empty;
    private MessageBoxButton _button = MessageBoxButton.YesNoCancel;
    private MessageBoxResult _result = MessageBoxResult.None;

    public MessageBoxDialog()
    {
        InitializeComponent();

        DataContext = this;

        ConfirmationCommand = new RelayCommand(() =>
        {
            Result = CalculateResult(true);
            DialogResult = true;
        });
        DenegationCommand = new RelayCommand(() =>
        {
            Result = CalculateResult(false);
            DialogResult = false;
        });
        CancellationCommand = new RelayCommand(() =>
        {
            Result = CalculateResult(null);
            Close();
        });
    }

    public string Message
    {
        get => _message;
        set
        {
            if (_message != value)
            {
                _message = value;
                OnPropertyChanged();
            }
        }
    }

    public MessageBoxButton Button
    {
        get => _button;
        set
        {
            if (_button != value)
            {
                _button = value;
                OnPropertyChanged();

                UpdateButtons(value);
            }
        }
    }

    public MessageBoxResult Result
    {
        get => _result;
        private set
        {
            if (_result != value)
            {
                _result = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand ConfirmationCommand { get; }
    public ICommand DenegationCommand { get; }
    public ICommand CancellationCommand { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) =>
        PropertyChanged?.Invoke(this, e);

    private void UpdateButtons(MessageBoxButton value)
    {
        switch (value)
        {
            case MessageBoxButton.OK:
                _confirmationButton.Style = (Style)FindResource("StandardButtonStyle");

                _confirmationButton.SetCurrentValue(ContentProperty, "OK");

                _confirmationButton.SetCurrentValue(VisibilityProperty, Visibility.Visible);
                _denegationButton.SetCurrentValue(VisibilityProperty, Visibility.Collapsed);
                _cancellationButton.SetCurrentValue(VisibilityProperty, Visibility.Collapsed);

                Grid.SetColumn(_confirmationButton, 4);

                _firstColumn.SetCurrentValue(ColumnDefinition.WidthProperty, new GridLength(0));
                _firstMargin.SetCurrentValue(ColumnDefinition.WidthProperty, new GridLength(0));
                break;
            case MessageBoxButton.OKCancel:
                _confirmationButton.Style = (Style)FindResource("AccentButtonStyle");

                _confirmationButton.SetCurrentValue(ContentProperty, "OK");
                _cancellationButton.SetCurrentValue(ContentProperty, "Cancel");

                _confirmationButton.SetCurrentValue(VisibilityProperty, Visibility.Visible);
                _denegationButton.SetCurrentValue(VisibilityProperty, Visibility.Collapsed);
                _cancellationButton.SetCurrentValue(VisibilityProperty, Visibility.Visible);

                Grid.SetColumn(_confirmationButton, 2);
                Grid.SetColumn(_cancellationButton, 4);

                _firstColumn.SetCurrentValue(ColumnDefinition.WidthProperty, new GridLength(0));
                _firstMargin.SetCurrentValue(ColumnDefinition.WidthProperty, new GridLength(0));
                break;
            case MessageBoxButton.YesNoCancel:
                _confirmationButton.Style = (Style)FindResource("AccentButtonStyle");

                _confirmationButton.SetCurrentValue(ContentProperty, "Yes");
                _denegationButton.SetCurrentValue(ContentProperty, "No");
                _cancellationButton.SetCurrentValue(ContentProperty, "Cancel");

                _confirmationButton.SetCurrentValue(VisibilityProperty, Visibility.Visible);
                _denegationButton.SetCurrentValue(VisibilityProperty, Visibility.Visible);
                _cancellationButton.SetCurrentValue(VisibilityProperty, Visibility.Visible);

                Grid.SetColumn(_confirmationButton, 0);
                Grid.SetColumn(_denegationButton, 2);
                Grid.SetColumn(_cancellationButton, 4);

                _firstColumn.SetCurrentValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
                _firstMargin.SetCurrentValue(ColumnDefinition.WidthProperty, new GridLength(8));
                break;
            case MessageBoxButton.YesNo:
                _confirmationButton.Style = (Style)FindResource("AccentButtonStyle");

                _confirmationButton.SetCurrentValue(ContentProperty, "Yes");
                _denegationButton.SetCurrentValue(ContentProperty, "No");

                _confirmationButton.SetCurrentValue(VisibilityProperty, Visibility.Visible);
                _denegationButton.SetCurrentValue(VisibilityProperty, Visibility.Visible);
                _cancellationButton.SetCurrentValue(VisibilityProperty, Visibility.Collapsed);

                Grid.SetColumn(_confirmationButton, 2);
                Grid.SetColumn(_denegationButton, 4);

                _firstColumn.SetCurrentValue(ColumnDefinition.WidthProperty, new GridLength(0));
                _firstMargin.SetCurrentValue(ColumnDefinition.WidthProperty, new GridLength(0));
                break;
        }
    }

    private MessageBoxResult CalculateResult(bool? result)
    {
        if (result is null)
        {
            return MessageBoxResult.Cancel;
        }

        return Button switch
        {
            MessageBoxButton.OK => result.Value ? MessageBoxResult.OK : throw new NotSupportedException("Result always should be 'Ok'."),
            MessageBoxButton.OKCancel => result.Value ? MessageBoxResult.OK : throw new NotSupportedException("Result always should be 'Ok' if not cancelled."),
            MessageBoxButton.YesNoCancel => result.Value ? MessageBoxResult.Yes : MessageBoxResult.No,
            MessageBoxButton.YesNo => result.Value ? MessageBoxResult.Yes : MessageBoxResult.No,
            _ => throw new UnreachableException(),
        };
    }
}
