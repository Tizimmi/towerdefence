using TowerDefence.Scripts.BuildingsLogic;
using TowerDefence.Scripts.GameUI;
using TowerDefence.Scripts.GlobalLogic;
using UnityEngine;

namespace TowerDefence.Scripts.GameLogic.LevelLogic
{
	public class Level
	{
		private readonly BuildingManager _buildingManager;
		private readonly LevelConfig _config;
		private readonly ICoroutineRunner _coroutineRunner;
		private readonly MoneyManager _moneyManager;
		private readonly GameUIManager _uiManager;
		private readonly WaveSpawner _waveSpawner;

		public Level(
			LevelConfig config,
			ICoroutineRunner coroutineRunner,
			ViewProvider viewProvider,
			Transform uiRoot)
		{
			_config = config;
			_coroutineRunner = coroutineRunner;
			_moneyManager = new MoneyManager(_config.StartingBalance);
			_buildingManager = new BuildingManager(_moneyManager, _config.AvailableTurrets[0]);
			_waveSpawner = new WaveSpawner(_coroutineRunner, _config.WaveInfos);

			_uiManager = new GameUIManager(viewProvider,
				uiRoot,
				_buildingManager,
				_moneyManager,
				_waveSpawner,
				_config.AvailableTurrets);
		}

		public void CreateUI()
		{
			_uiManager.InstantiateUi();
		}
	}
}