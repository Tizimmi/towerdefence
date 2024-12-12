using TowerDefence.Scripts.BuffsLogic;
using TowerDefence.Scripts.BuffsLogic.ConcreteBuffs;
using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic.Turrets
{
	public class SlowingTurret : WithTargetTurret
	{
		[SerializeField]
		private float _tickTime = .5f;
		[SerializeField]
		private float _speedMultiplier;

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
				return;

			if (Vector3.Distance(transform.position, Target.transform.position) < _range + _rotationFollowOffset)
				FollowTarget();
			
			if (_cooldownTimer <= 0)
			{
				Attack();
				_cooldownTimer = _tickTime;
			}
		}

		public override void Attack()
		{
			if (Vector3.Distance(transform.position, Target.transform.position) >= _range)
				return;
			
			Target._buffManager.AddBuff(new TimedBuff(Target._buffManager, _speedBuff, _tickTime, false));
			Target._healthComponent.ReduceHealth(_damage);
		}
	}
}