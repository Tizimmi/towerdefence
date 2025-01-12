using TowerDefence.Scripts.Services;
using UnityEngine;
using static TowerDefence.Scripts.EnemyLogic.EnemyType;

namespace TowerDefence.Scripts.GlobalLogic.GameFactory
{
	public class GameFactory : IGameFactory
	{
		private readonly IAssetProvider _assetProvider;

		public GameFactory(IAssetProvider assetProvider)
		{
			_assetProvider = assetProvider;
		}

		public GameObject CreateDefaultGoblin(Vector3 at, Transform parent)
		{
			return _assetProvider.InstantiatePrefab(ResourcesPathProvider.EnemyPathMap[DefaultGoblin], at, parent);
		}
	}
}