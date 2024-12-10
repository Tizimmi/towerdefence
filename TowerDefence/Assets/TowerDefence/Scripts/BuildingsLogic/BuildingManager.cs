using TowerDefence.Scripts.BuildingsLogic.Turrets;
using TowerDefence.Scripts.GameLogic;
using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic
{
	public class BuildingManager
	{
		private readonly Turret _selectedTurret;

		private readonly MoneyManager _moneyManager;

		public BuildingManager(MoneyManager moneyManager, Turret selectedTurret)
		{
			_moneyManager = moneyManager;
			_selectedTurret = selectedTurret;
		}

		public Turret GetCurrentTurret()
		{
			return _selectedTurret;
		}

		public void BuildTurret(TurretStand stand)
		{
			if (_moneyManager.TrySpendBalance(_selectedTurret._value))
				stand.SpawnTurret(_selectedTurret);
			else
				Debug.LogError("dont have enough money");
		}
	}
}