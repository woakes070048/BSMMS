using System.Windows;
using InstaFollow.Core.UI.ViewModel;

namespace InstaFollow.Core.UI.View
{
	public abstract class BaseWindow : Window, IBaseWindow
	{
		public abstract void AttachContext(IBaseViewModel viewModel);
	}

	public interface IBaseWindow
	{
		void AttachContext(IBaseViewModel viewModel);
		void Show();
		bool? ShowDialog();
		void Close();
	}
}