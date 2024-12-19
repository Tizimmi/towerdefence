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
		private readonly Level _level;
		private readonly LevelConfig _levelConfig;
		private readonly BuildingManager _buildingManager;
		private readonly RectTransform _uiRoot;

		public GameUIManager(RectTransform uiRoot, Level level, LevelConfig levelConfig, BuildingManager buildingManager)
		{
			_uiRoot = uiRoot;
			_level = level;
			_levelConfig = levelConfig;
			_buildingManager = buildingManager;

			_moneyView = _levelConfig.MoneyView;
			_waveCountdownView = _levelConfig.WaveCountdownView;
			_turretStoreView = _levelConfig.TurretStoreView;

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
		}
	}
}