using System.Collections.Generic;
using TowerDefence.Scripts.EnemyLogic;
using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic
{
	public class SingleTargetTurret : Turret
	{
		[SerializeField]
		private SphereCollider _rangeCollider;
		[SerializeField]
		private int _damage;
		[SerializeField]
		private float _rotationSpeed = 5f;

		private Enemy _target;

		private readonly List<Enemy> _validTargets = new();

		private void Start()
		{
			_rangeCollider.radius = _range;
		}

		private void Update()
		{
			
		}

		private void FixedUpdate()
		{

		}

		public override void Attack()
		{
			FollowTarget();
			
			if (_target == null || !(Vector3.Distance(transform.position, _target.transform.position) < _range))
				return;

			_target._healthComponent.ReduceHealth(_damage);
			Debug.Log("Casting spell");
		}

		private void FollowTarget()
		{
			var direction = _target.transform.position - transform.position;
			var lookRotation = Quaternion.LookRotation(direction);
			var rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed).eulerAngles;
			transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
		}
		
		public void GetTarget()
		{
			if (_validTargets.Count == 0)
				return;

			_target = _validTargets[0];
				
			var position = transform.position;

			var newTarget = _target;
			
			foreach (var target in _validTargets)
			{
				var isCurrentClosest = Vector3.Distance(position, target.transform.position) <
										Vector3.Distance(position, _target.transform.position);

				newTarget = isCurrentClosest ? target : _target;
			}

			_target = newTarget;
		}
	}
}