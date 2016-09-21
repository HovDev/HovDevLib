using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace HovDevLib.Dialogs
{
    /// <summary>
    ///     Центрированное сообщение
    /// </summary>
    public class CenterWinDialog : IDisposable
    {
        private readonly Window _mOwner;
        private int _mTries;

        /// <summary>
        ///     Инициализация нового экземпляра класса CenterWinDialog
        /// </summary>
        /// <param name="owner">Родительское окно</param>
        public CenterWinDialog(Window owner)
        {
            _mOwner = owner;
            Dispatcher.CurrentDispatcher.BeginInvoke(new MethodInvoker(FindDialog));
        }

        /// <summary>
        ///     Освобождает все ресурсы занимаемые этим экземпляром класса CenterWinDialog
        /// </summary>
        public void Dispose()
        {
            _mTries = -1;
        }

        private void FindDialog()
        {
            // Enumerate windows to find the message box
            if (_mTries < 0) return;
            var callback = new EnumThreadWndProc(CheckWindow);
            if (EnumThreadWindows(GetCurrentThreadId(), callback, IntPtr.Zero))
                if (++_mTries < 10)
                    Dispatcher.CurrentDispatcher.BeginInvoke(new MethodInvoker(FindDialog));
        }

        private bool CheckWindow(IntPtr hWnd, IntPtr lp)
        {
            // Checks if <hWnd> is a dialog
            var sb = new StringBuilder(260);
            GetClassName(hWnd, sb, sb.Capacity);
            if (sb.ToString() != "#32770") return true;
            // Got it
            var frmRect = new Rectangle(new Point((int) _mOwner.Left, (int) _mOwner.Top),
                new Size((int) _mOwner.ActualWidth, (int) _mOwner.ActualHeight));
            Rect dlgRect;
            GetWindowRect(hWnd, out dlgRect);
            MoveWindow(hWnd,
                frmRect.Left + (frmRect.Width - dlgRect.Right + dlgRect.Left)/2,
                frmRect.Top + (frmRect.Height - dlgRect.Bottom + dlgRect.Top)/2,
                dlgRect.Right - dlgRect.Left,
                dlgRect.Bottom - dlgRect.Top, true);
            return false;
        }

        [DllImport("user32.dll")]
        private static extern bool EnumThreadWindows(int tid, EnumThreadWndProc callback, IntPtr lp);

        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();

        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int buflen);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out Rect rc);

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool repaint);

        // P/Invoke declarations
        private delegate bool EnumThreadWndProc(IntPtr hWnd, IntPtr lp);

        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
}