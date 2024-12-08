using UnityEngine;

namespace TowerDefence.Scripts.GameLogic
{
	public class MoneyManager : MonoBehaviour // переделать из монобеха?
	{
		[SerializeField]
		private int _startingBalance;
		
		private int _currentBalance;

		private void Start()
		{
			_currentBalance = _startingBalance;
		}

		public bool TrySpendBalance(int value)
		{
			if (_currentBalance - value < 0)
				return false;

			_currentBalance -= value;
			return true;
		}

		public void AddBalance(int value)
		{
			_currentBalance += value;
			Debug.Log(_currentBalance);
		}
	}
}