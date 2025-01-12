using Plugins.ReactivePropertyModule;
using TowerDefence.Scripts.BuildingsLogic.Turrets;
using TowerDefence.Scripts.GameLogic;

namespace TowerDefence.Scripts.BuildingsLogic
{
	public class BuildingManager
	{
		private readonly MoneyManager _moneyManager;
		public readonly ReactiveProperty<Turret> SelectedTurret;

		public BuildingManager(MoneyManager moneyManager, Turret turret)
		{
			_moneyManager = moneyManager;
			SelectedTurret = new ReactiveProperty<Turret>(turret);
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
		}
	}
}