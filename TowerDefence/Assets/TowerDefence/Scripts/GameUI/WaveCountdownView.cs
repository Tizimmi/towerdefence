using Plugins.MVVMModule;
using Plugins.ReactivePropertyModule;
using TMPro;
using UnityEngine;

namespace TowerDefence.Scripts.GameUI
{
	public class WaveCountdownView : View<WaveCountdownViewModel>
	{
		[SerializeField]
		private TextMeshProUGUI _waveCountdown;

		protected override void OnBind(WaveCountdownViewModel viewModel)
		{
			viewModel.Timer.OnValueChange += UpdateValue;
			UpdateValue(viewModel.Timer.Value);
		}

		protected override void OnUnbind(WaveCountdownViewModel viewModel)
		{
			viewModel.Timer.OnValueChange -= UpdateValue;
		}

		private void UpdateValue(float time)
		{
			if (time == 0)
			{
				_waveCountdown.text = string.Empty;
				return;
			}

			_waveCountdown.text = Mathf.Ceil(time).ToString();
		}
	}

	public class WaveCountdownViewModel : ViewModel
	{
		public IReadOnlyReactiveProperty<float> Timer => _timer;
		private readonly ReactiveProperty<float> _timer;

		public WaveCountdownViewModel(ReactiveProperty<float> timer)
		{
			_timer = timer;
		}
	}
}