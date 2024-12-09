using UnityEngine;

namespace Plugins.MVVMModule
{
	public abstract class View<TViewModel> : MonoBehaviour, IView<TViewModel>
		where TViewModel : class, IViewModel
	{
		private TViewModel _viewModel;
		public TViewModel ViewModel => _viewModel;

		public void Bind(TViewModel viewModel)
		{
			Unbind();
			
			_viewModel = viewModel;
			OnBind(_viewModel);
		}

		public void Unbind()
		{
			if (_viewModel != null)
			{
				OnUnbind(_viewModel);
				_viewModel = null;
			}
		}

		protected virtual void OnBind(TViewModel viewModel)
		{
			Debug.Log($"Bind view model '{viewModel}' to view '{this}'");
		}

		protected virtual void OnUnbind(TViewModel viewModel)
		{
			Debug.Log($"Unbind view model '{viewModel}' from view '{this}'");
		}

		public virtual void Dispose() { }
	}
}