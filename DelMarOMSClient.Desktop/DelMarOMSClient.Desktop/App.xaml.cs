using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace DelMarOMSClient.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            //OMSSplashScreen splash = new OMSSplashScreen();
            //splash.DataContext = new Models.OMSSplashScreenModel();
            //splash.Show();
            //Application.Current.MainWindow = null;
            //Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            //splash.Close();
            //splash = null;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
            base.OnStartup(e);
        }
    }
}
