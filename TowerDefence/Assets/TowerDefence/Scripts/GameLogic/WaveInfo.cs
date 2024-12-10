using TowerDefence.Scripts.EnemyLogic;
using UnityEngine;

namespace TowerDefence.Scripts.GameLogic
{
	[System.Serializable]
	public class WaveInfo
	{
		[SerializeField]
		public Enemy[] _enemies;
		[SerializeField]
		public float _spawnRate;
		[SerializeField]
		public float _waveCooldown;

		public Enemy[] GetEnemies()
		{
			return _enemies;
		}
	}
}