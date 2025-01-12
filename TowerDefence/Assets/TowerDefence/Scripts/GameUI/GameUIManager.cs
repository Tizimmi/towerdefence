using TowerDefence.Scripts.BuildingsLogic;
using TowerDefence.Scripts.BuildingsLogic.Turrets;
using TowerDefence.Scripts.GameLogic;
using UnityEngine;

namespace TowerDefence.Scripts.GameUI
{
	public class GameUIManager
	{
		private readonly Turret[] _availableTurrets;
		private readonly BuildingManager _buildingManager;
		private readonly MoneyManager _moneyManager;
		private readonly Transform _uiRoot;
		private readonly ViewProvider _viewProvider;
		private readonly WaveSpawner _waveSpawner;

		public GameUIManager(
			ViewProvider viewProvider,
			Transform uiRoot,
			BuildingManager buildingManager,
			MoneyManager moneyManager,
			WaveSpawner waveSpawner,
			Turret[] availableTurrets)
		{
			_viewProvider = viewProvider;
			_uiRoot = uiRoot;
			_buildingManager = buildingManager;
			_moneyManager = moneyManager;
			_waveSpawner = waveSpawner;
			_availableTurrets = availableTurrets;
		}

		public void InstantiateUi()
		{
			var moneyView = Object.Instantiate(_viewProvider.MoneyView, _uiRoot);
			moneyView.Bind(new MoneyViewModel(_moneyManager.CurrentBalance));

			var countdownView = Object.Instantiate(_viewProvider.WaveCountdownView, _uiRoot);
			countdownView.Bind(new WaveCountdownViewModel(_waveSpawner.WaveTimer));

			var turretStore = Object.Instantiate(_viewProvider.TurretStoreView, _uiRoot);
			turretStore.Bind(new TurretStoreViewModel(_availableTurrets, _buildingManager));

			var tipPopup = Object.Instantiate(_viewProvider.TipPopupView, _uiRoot);
			tipPopup.Bind(new TipPopupViewModel());
		}
	}
}