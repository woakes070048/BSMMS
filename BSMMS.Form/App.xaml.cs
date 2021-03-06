﻿using System.Windows;
using BSMMS.Core.Extension;
using BSMMS.Core.UI.ViewModel;
using BSMMS.Form.Service;
using BSMMS.Form.View;

namespace BSMMS.Form
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void OnStartUp(object sender, StartupEventArgs e)
		{
			this.ShutdownMode = ShutdownMode.OnExplicitShutdown;

			var windowService = WindowService.Instance;
			if (LicenseService.Instance.IsValidRegistryLicenseCode())
			{
				windowService.CreateAndShowWindowModal<MainView, MainViewModel>();
			}
			else
			{
				var window = windowService.CreateAndShowWindowModal<LicenseView, LicenseViewModel>();

				var licenseViewModel = window.ViewModel as LicenseViewModel;
				if (licenseViewModel != null && licenseViewModel.LicenseVerified)
				{
					windowService.CreateAndShowWindowModal<InstagramView, InstagramViewModel>();
				}
			}

			this.Shutdown();
		}
	}
}
