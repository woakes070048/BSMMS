﻿using System.Windows;
using BSMMS.Core.UI.View;
using BSMMS.Core.UI.ViewModel;

namespace BSMMS.Form.View
{
	/// <summary>
	/// Interaction logic for LicenseView.xaml
	/// </summary>
	public partial class LicenseView : BaseWindow
	{
		public LicenseViewModel ViewModel { get; set; }

		public LicenseView()
		{
			InitializeComponent();
		}

		public override void AttachContext(IBaseViewModel viewModel)
		{
			this.ViewModel = viewModel as LicenseViewModel;
			this.ViewModel.Init();

			this.DataContext = this.ViewModel;
		}
	}
}
