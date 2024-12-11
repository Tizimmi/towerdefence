using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic.Turrets
{
	public class SlowingTurret : WithTargetTurret
	{
		private void Start()
		{
			InvokeRepeating(nameof(GetTarget), 0f, 0.5f);
		}
		
		private void Update()
		{
			if (Target == null)
				return;

			if (Vector3.Distance(transform.position, Target.transform.position) < _range + _rotationFollowOffset)
				FollowTarget();
			
			Attack();
		}

		public override void Attack()
		{
			if (Vector3.Distance(transform.position, Target.transform.position) >= _range)
				return;
			
			Target._healthComponent.ReduceHealth(_damage * Time.deltaTime);
		}
	}
}