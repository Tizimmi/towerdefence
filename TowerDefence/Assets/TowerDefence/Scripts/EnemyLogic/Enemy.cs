using TowerDefence.Scripts.BuffsLogic;
using TowerDefence.Scripts.EnemyLogic.HealthLogic;
using TowerDefence.Scripts.EnemyLogic.MovementLogic;
using UnityEngine;

namespace TowerDefence.Scripts.EnemyLogic
{
	public abstract class Enemy : MonoBehaviour
	{
		[SerializeField]
		public BuffManager _buffManager;

		[SerializeField]
		public HealthComponent _healthComponent;

		[SerializeField]
		public MovementComponent _movementComponent;

		protected abstract void OnZeroHealth();
	}
}