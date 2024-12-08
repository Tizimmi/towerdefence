using TowerDefence.Scripts.WaypointsSystem;
using UnityEngine;

namespace TowerDefence.Scripts.GameLogic
{
	public class Level : MonoBehaviour
	{
		[SerializeField]
		private WaveSpawner _spawner;
		[SerializeField]
		private Waypoints _waypoints;
	}
}