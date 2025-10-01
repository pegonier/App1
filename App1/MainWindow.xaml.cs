using App1;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Pooltriage2._0
{
    
    public sealed partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private GridModeler ViewModel = new GridModeler();
        List<BuildArzt> ArztListe = new List<BuildArzt>();

        public MainWindow()
        {
            this.InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += Timer_Tick;
            timer.Start();
            var windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(this);
            var windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
            var appWindow = AppWindow.GetFromWindowId(windowId);

            // Bildschirmgröße ermitteln (primärer Monitor)
            var displayArea = DisplayArea.GetFromWindowId(windowId, DisplayAreaFallback.Nearest);
            if (displayArea != null)
            {
                var screenSize = displayArea.WorkArea;
                appWindow.Resize(new SizeInt32(screenSize.Width, appWindow.Size.Height));
            }
            MainGrid.DataContext = ViewModel;
            MainGrid.Visibility = Visibility.Visible;
            ArztListe = ViewModel.MyItems.ToList();
            appWindow.Title = "Pooltriage ";
        }
        private void Timer_Tick(object sender, object e)
        {
            ExaminationTriage examinationTriage = new ExaminationTriage();
            if (ArztListe.Count != null)
            {
                examinationTriage.ExaminationToDoctor(ArztListe);
            }
            
        }
    }
}