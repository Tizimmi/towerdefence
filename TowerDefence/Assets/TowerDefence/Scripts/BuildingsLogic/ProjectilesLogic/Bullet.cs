using System;
using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic.ProjectilesLogic
{
	public class Bullet : MonoBehaviour
	{
		[SerializeField]
		private int _speed;

		private Transform _target;

		public void FindTarget(Transform target)
		{
			_target = target;
		}

		private void Update()
		{
			if (_target == null)
			{
				Destroy(gameObject);
				return;
			}

			var direction = _target.position - transform.position;
			var distance = _speed * Time.deltaTime;

			if (direction.magnitude <= distance)
			{
				Destroy(gameObject);
				return;
			}
			
			transform.Translate(direction.normalized * distance, Space.World);
		}
	}
}