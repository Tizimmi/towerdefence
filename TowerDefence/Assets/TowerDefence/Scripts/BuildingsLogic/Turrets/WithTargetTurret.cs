using System.Linq;
using TowerDefence.Scripts.EnemyLogic;
using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic.Turrets
{
	public class WithTargetTurret : Turret
	{
		[SerializeField]
		protected float _rotationSpeed;
		[SerializeField]
		protected float _rotationFollowOffset;
		
		protected Enemy Target;

		public override void Attack()
		{
			throw new System.NotImplementedException();
		}
		
		protected void GetTarget() // придумать метод получше, мб через зенжект прокидывать сюда список врагов из спавнера
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

			Target = newTarget;
		}

		protected void FollowTarget()
		{
			var direction = Target.transform.position - transform.position;
			var lookRotation = Quaternion.LookRotation(direction);
			var rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed).eulerAngles;
			transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
		}
	}
}