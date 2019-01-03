using ClipboardManager.Classes.Core;
using ClipboardManager.Classes.KeyEvents;
using ClipboardManager.Classes.ViewModel;
using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;

namespace ClipboardManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _dataFileName = @"ClipData.xml";
        DataTable _clipDataTable = new DataTable();

        private string lastText;
        private string lastTextUsingEnterKey;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem menuItemClose;
        private System.Windows.Forms.MenuItem menuItemOpen;
        private System.Windows.Forms.MenuItem menuItemSettings;
        private System.ComponentModel.IContainer components;

        private ViewModel viewModel;
        private ClipboardMonitor clipboardMonitor;
        private bool isLeftShiftDown;
        private bool isSpaceDown;

        public MainWindow()
        {
            InitializeComponent();
            //SettingsForm settingsForm = new SettingsForm();
            //settingsForm.ShowDialog();
            CreateNotifyIcon();
            MinimizeApplication();
            InitiateVars();
            RegisterKeyEvents();
            InitiateClipboardMonitor();
            InitDataTable();
        }

        private void SaveToBinFile(ClipboardItem clipboardItem)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ClipboardItem));
            FileStream fileStream = File.Create(System.Windows.Forms.Application.StartupPath + "\\database.xml");
            xmlSerializer .Serialize(fileStream, clipboardItem);
            fileStream.Dispose();
        }

        private void SetToolTipDuration()
        {
            ToolTipService.ShowDurationProperty.OverrideMetadata(typeof(DependencyObject), new FrameworkPropertyMetadata(10000));
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
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

            components = new System.ComponentModel.Container();
            contextMenu = new System.Windows.Forms.ContextMenu();
            menuItemClose = new System.Windows.Forms.MenuItem();
            menuItemOpen = new System.Windows.Forms.MenuItem();
            menuItemSettings = new System.Windows.Forms.MenuItem();

            contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItemClose, menuItemOpen, menuItemSettings });

            menuItemSettings.Index = 0;
            menuItemSettings.Text = "Settings";
            menuItemSettings.Click += MenuItemSettings_Click;

            menuItemOpen.Index = 1;
            menuItemOpen.Text = "Open";
            menuItemOpen.Click += MenuItemOpen_Click;

            menuItemClose.Index = 2;
            menuItemClose.Text = "Exit";
            menuItemClose.Click += MenuItemClose_Click;

            notifyIcon.ContextMenu = contextMenu;
            notifyIcon.Text = "Clipboard manager";
            notifyIcon.MouseDown += NotifyIcon_MouseDown;
            notifyIcon.Icon = Properties.Resources.app_icon;
            notifyIcon.Visible = true;
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            MaximaizeApplication();
            Activate();
        }

        private void MenuItemClose_Click(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItemSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            MaximaizeApplication();
        }

        private void NotifyIcon_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Right)
            //{
            //    ContextMenu contextMenu = (ContextMenu)FindResource("NotifierContextMenu");
            //    if (contextMenu != null)
            //        contextMenu.IsOpen = true;
            //}
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
                if (clipboardText != lastText && clipboardText != "" && clipboardText != lastTextUsingEnterKey)
                {
                    ClipboardItem clipboardItem = new ClipboardItem
                    {
                        Text = clipboardText,
                        Time = DateTime.Now
                    };

                    viewModel.Clipboards.Insert(0, clipboardItem);
                    //SaveToBinFile(clipboardItem);
                    lastText = clipboardText;
                }
            }
            catch (Exception)
            {

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Rect desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;

            //if (viewModel.Clipboards.Count != 0)
            //{
            //    ListViewUsers.SelectedIndex = 0;
            //    ListViewUsers.ScrollIntoView(ListViewUsers.SelectedItem);
            //}

            //ListViewUsers.Focus();
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

                //int index = ListViewUsers.SelectedIndex;
                ClipboardItem selectedItem = ListViewUsers.SelectedItem as ClipboardItem;
                lastTextUsingEnterKey = selectedItem.Text;
                Clipboard.SetText(lastTextUsingEnterKey);
                ListViewUsers.SelectedItem = null;
                MinimizeApplication();
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
            //if (viewModel.Clipboards.Count != 0)
            //{
            //ListViewUsers.SelectedIndex = 0;
            //ListViewUsers.ScrollIntoView(ListViewUsers.SelectedItem);

            //ListBoxItem item = (ListBoxItem)ListViewUsers.ItemContainerGenerator.ContainerFromIndex(0);
            //FocusManager.SetFocusedElement(this /* focus scope region */, item);
            //}
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                if (viewModel.Clipboards.Count != 0)
                {
                    ListBoxItem item = (ListBoxItem)ListViewUsers.ItemContainerGenerator.ContainerFromIndex(0);
                    FocusManager.SetFocusedElement(this /* focus scope region */, item);
                }
                //if (viewModel.Clipboards.Count != 0)
                //{
                //    ListViewUsers.SelectedIndex = 0;
                //    ListViewUsers.ScrollIntoView(ListViewUsers.SelectedItem);
                //}

                //ListViewUsers.Focus();
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
            foreach (var item in viewModel.Clipboards)
            {
                DataRow dataRow = _clipDataTable.NewRow();
                dataRow["ClipHeader"] = item.Text;
                _clipDataTable.Rows.Add(dataRow);
            }

            WriteDataFile();

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

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void InitDataTable()
        {
            _clipDataTable = new DataTable();
            _clipDataTable.Columns.Add("ClipHeader");
            _clipDataTable.AcceptChanges();
        }

        private void WriteDataFile()
        {
            DataSet ClipDataSet = new DataSet();
            ClipDataSet.Tables.Add(_clipDataTable);
            ClipDataSet.WriteXml(_dataFileName);
        }

        private void ReadDataFile()
        {
            DataSet ClipDataSet = new DataSet();
            if (File.Exists(_dataFileName))
            {
                ClipDataSet.ReadXml(_dataFileName);

                foreach (DataRow item in ClipDataSet.Tables[0].Rows)
                {
                    viewModel.Clipboards.Add(new ClipboardItem { Text = Convert.ToString(item["ClipHeader"]) });
                }
            }
        }
    }
}
