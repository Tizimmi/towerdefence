using UnityEngine;

namespace TowerDefence.Scripts.Services
{
	public interface IGameFactory : IService

	{
		GameObject CreateDefaultGoblin(Vector3 at, Transform parent);
	}
}