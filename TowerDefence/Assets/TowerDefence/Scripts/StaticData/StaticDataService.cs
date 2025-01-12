using System.Collections.Generic;
using System.Linq;
using TowerDefence.Scripts.EnemyLogic;
using TowerDefence.Scripts.Services;
using UnityEngine;

namespace TowerDefence.Scripts.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private Dictionary<EnemyType, EnemyStaticData> _enemies;

		public void LoadEnemies()
		{
			_enemies = Resources.LoadAll<EnemyStaticData>("Configs/EnemyConfigs").ToDictionary(x => x.EnemyType, x => x);
		}

		public EnemyStaticData ForEnemy(EnemyType type)
		{
			return _enemies.GetValueOrDefault(type);
		}
	}
}