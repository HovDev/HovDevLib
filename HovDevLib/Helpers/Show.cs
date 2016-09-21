using System;
using System.Globalization;
using System.Windows;

namespace HovDevLib.Helpers
{
    public static class ShowStatics
    {
        /// <summary>
        ///     Показывает объект в сообщении System.Windows.MessageBox
        /// </summary>
        /// <param name="inputObject">Объект для сообщения</param>
        /// <returns>Показываемый объект</returns>
        public static T ToShowWin<T>(this T inputObject)
        {
            MessageBox.Show(Convert.ToString(inputObject, CultureInfo.CurrentCulture));
            return inputObject;
        }
    }
}