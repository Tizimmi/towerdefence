using TowerDefence.Scripts.BuildingsLogic;
using TowerDefence.Scripts.GameUI;
using Zenject;

namespace TowerDefence.Scripts.GameLogic.LevelLogic
{
	public class Level
	{
		public MoneyManager MoneyManager { get; }
		public BuildingManager BuildingManager { get; private set; }
		public WaveSpawner WaveSpawner { get; }

		[Inject]
		private readonly LevelConfig _levelConfig;

		public Level(LevelConfig levelConfig, WaveSpawner waveSpawner, TipPopupViewModel tipPopupViewModel)
		{
			_levelConfig = levelConfig;
			WaveSpawner = waveSpawner;
			MoneyManager = new MoneyManager(_levelConfig.StartingBalance);
			BuildingManager = new BuildingManager(MoneyManager, _levelConfig.AvailableTurrets[0], tipPopupViewModel );
		}
	}
}