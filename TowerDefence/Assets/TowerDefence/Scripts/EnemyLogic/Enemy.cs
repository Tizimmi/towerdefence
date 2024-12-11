using TowerDefence.Scripts.BuffsLogic;
using UnityEngine;

namespace TowerDefence.Scripts.EnemyLogic
{
	public abstract class Enemy : MonoBehaviour
	{
		[field:SerializeField]
		public EnemyStats.EnemyStats BaseStats { get; private set; }
		
		public EnemyStats.EnemyStats CurrentStats { get; protected set; }

		public BuffManager BuffManager;

		protected abstract void OnZeroHealth();

		public void Start()
		{
			CurrentStats = BaseStats;
			BuffManager = new BuffManager(BaseStats);
		}
	}
}