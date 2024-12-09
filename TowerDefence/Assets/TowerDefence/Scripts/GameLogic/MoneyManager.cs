using Plugins.ReactivePropertyModule;
using TowerDefence.Scripts.GameUI;
using UnityEngine;

namespace TowerDefence.Scripts.GameLogic
{
	public class MoneyManager : MonoBehaviour // переделать из монобеха?
	{
		[SerializeField]
		private int _startingBalance;
		[SerializeField]
		private MoneyView _moneyView;
		
		private ReactiveProperty<int> _currentBalance = new(0);

		private void Start()
		{
			_moneyView.Bind(new MoneyViewModel(_currentBalance));
			_currentBalance.Value = _startingBalance;
		}

		public bool TrySpendBalance(int value)
		{
			if (_currentBalance.Value - value < 0)
				return false;

			_currentBalance.Value -= value;
			return true;
		}

		public void AddBalance(int value)
		{
			_currentBalance.Value += value;
		}
	}
}