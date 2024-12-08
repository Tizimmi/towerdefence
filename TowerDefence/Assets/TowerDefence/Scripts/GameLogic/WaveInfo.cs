using System;
using System.Collections.Generic;
using TowerDefence.Scripts.EnemyLogic;
using UnityEngine;

namespace TowerDefence.Scripts.GameLogic
{
	public abstract class WaveInfo : ScriptableObject
	{
		[SerializeField]
		protected List<Enemy> _enemies;

		public List<Enemy> GetEnemies()
		{
			return _enemies;
		}
	}
}