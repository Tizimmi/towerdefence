using System;
using TowerDefence.Scripts.EnemyLogic;
using UnityEngine;

namespace TowerDefence.Scripts.GameLogic
{
	[Serializable]
	public class WaveInfo
	{
		[SerializeField]
		public EnemyType[] _enemies;
		[SerializeField]
		public float _spawnRate;
		[SerializeField]
		public float _waveCooldown;

		public EnemyType[] GetEnemies()
		{
			return _enemies;
		}
	}
}