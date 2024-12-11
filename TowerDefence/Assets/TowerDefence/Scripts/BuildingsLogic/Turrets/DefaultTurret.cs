using TowerDefence.Scripts.BuildingsLogic.ProjectilesLogic;
using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic.Turrets
{
	public class DefaultTurret : WithTargetTurret
	{
		[SerializeField]
		private float _attackCooldown = 1.5f;

		[Header("Dependencies")]
		[SerializeField]
		private ParticleSystem _particle;
		[SerializeField]
		private Transform _bulletPoint;
		[SerializeField]
		private Bullet _bulletPrefab;
		
		private float _cooldownTimer;

		private void Start()
		{
			InvokeRepeating(nameof(GetTarget), 0f, 0.5f);
		}

		private void Update()
		{
			_cooldownTimer -= Time.deltaTime;

			if (Target == null)
				return;

			if (Vector3.Distance(transform.position, Target.transform.position) < _range + _rotationFollowOffset)
				FollowTarget();

			if (_cooldownTimer <= 0)
			{
				Attack();
				_cooldownTimer = _attackCooldown;
			}
		}

		public override void Attack()
		{
			if (Vector3.Distance(transform.position, Target.transform.position) >= _range)
				return;

			_particle.Play();

			var bullet = Instantiate(_bulletPrefab,
				_bulletPoint.position,
				_bulletPoint.rotation,
				_bulletPoint);

			bullet.FindTarget(Target, _damage);
		}
	}
}