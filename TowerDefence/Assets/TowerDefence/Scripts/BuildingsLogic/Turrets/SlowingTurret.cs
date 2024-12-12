using TowerDefence.Scripts.BuffsLogic;
using TowerDefence.Scripts.BuffsLogic.ConcreteBuffs;
using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic.Turrets
{
	public class SlowingTurret : WithTargetTurret
	{
		[Header("Slowing stats")]
		[SerializeField]
		private float _tickTime = .5f;
		[SerializeField]
		private float _speedMultiplier;

		[Header("Dependencies")]
		[SerializeField]
		private LineRenderer _lineRenderer;
		[SerializeField]
		private Transform _firePoint;
		
		private float _cooldownTimer;

		private SpeedBuff _speedBuff;

		private bool test = false;

		private void Start()
		{
			InvokeRepeating(nameof(GetTarget), 0f, 0.5f);
			_speedBuff = new(_speedMultiplier, false);
		}
		
		private void Update()
		{
			_cooldownTimer -= Time.deltaTime;

			if (Target == null)
			{
				return;
			}

			if (Vector3.Distance(transform.position, Target.transform.position) > _range + _rotationFollowOffset)
				return;
			
			FollowTarget();
			
			UpdateLaser();
			
			if (_cooldownTimer <= 0)
			{
				Attack();
				_cooldownTimer = _tickTime;
			}
		}

		public override void Attack()
		{
			Target._buffManager.AddBuff(new TimedBuff(Target._buffManager, _speedBuff, _tickTime, false));
			Target._healthComponent.ReduceHealth(_damage);
		}

		private void UpdateLaser()
		{
			if (Vector3.Distance(transform.position, Target.transform.position) > _range || Target == null)
			{
				_lineRenderer.enabled = false;
				return;
			}

			_lineRenderer.enabled = true;
			_lineRenderer.SetPosition(0, _firePoint.position);
			_lineRenderer.SetPosition(1, Target.transform.position);
		}
	}
}