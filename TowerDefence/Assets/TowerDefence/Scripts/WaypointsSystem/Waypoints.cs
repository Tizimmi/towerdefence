using UnityEngine;

namespace TowerDefence.Scripts.WaypointsSystem
{
    public abstract class Waypoints : MonoBehaviour
    {
        public abstract void DrawPath();
        public abstract Transform GetNextWaypoint(Transform currentWaypoint);
    }
}
