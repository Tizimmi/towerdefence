using Plugins.MVVMModule;
using Plugins.ReactivePropertyModule;
using TMPro;
using UnityEngine;

namespace TowerDefence.Scripts.GameUI
{
	public class MoneyView : View<MoneyViewModel>
	{
		[SerializeField]
		private TextMeshProUGUI _moneyContainer;

		protected override void OnBind(MoneyViewModel viewModel)
		{
			viewModel.Money.OnValueChange += UpdateValue;
			UpdateValue(viewModel.Money.Value);
		}

		protected override void OnUnbind(MoneyViewModel viewModel)
		{
			viewModel.Money.OnValueChange -= UpdateValue;
		}

		private void UpdateValue(int value)
		{
			_moneyContainer.text = value + " $";
		}
	}

	public class MoneyViewModel : ViewModel
	{
		public IReadOnlyReactiveProperty<int> Money => _money;
		private readonly ReactiveProperty<int> _money;

		public MoneyViewModel(ReactiveProperty<int> money)
		{
			_money = money;
		}
	}
}