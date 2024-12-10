using Plugins.ReactivePropertyModule;

namespace TowerDefence.Scripts.GameLogic
{
	public class MoneyManager
	{
		public ReactiveProperty<int> CurrentBalance { get; } = new(0);

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