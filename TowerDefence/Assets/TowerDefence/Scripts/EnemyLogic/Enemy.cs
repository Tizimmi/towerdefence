using TowerDefence.Scripts.BuffsLogic;
using TowerDefence.Scripts.EnemyLogic.HealthLogic;
using TowerDefence.Scripts.EnemyLogic.MovementLogic;
using UnityEngine;

namespace TowerDefence.Scripts.EnemyLogic
{
	public abstract class Enemy : MonoBehaviour
	{
		[field:SerializeField]
		public EnemyStats.EnemyStats BaseStats { get; private set; }

		[SerializeField]
		public HealthComponent _healthComponent;

		[SerializeField]
		public MovementComponent _movementComponent;
		
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