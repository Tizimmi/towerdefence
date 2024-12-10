using Plugins.ReactivePropertyModule;

namespace TowerDefence.Scripts.GameLogic
{
	public class MoneyManager
	{
		private ReactiveProperty<int> _currentBalance = new(0);
		public ReactiveProperty<int> CurrentBalance => _currentBalance;

		public MoneyManager(int startingBalance)
		{
			CurrentBalance.Value = startingBalance;
		}

		public bool TrySpendBalance(int value)
		{
			if (CurrentBalance.Value - value < 0)
				return false;

			CurrentBalance.Value -= value;
			return true;
		}

		public void AddBalance(int value)
		{
			CurrentBalance.Value += value;
		}
	}
}