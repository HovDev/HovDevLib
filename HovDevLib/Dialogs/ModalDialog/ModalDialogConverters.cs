using System;
using System.Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using HovDevLib.Helpers;

namespace HovDevLib.Dialogs
{
    /// <summary>
    ///     Конвертер иконки сообщения
    /// </summary>
    [ValueConversion(typeof(ModalDialogIcon), typeof(ImageSource))]
    public class ModalDialogConverters : IValueConverter
    {
        /// <summary>
        ///     Прямая конвертация
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Иконка сообщения</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ModalDialogIcon) value)
            {
                case ModalDialogIcon.None:
                    return null;
                case ModalDialogIcon.Application:
                    return SystemIcons.Application.ToImageSource();
                case ModalDialogIcon.Asterisk:
                    return SystemIcons.Asterisk.ToImageSource();
                case ModalDialogIcon.Error:
                    return SystemIcons.Error.ToImageSource();
                case ModalDialogIcon.Exclamation:
                    return SystemIcons.Exclamation.ToImageSource();
                case ModalDialogIcon.Hand:
                    return SystemIcons.Hand.ToImageSource();
                case ModalDialogIcon.Information:
                    return SystemIcons.Information.ToImageSource();
                case ModalDialogIcon.Question:
                    return SystemIcons.Question.ToImageSource();
                case ModalDialogIcon.Shield:
                    return SystemIcons.Shield.ToImageSource();
                case ModalDialogIcon.Warning:
                    return SystemIcons.Warning.ToImageSource();
                case ModalDialogIcon.WinLogo:
                    return SystemIcons.WinLogo.ToImageSource();
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        /// <summary>
        ///     Обратная конвертация
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    /// <summary>
    ///     Конвертер видимости иконки сообщения
    /// </summary>
    [ValueConversion(typeof(ModalDialogIcon), typeof(Visibility))]
    public class ModalDialogIconVisibilityConverter : IValueConverter
    {
        /// <summary>
        ///     Прямая конвертация
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Видимость иконки сообщения</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (ModalDialogIcon) value == ModalDialogIcon.None ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <summary>
        ///     Обратная конвертация
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}