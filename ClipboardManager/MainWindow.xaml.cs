using ClipboardManager.Classes.Core;
using ClipboardManager.Classes.KeyEvents;
using ClipboardManager.Classes.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ClipboardManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string lastTest;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private ViewModel viewModel;
        private ClipboardMonitor clipboardMonitor;
        private bool isLeftShiftDown;
        private bool isSpaceDown;

        public MainWindow()
        {
            InitializeComponent();
            CreateNotifyIcon();
            MinimizeApplication();
            InitiateVars();
            RegisterKeyEvents();
            InitiateClipboardMonitor();
        }

        private void InitiateVars()
        {
            isLeftShiftDown = false;
            isSpaceDown = false;
            viewModel = new ViewModel();
            DataContext = viewModel;
        }

        private void RegisterKeyEvents()
        {
            HookManager.KeyDown += HookManager_KeyDown;
            HookManager.KeyUp += HookManager_KeyUp;
        }

        private void HookManager_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.LShiftKey)
                isLeftShiftDown = false;
            if (e.KeyData == System.Windows.Forms.Keys.Space)
                isSpaceDown = false;
        }

        private void HookManager_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.LShiftKey)
                isLeftShiftDown = true;
            if (e.KeyData == System.Windows.Forms.Keys.Space)
                isSpaceDown = true;

            if (isLeftShiftDown && isSpaceDown)
                MaximaizeApplication();
        }

        private void CreateNotifyIcon()
        {
            notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.MouseDown += NotifyIcon_MouseDown;
            notifyIcon.Icon = Properties.Resources.app_icon;
            notifyIcon.Visible = true;
        }

        private void NotifyIcon_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenu contextMenu = (ContextMenu)FindResource("NotifierContextMenu");
                if (contextMenu != null)
                    contextMenu.IsOpen = true;
            }
        }

        private void InitiateClipboardMonitor()
        {
            clipboardMonitor = new ClipboardMonitor();
            clipboardMonitor.OnClipboardContentChanged += ClipboardMonitor_OnClipboardContentChanged;
        }

        private void ClipboardMonitor_OnClipboardContentChanged(object sender, EventArgs e)
        {
            try
            {
                string clipboardText = Clipboard.GetText(TextDataFormat.UnicodeText);
                if (clipboardText != lastTest && clipboardText != "")
                    viewModel.Clipboards.Insert(0, new ClipboardItem {
                        Text = clipboardText
                    });

                lastTest = clipboardText;
            }
            catch (Exception)
            {

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListViewUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                clipboardMonitor.OnClipboardContentChanged -= ClipboardMonitor_OnClipboardContentChanged;

                if (ListViewUsers.SelectedIndex == -1)
                    return;

                int index = ListViewUsers.SelectedIndex;
                ClipboardItem selectedItem = ListViewUsers.SelectedItem as ClipboardItem;
                Clipboard.SetText(selectedItem.Text);
                ListViewUsers.SelectedItem = null;
                MinimizeApplication();

                //clipboardMonitor.OnClipboardContentChanged -= ClipboardMonitor_OnClipboardContentChanged;
                //object source = e.Source;
                //ClipboardItem selectedItem = ListViewUsers.SelectedItem as ClipboardItem;
                //var viewModel = DataContext as ViewModel;
                //try
                //{
                //    string text = Clipboard.GetText();
                //    if (text != selectedItem.Text)
                //        Clipboard.SetText(selectedItem.Text);
                //}
                //catch (COMException)
                //{

                //}

                clipboardMonitor.OnClipboardContentChanged += ClipboardMonitor_OnClipboardContentChanged;
            }
        }

        private void ListViewUsers_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (ListViewUsers.SelectedIndex == -1)
                return;
            int index = ListViewUsers.SelectedIndex;
            ClipboardItem selectedItem = ListViewUsers.SelectedItem as ClipboardItem;
            Clipboard.SetText(selectedItem.Text);
            ListViewUsers.SelectedItem = null;
            MinimizeApplication();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            MinimizeApplication();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            MinimizeApplication();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
             if (WindowState == WindowState.Normal)
            {
                if (viewModel.Clipboards.Count != 0)
                {
                    ListViewItem item = ListViewUsers.ItemContainerGenerator.ContainerFromIndex(0) as ListViewItem;
                    if (item != null)
                    {
                        item.Focus();
                        item.IsSelected = true;
                    }
                }
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                MinimizeApplication();
        }        

        private void MinimizeApplication()
        {
            Hide();
            WindowState = WindowState.Minimized;
        }

        private void MaximaizeApplication()
        {
            Show();
            WindowState = WindowState.Normal;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            notifyIcon.Visible = false;
        }

        private void Menu_Open(object sender, RoutedEventArgs e)
        {
            MaximaizeApplication();
        }

        private void Menu_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Menu_Settings(object sender, RoutedEventArgs e)
        {

        }
    }
}
