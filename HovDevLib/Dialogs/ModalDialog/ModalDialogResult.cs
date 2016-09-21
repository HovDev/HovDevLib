namespace HovDevLib.Dialogs
{
    /// <summary>
    ///     Результат вывода сообщения
    /// </summary>
    public enum ModalDialogResult
    {
        /// <summary>
        ///     Нажата кнопка OK
        /// </summary>
        Ok = 0,

        /// <summary>
        ///     Нажата кнопка Отмена
        /// </summary>
        Cancel = 1,

        /// <summary>
        ///     Назата кнопка Да
        /// </summary>
        Yes = 2,

        /// <summary>
        ///     Нажата кнопка Нет
        /// </summary>
        No = 3,

        /// <summary>
        ///     Результата нет
        /// </summary>
        None = 4
    }
}