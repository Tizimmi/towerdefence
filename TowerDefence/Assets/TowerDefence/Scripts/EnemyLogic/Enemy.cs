using TowerDefence.Scripts.EnemyLogic.HealthLogic;
using TowerDefence.Scripts.WaypointsSystem;
using UnityEngine;

namespace TowerDefence.Scripts.EnemyLogic
{
	public abstract class Enemy : MonoBehaviour
	{
		[SerializeField]
		public HealthComponent _healthComponent;
		[SerializeField]
		protected float _movementSpeed;
		[SerializeField]
		protected int _killValue;

		protected Waypoints Path;

		protected Transform CurrentWaypoint;
		
		public abstract void Move();
		public abstract void Init(Waypoints path);

		protected abstract void OnZeroHealth();
	}
}