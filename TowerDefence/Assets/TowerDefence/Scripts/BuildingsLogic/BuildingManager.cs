using Plugins.ReactivePropertyModule;
using System;
using TowerDefence.Scripts.BuildingsLogic.Turrets;
using TowerDefence.Scripts.GameLogic;
using TowerDefence.Scripts.GameUI;

namespace TowerDefence.Scripts.BuildingsLogic
{
	public class BuildingManager
	{
		public readonly ReactiveProperty<Turret> SelectedTurret;
		private readonly MoneyManager _moneyManager;
		private readonly TipPopupViewModel _tipPopupViewModel;

		public BuildingManager(MoneyManager moneyManager, Turret turret, TipPopupViewModel tipPopupViewModel)
		{
			_moneyManager = moneyManager;
			_tipPopupViewModel = tipPopupViewModel;
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
				_tipPopupViewModel.ShowTip("You don't have enough money");
		}
	}
}