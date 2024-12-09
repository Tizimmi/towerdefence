using System;

namespace Plugins.MVVMModule
{
	public interface IView<in TViewModel> : IDisposable
		where TViewModel : class, IViewModel
	{
		void Bind(TViewModel viewModel);
		void Unbind();
	}
}