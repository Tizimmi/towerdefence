using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic.Turrets
{
	public abstract class Turret : MonoBehaviour
	{
		[SerializeField]
		public int _value;
		[SerializeField]
		protected float _range;

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawWireSphere(transform.position, _range);
		}

		public abstract void Attack();
	}
}