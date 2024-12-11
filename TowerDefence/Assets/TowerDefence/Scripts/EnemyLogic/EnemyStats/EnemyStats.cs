using TowerDefence.Scripts.EnemyLogic.HealthLogic;
using TowerDefence.Scripts.EnemyLogic.MovementLogic;
using UnityEngine;

namespace TowerDefence.Scripts.EnemyLogic.EnemyStats
{
	public class EnemyStats : MonoBehaviour
	{
		[SerializeField]
		public HealthComponent _healthComponent;
		[SerializeField]
		public MovementComponent _movementComponent;
		[SerializeField]
		public int _killValue;
	}
}