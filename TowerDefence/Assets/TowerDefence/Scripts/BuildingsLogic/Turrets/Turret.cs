using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic.Turrets
{
	public abstract class Turret : MonoBehaviour
	{
		[SerializeField]
		protected int _damage;
		[SerializeField]
		protected float _range;
		[SerializeField]
		public int _value;

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawWireSphere(transform.position, _range);
		}

		public abstract void Attack();
	}
}