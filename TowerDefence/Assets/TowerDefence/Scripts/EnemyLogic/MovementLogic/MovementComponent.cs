using TowerDefence.Scripts.WaypointsSystem;
using UnityEngine;

namespace TowerDefence.Scripts.EnemyLogic.MovementLogic
{
	public abstract class MovementComponent : MonoBehaviour
	{
		[Range(0.01f, 2f)]
		[SerializeField]
		protected float _pathOffset;

		protected float MovementSpeed { get; set; }
		
		protected Transform CurrentWaypoint;

		protected Waypoints Path;
		
		public abstract void Move();
		
		public abstract void Init(Waypoints path, float moveSpeed);
	}
}