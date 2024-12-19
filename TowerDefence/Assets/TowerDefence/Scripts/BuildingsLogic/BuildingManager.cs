using Plugins.ReactivePropertyModule;
using TowerDefence.Scripts.BuildingsLogic.Turrets;
using TowerDefence.Scripts.GameLogic;
using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic
{
	public class BuildingManager
	{
		public readonly ReactiveProperty<Turret> SelectedTurret;

		private readonly MoneyManager _moneyManager;

		public BuildingManager(MoneyManager moneyManager, Turret turret)
		{
			_moneyManager = moneyManager;
			SelectedTurret = new(turret);
		}

		public void SetCurrentTurret(Turret turret)
		{
			SelectedTurret.Value = turret;
		}

		public Turret GetCurrentTurret()
		{
			return SelectedTurret.Value;
		}

		public void BuildTurret(TurretStand stand)
		{
			if (_moneyManager.TrySpendBalance(SelectedTurret.Value._value))
				stand.SpawnTurret(SelectedTurret.Value);
			else
				Debug.LogError("dont have enough money");
		}
	}
}