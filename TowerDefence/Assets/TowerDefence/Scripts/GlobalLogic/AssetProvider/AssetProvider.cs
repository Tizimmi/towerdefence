using TowerDefence.Scripts.Services;
using UnityEngine;
using Zenject;

namespace TowerDefence.Scripts.GlobalLogic.AssetProvider
{
	public class AssetProvider : IAssetProvider
	{
		private readonly DiContainer _container;

		public AssetProvider(DiContainer container)
		{
			_container = container;
		}

		public GameObject InstantiatePrefab(string path)
		{
			var load = Resources.Load(path);
			return _container.InstantiatePrefab(load);
		}

		public T InstantiatePrefab<T>(string path)
		{
			var load = Resources.Load(path);
			return InstantiatePrefab(path).GetComponent<T>();
		}

		public GameObject InstantiatePrefab(string path, Vector3 at, Transform parent)
		{
			var load = Resources.Load(path);
			return _container.InstantiatePrefab(load,
				at,
				Quaternion.identity,
				parent);
		}

		public T InstantiatePrefab<T>(string path, Vector3 at, Transform parent)
		{
			var load = Resources.Load(path);
			return _container.InstantiatePrefab(load,
					at,
					Quaternion.identity,
					parent)
				.GetComponent<T>();
		}
	}
}