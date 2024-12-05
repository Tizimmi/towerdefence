using System;
using TowerDefence.Scripts.WaypointsSystem;
using UnityEngine;

namespace TowerDefence.Scripts.EnemyLogic
{
	public abstract class Enemy : MonoBehaviour
	{
		[SerializeField]
		protected int _health;
		[SerializeField]
		protected float _movementSpeed;
		[SerializeField]
		protected Waypoints _path;

		protected Transform CurrentWaypoint;
		
		public abstract void Move();
	}
}