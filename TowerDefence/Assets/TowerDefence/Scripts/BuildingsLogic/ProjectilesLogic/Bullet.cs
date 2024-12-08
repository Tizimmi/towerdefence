using TowerDefence.Scripts.EnemyLogic;
using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic.ProjectilesLogic
{
	public class Bullet : MonoBehaviour
	{
		[SerializeField]
		private int _speed;
		
		private int _damage;
		private Enemy _target;

		public void FindTarget(Enemy target, int damage)
		{
			_target = target;
			_damage = damage;
		}

		private void Update()
		{
			if (_target == null)
			{
				Destroy(gameObject);
				return;
			}

			var direction = _target.transform.position - transform.position;
			var distance = _speed * Time.deltaTime;

			if (direction.magnitude <= distance)
			{
				_target._healthComponent.ReduceHealth(_damage);
				Destroy(gameObject);
				return;
			}
			
			transform.Translate(direction.normalized * distance, Space.World);
		}
	}
}