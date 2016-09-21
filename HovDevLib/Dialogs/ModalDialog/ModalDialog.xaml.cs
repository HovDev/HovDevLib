using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace HovDevLib.Dialogs
{
    /// <summary>
    ///     Модальное окно сообщения
    /// </summary>
    public partial class ModalDialog
    {
        public ModalDialog CreateNew(ModalDialog main)
        {
            return new ModalDialog
            {
                Icon = main.Icon,
                Message = main.Message,
                ParentElement = main.ParentElement,
                OkTitle = main.OkTitle,
                CancelTitle = main.CancelTitle,
                YesTitle = main.YesTitle,
                NoTitle = main.NoTitle
            };
        }

        #region Private

        private bool _hideRequest;
        private ModalDialogResult _result = ModalDialogResult.None;
        private ModalDialogButtons _buttons = ModalDialogButtons.Ok;
        private IInputElement _focusedControl;

        private void HideHandlerDialog()
        {
            _hideRequest = true;
            Visibility = Visibility.Hidden;
            ParentElement.IsEnabled = true;
            Keyboard.Focus(_focusedControl);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            _result = _buttons == ModalDialogButtons.Ok ? ModalDialogResult.Ok : ModalDialogResult.Yes;
            HideHandlerDialog();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _result = _buttons == ModalDialogButtons.OkCancel ? ModalDialogResult.Cancel : ModalDialogResult.No;
            HideHandlerDialog();
        }

        private void Cancel2Button_Click(object sender, RoutedEventArgs e)
        {
            if (_buttons == ModalDialogButtons.YesNoCancel)
                _result = ModalDialogResult.Cancel;
            HideHandlerDialog();
        }

        #endregion

        #region Properties

        #region Message

        /// <summary>
        ///     Текст сообщения
        /// </summary>
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message",
            typeof(string), typeof(ModalDialog), new UIPropertyMetadata(string.Empty));

        /// <summary>
        ///     Текст сообщения
        /// </summary>
        [Category("Properties")]
        public string Message
        {
            get { return (string) GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        #endregion

        #region Icon

        /// <summary>
        ///     Иконка сообщения
        /// </summary>
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof(ModalDialogIcon), typeof(ModalDialog), new PropertyMetadata(ModalDialogIcon.None));

        /// <summary>
        ///     Иконка сообщения
        /// </summary>
        [Category("Properties")]
        public ModalDialogIcon Icon
        {
            get { return (ModalDialogIcon) GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        #endregion

        #region ParentElement

        /// <summary>
        ///     Родительский элемент сообщения
        /// </summary>
        public static readonly DependencyProperty ParentElementProperty = DependencyProperty.Register("ParentElement",
            typeof(UIElement), typeof(ModalDialog), new UIPropertyMetadata(null));

        /// <summary>
        ///     Родительский элемент сообщения
        /// </summary>
        [Category("Properties")]
        public UIElement ParentElement
        {
            get { return (UIElement) GetValue(ParentElementProperty); }
            set { SetValue(ParentElementProperty, value); }
        }

        #endregion

        #region CornerRadius

        /// <summary>
        ///     Радиусы углов формы сообщения
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius",
            typeof(CornerRadius), typeof(ModalDialog), new UIPropertyMetadata(new CornerRadius(10, 0, 10, 0)));

        /// <summary>
        ///     Радиусы углов формы сообщения
        /// </summary>
        [Category("Properties")]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius) GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        #endregion

        #region ButtonHorizontalAlignment

        /// <summary>
        ///     Расположение кнопок сообщения
        /// </summary>
        public static readonly DependencyProperty ButtonHorizontalAlignmentProperty =
            DependencyProperty.Register("ButtonHorizontalAlignment", typeof(HorizontalAlignment), typeof(ModalDialog),
                new UIPropertyMetadata(HorizontalAlignment.Center));

        /// <summary>
        ///     Расположение кнопок сообщения
        /// </summary>
        [Category("Properties")]
        public HorizontalAlignment ButtonHorizontalAlignment
        {
            get { return (HorizontalAlignment) GetValue(ButtonHorizontalAlignmentProperty); }
            set { SetValue(ButtonHorizontalAlignmentProperty, value); }
        }

        #endregion

        #region OKTitle

        /// <summary>
        ///     Текст кнопки OK
        /// </summary>
        public static readonly DependencyProperty OkTitleProperty = DependencyProperty.Register("OkTitle",
            typeof(string), typeof(ModalDialog), new UIPropertyMetadata("OK"));

        /// <summary>
        ///     Текст кнопки OK
        /// </summary>
        [Category("Properties")]
        public string OkTitle
        {
            get { return (string) GetValue(OkTitleProperty); }
            set { SetValue(OkTitleProperty, value); }
        }

        #endregion

        #region YesTitle

        /// <summary>
        ///     Текст кнопки Да
        /// </summary>
        public static readonly DependencyProperty YesTitleProperty = DependencyProperty.Register("YesTitle",
            typeof(string), typeof(ModalDialog), new UIPropertyMetadata("Да"));

        /// <summary>
        ///     Текст кнопки Да
        /// </summary>
        [Category("Properties")]
        public string YesTitle
        {
            get { return (string) GetValue(YesTitleProperty); }
            set { SetValue(YesTitleProperty, value); }
        }

        #endregion

        #region CancelTitle

        /// <summary>
        ///     Текст кнопки Отмена
        /// </summary>
        public static readonly DependencyProperty CancelTitleProperty = DependencyProperty.Register("CancelTitle",
            typeof(string), typeof(ModalDialog), new UIPropertyMetadata("Отмена"));

        /// <summary>
        ///     Текст кнопки Отмена
        /// </summary>
        [Category("Properties")]
        public string CancelTitle
        {
            get { return (string) GetValue(CancelTitleProperty); }
            set { SetValue(CancelTitleProperty, value); }
        }

        #endregion

        #region NoTitle

        /// <summary>
        ///     Текст кнопки Нет
        /// </summary>
        public static readonly DependencyProperty NoTitleProperty = DependencyProperty.Register("NoTitle",
            typeof(string), typeof(ModalDialog), new UIPropertyMetadata("Нет"));

        /// <summary>
        ///     Текст кнопки Нет
        /// </summary>
        [Category("Properties")]
        public string NoTitle
        {
            get { return (string) GetValue(NoTitleProperty); }
            set { SetValue(NoTitleProperty, value); }
        }

        #endregion

        #region BackgroundUnderlay

        /// <summary>
        ///     Фон подложки
        /// </summary>
        public static readonly DependencyProperty BackgroundUnderlayProperty = DependencyProperty.Register(
            "BackgroundUnderlay", typeof(Brush), typeof(ModalDialog),
            new PropertyMetadata(new SolidColorBrush(Color.FromArgb(127, 0, 0, 0))));

        /// <summary>
        ///     Фон подложки
        /// </summary>
        [Category("Properties")]
        public Brush BackgroundUnderlay
        {
            get { return (Brush) GetValue(BackgroundUnderlayProperty); }
            set { SetValue(BackgroundUnderlayProperty, value); }
        }

        #endregion

        #endregion

        #region Public

        /// <summary>
        ///     Создает модальное окно сообщения
        /// </summary>
        public ModalDialog()
        {
            InitializeComponent();
            Visibility = Visibility.Hidden;
        }

        /// <summary>
        ///     Выводит сообщение
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <returns>Результат вывода сообщения</returns>
        public ModalDialogResult Show(string message)
        {
            return PrivateShow(ParentElement, message, ModalDialogButtons.Ok, ModalDialogIcon.None);
        }

        /// <summary>
        ///     Выводит сообщение
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="icon">Иконка сообщения</param>
        /// <returns>Результат вывода сообщения</returns>
        public ModalDialogResult Show(string message, ModalDialogIcon icon)
        {
            return PrivateShow(ParentElement, message, ModalDialogButtons.Ok, icon);
        }

        /// <summary>
        ///     Выводит сообщение
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="buttons">Набор кнопок сообщения</param>
        /// <returns>Результат вывода сообщения</returns>
        public ModalDialogResult Show(string message, ModalDialogButtons buttons)
        {
            return PrivateShow(ParentElement, message, buttons, ModalDialogIcon.None);
        }

        /// <summary>
        ///     Выводит сообщение
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="buttons">Набор кнопок сообщения</param>
        /// <param name="icon">Иконка сообщения</param>
        /// <returns>Результат вывода сообщения</returns>
        public ModalDialogResult Show(string message, ModalDialogButtons buttons, ModalDialogIcon icon)
        {
            return PrivateShow(ParentElement, message, buttons, icon);
        }

        private ModalDialogResult PrivateShow(UIElement parentElement, string message, ModalDialogButtons buttons,
            ModalDialogIcon icon)
        {
            var parentWindow = Window.GetWindow(Parent);
            parentWindow?.Activate();
            if ((parentWindow != null) && (parentWindow.WindowState == WindowState.Minimized))
                parentWindow.WindowState = WindowState.Normal;
            Keyboard.Focus(parentWindow);
            if (parentElement == null) throw new ArgumentNullException(nameof(parentElement));
            Window.GetWindow(this)?.Activate();
            if (parentElement == null)
                throw new ArgumentNullException(nameof(parentElement));
            _focusedControl = Keyboard.FocusedElement;
            Message = message;
            _buttons = buttons;
            Icon = icon;
            switch (_buttons)
            {
                case ModalDialogButtons.Ok:
                    SetButtonValues(OkButton, true, true, true, OkTitle);
                    SetButtonValues(CancelButton, false);
                    SetButtonValues(Cancel2Button, false);
                    break;
                case ModalDialogButtons.OkCancel:
                    SetButtonValues(OkButton, true, true, false, OkTitle);
                    SetButtonValues(CancelButton, true, false, true, CancelTitle);
                    SetButtonValues(Cancel2Button, false);
                    break;
                case ModalDialogButtons.YesNo:
                    SetButtonValues(OkButton, true, true, false, YesTitle);
                    SetButtonValues(CancelButton, true, false, true, NoTitle);
                    SetButtonValues(Cancel2Button, false);
                    break;
                case ModalDialogButtons.YesNoCancel:
                    SetButtonValues(OkButton, true, false, false, YesTitle);
                    SetButtonValues(CancelButton, true, false, false, NoTitle);
                    SetButtonValues(Cancel2Button, true, true, true, CancelTitle);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(buttons));
            }
            Visibility = Visibility.Visible;
            ParentElement.IsEnabled = false;
            _hideRequest = false;
            while (!_hideRequest)
            {
                if (Dispatcher.HasShutdownStarted || Dispatcher.HasShutdownFinished)
                    break;
                Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));
                Thread.Sleep(20);
            }
            return _result;
        }

        /// <summary>
        ///     Устанавливает значения для кнопки
        /// </summary>
        /// <param name="needButton">Требуемая кнопка</param>
        /// <param name="visibility">Видимость кнопки</param>
        private static void SetButtonValues(Button needButton, bool visibility)
        {
            SetButtonValues(needButton, visibility, false, false, string.Empty);
        }

        /// <summary>
        ///     Устанавливает значения для кнопки
        /// </summary>
        /// <param name="needButton">Требуемая кнопка</param>
        /// <param name="visibility">Видимость кнопки</param>
        /// <param name="isDefault">Является ли кнопкой по умолчанию</param>
        /// <param name="isCancel">Является ли кнопкой отмены</param>
        /// <param name="text">Текст кнопки</param>
        private static void SetButtonValues(Button needButton, bool visibility, bool isDefault, bool isCancel,
            string text)
        {
            if (needButton == null) throw new ArgumentNullException(nameof(needButton));
            needButton.Visibility = visibility ? Visibility.Visible : Visibility.Collapsed;
            needButton.IsDefault = isDefault;
            needButton.IsCancel = isCancel;
            needButton.Content = text;
        }

        #endregion
    }
}