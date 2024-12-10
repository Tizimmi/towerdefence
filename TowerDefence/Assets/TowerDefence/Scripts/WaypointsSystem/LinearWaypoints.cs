using UnityEngine;

namespace TowerDefence.Scripts.WaypointsSystem
{
	public class LinearWaypoints : Waypoints
	{
		private void OnDrawGizmos()
		{
			DrawPath();
		}

		public override void DrawPath()
		{
			foreach (Transform t in transform)
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawWireSphere(t.position, .5f);
			}

			for (var i = 0; i < transform.childCount - 1; i++)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
			}
		}

		public override Transform GetNextWaypoint(Transform currentWaypoint)
		{
			if (currentWaypoint == null)
				return transform.GetChild(0);

			var index = currentWaypoint.GetSiblingIndex();

			return index < transform.childCount - 1 ? transform.GetChild(index + 1) : null;
		}
	}
}