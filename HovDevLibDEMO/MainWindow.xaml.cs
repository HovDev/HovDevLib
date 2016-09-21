using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using HovDevLib.Dialogs;
using HovDevLib.Helpers;

namespace HovDevLibDEMO
{
    /// <summary>
    ///     Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BModalDialog_Click(object sender, RoutedEventArgs e)
        {
            const string message = "My message sample";
            var longText =
                $"Bla bla bla bla bla bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla.\r" +
                "Bla bla bla bla bla bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla.\r" +
                "Bla bla bla bla bla bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla  bla bla bla.";
            const ModalDialogButtons buttons = ModalDialogButtons.YesNoCancel;
            const ModalDialogIcon icon = ModalDialogIcon.Information;

            Mdlg.Show(
                $"Modal Dialog Result: \r\"{Mdlg.Show(message, buttons, icon)}\""
                // $"Modal Dialog Result: \r\"{Mdlg.Show(longText, buttons, icon)}\""
            );
        }

        private void BtToShowWin_Click(object sender, RoutedEventArgs e)
        {
            Mdlg
                .ToShowWin()
                .Show("Hellow!");
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            e.Cancel =
                Mdlg.Show("Exit?! Are you sure? ;)", ModalDialogButtons.YesNo, ModalDialogIcon.Question) ==
                       ModalDialogResult.No;
        }

        private void BtCenterWinDialog_Click(object sender, RoutedEventArgs e)
        {
            using (new CenterWinDialog(this))
            {
                System.Windows.MessageBox.Show("MessageBox centered");
            }
        }
    }
}