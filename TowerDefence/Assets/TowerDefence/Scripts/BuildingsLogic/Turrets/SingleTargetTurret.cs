﻿using System.Linq;
using TowerDefence.Scripts.BuildingsLogic.ProjectilesLogic;
using TowerDefence.Scripts.EnemyLogic;
using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic.Turrets
{
	public class SingleTargetTurret : Turret
	{
		[SerializeField]
		private int _damage;
		[SerializeField]
		private float _attackCooldown = 1.5f;

		[Header("Dependencies")]
		[SerializeField]
		private float _rotationSpeed = 5f;
		[SerializeField]
		private float _rotationFollowOffset = 5f;
		[SerializeField]
		private ParticleSystem _particle;
		[SerializeField]
		private Transform _bulletPoint;
		[SerializeField]
		private Bullet _bulletPrefab;
		private float _cooldownTimer;

		private Enemy _target;

		private void Start()
		{
			InvokeRepeating(nameof(GetTarget), 0f, 0.5f);
		}

		private void Update()
		{
			_cooldownTimer -= Time.deltaTime;

			if (_target == null)
				return;

			if (Vector3.Distance(transform.position, _target.transform.position) < _range + _rotationFollowOffset)
				FollowTarget();

			if (_cooldownTimer <= 0)
			{
				Attack();
				_cooldownTimer = _attackCooldown;
			}
		}

		public override void Attack()
		{
			if (Vector3.Distance(transform.position, _target.transform.position) >= _range)
				return;

			_particle.Play();

			var bullet = Instantiate(_bulletPrefab,
				_bulletPoint.position,
				_bulletPoint.rotation,
				_bulletPoint);

			bullet.FindTarget(_target, _damage);
		}

		public void GetTarget() // придумать метод получше, мб через зенжект прокидывать сюда список врагов из спавнера
		{
			var validTargets = GameObject.FindGameObjectsWithTag("Enemy").Select(t => t.GetComponent<Enemy>()).ToList();

			if (validTargets.Count == 0)
				return;

			var position = transform.position;

			Enemy newTarget = null;

			foreach (var target in validTargets)
			{
				if (newTarget == null)
				{
					newTarget = target;
					continue;
				}

				newTarget = Vector3.Distance(position, target.transform.position) < Vector3.Distance(position, newTarget.transform.position)
					? target
					: newTarget;
			}

			_target = newTarget;
		}

		private void FollowTarget()
		{
			var direction = _target.transform.position - transform.position;
			var lookRotation = Quaternion.LookRotation(direction);
			var rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed).eulerAngles;
			transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
		}
	}
}