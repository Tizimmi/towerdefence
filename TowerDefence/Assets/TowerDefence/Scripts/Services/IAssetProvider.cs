using UnityEngine;

namespace TowerDefence.Scripts.Services
{
	public interface IAssetProvider : IService
	{
		GameObject InstantiatePrefab(string path);
		T InstantiatePrefab<T>(string path);
		GameObject InstantiatePrefab(string path, Vector3 at, Transform parent);
		T InstantiatePrefab<T>(string path, Vector3 at, Transform parent);
	}
}