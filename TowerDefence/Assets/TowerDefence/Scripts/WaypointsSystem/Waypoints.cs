using System;
using UnityEngine;

namespace TowerDefence.Scripts.WaypointsSystem
{
    public abstract class Waypoints : MonoBehaviour
    {
        public abstract void DrawPath();
        public abstract Transform GetNextWaypoint(Transform currentWaypoint);
    }
    
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

            for (int i = 0; i < transform.childCount-1; i++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i+1).position);
            }
        }

        public override Transform GetNextWaypoint(Transform currentWaypoint)
        {
            return null;
        }
    }
}
