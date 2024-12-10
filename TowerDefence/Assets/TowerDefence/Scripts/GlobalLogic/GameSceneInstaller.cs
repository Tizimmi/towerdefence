using TowerDefence.Scripts.BuildingsLogic;
using TowerDefence.Scripts.GameLogic;
using TowerDefence.Scripts.GameLogic.LevelLogic;
using TowerDefence.Scripts.GameUI;
using TowerDefence.Scripts.WaypointsSystem;
using UnityEngine;
using Zenject;

namespace TowerDefence.Scripts.GlobalLogic
{
	public class GameSceneInstaller : MonoInstaller
	{
		[SerializeField]
		private LevelConfig _levelConfig;
		[SerializeField]
		private RectTransform _uiRoot;
		[SerializeField]
		private Transform _enemyRoot;
		[SerializeField]
		private Waypoints _waypoints;
		[SerializeField]
		private WaveSpawner _waveSpawner;

		private Level _level;

		public override void InstallBindings()
		{
			_level = new Level(_levelConfig, _waveSpawner);

			Container.Bind<GameUIManager>().AsSingle().NonLazy();
			Container.Bind<BuildingManager>().FromInstance(_level.BuildingManager).AsSingle();
			Container.Bind<MoneyManager>().FromInstance(_level.MoneyManager).AsSingle();
			Container.Bind<GamePrefabFactory>().AsSingle().NonLazy();

			Container.BindInstance(_waveSpawner).AsSingle();
			Container.BindInstance(_level).AsSingle();
			Container.BindInstance(_uiRoot).AsSingle();
			Container.BindInstance(_levelConfig).AsSingle();
			Container.BindInstance(_enemyRoot).AsSingle();
			Container.BindInstance(_waypoints).AsSingle();
		}
	}
}