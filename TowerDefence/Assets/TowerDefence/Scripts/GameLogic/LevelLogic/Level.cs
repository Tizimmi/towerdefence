using TowerDefence.Scripts.BuildingsLogic;
using Zenject;

namespace TowerDefence.Scripts.GameLogic.LevelLogic
{
	public class Level 
	{
		public MoneyManager MoneyManager { get; private set; }
		public BuildingManager BuildingManager { get; private set; }
		
		private readonly WaveSpawner _waveSpawner;
		public WaveSpawner WaveSpawner => _waveSpawner;

		[Inject]
		private readonly LevelConfig _levelConfig;

		public Level(LevelConfig levelConfig, WaveSpawner waveSpawner)
		{
			_levelConfig = levelConfig;
			_waveSpawner = waveSpawner;
			MoneyManager = new(_levelConfig.StartingBalance);
			BuildingManager = new(MoneyManager, _levelConfig.SelectedTurret);
		}
	}
}