using System;
using TowerDefence.Scripts.WaypointsSystem;
using UnityEngine;

namespace TowerDefence.Scripts.EnemyLogic.MovementLogic
{
	public class DefaultMovementComponent : MovementComponent
	{
		public override void Init(Waypoints path)
		{
			Path = path;

			CurrentWaypoint = Path.GetNextWaypoint(CurrentWaypoint);
			transform.position = CurrentWaypoint.position;

			CurrentWaypoint = Path.GetNextWaypoint(CurrentWaypoint);
		}

		public override void Move(float speed)
		{
			if (CurrentWaypoint == null)
			{
				Destroy(gameObject);
				return;
			}

			transform.position = Vector3.MoveTowards(transform.position, CurrentWaypoint.position, speed * Time.deltaTime);

			if (Vector3.Distance(transform.position, CurrentWaypoint.position) < _pathOffset)
				CurrentWaypoint = Path.GetNextWaypoint(CurrentWaypoint);
		}
	}
}