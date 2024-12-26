using TowerDefence.Scripts.WaypointsSystem;
using UnityEngine;

namespace TowerDefence.Scripts.EnemyLogic.MovementLogic
{
	public class DefaultMovementComponent : MovementComponent
	{
		[Range(1f, 10f)]
		[SerializeField]
		private float _rotationSpeed;

		public override void Init(Waypoints path)
		{
			Path = path;

			CurrentWaypoint = Path.GetNextWaypoint(CurrentWaypoint);
			transform.position = CurrentWaypoint.position;

			CurrentWaypoint = Path.GetNextWaypoint(CurrentWaypoint);
			
			transform.LookAt(CurrentWaypoint);
		}

		public override void Move(float speed)
		{
			if (CurrentWaypoint == null)
			{
				Destroy(gameObject);
				return;
			}

			transform.position = Vector3.MoveTowards(transform.position, CurrentWaypoint.position, speed * Time.deltaTime);
			
			RotateToWaypoint();

			if (Vector3.Distance(transform.position, CurrentWaypoint.position) < _pathOffset)
				CurrentWaypoint = Path.GetNextWaypoint(CurrentWaypoint);
		}

		private void RotateToWaypoint()
		{
			var direction = CurrentWaypoint.transform.position - transform.position;
			var lookRotation = Quaternion.LookRotation(direction);
			var rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed).eulerAngles;
			transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
		}
	}
}