using JetBrains.Annotations;
using TowerDefence.Scripts.BuildingsLogic;
using TowerDefence.Scripts.GameLogic.LevelLogic;
using UnityEngine;

namespace TowerDefence.Scripts.GameUI
{
	[UsedImplicitly]
	public class GameUIManager
	{
		private MoneyView _moneyView;
		private WaveCountdownView _waveCountdownView;
		private TurretStoreView _turretStoreView;
		private TipPopupView _tipPopupView;
		private readonly Level _level;
		private readonly LevelConfig _levelConfig;
		private readonly BuildingManager _buildingManager;
		private readonly RectTransform _uiRoot;
		
		private readonly TipPopupViewModel _tipPopupViewModel;

		public GameUIManager(RectTransform uiRoot, Level level, LevelConfig levelConfig, BuildingManager buildingManager, TipPopupViewModel tipPopupViewModel)
		{
			_uiRoot = uiRoot;
			_level = level;
			_levelConfig = levelConfig;
			_buildingManager = buildingManager;
			_tipPopupViewModel = tipPopupViewModel;

			_moneyView = _levelConfig.MoneyView;
			_waveCountdownView = _levelConfig.WaveCountdownView;
			_turretStoreView = _levelConfig.TurretStoreView;
			_tipPopupView = _levelConfig.TipPopupView;

			InstantiateUi();
		}

		private void InstantiateUi()
		{
			_moneyView = Object.Instantiate(_moneyView, _uiRoot);
			_moneyView.Bind(new MoneyViewModel(_level.MoneyManager.CurrentBalance));

			_waveCountdownView = Object.Instantiate(_waveCountdownView, _uiRoot);
			_waveCountdownView.Bind(new WaveCountdownViewModel(_level.WaveSpawner.WaveTimer));

			_turretStoreView = Object.Instantiate(_turretStoreView, _uiRoot);
			_turretStoreView.Bind(new TurretStoreViewModel(_levelConfig, _buildingManager));

			_tipPopupView = Object.Instantiate(_tipPopupView, _uiRoot);
			_tipPopupView.Bind(_tipPopupViewModel);
		}
	}
}