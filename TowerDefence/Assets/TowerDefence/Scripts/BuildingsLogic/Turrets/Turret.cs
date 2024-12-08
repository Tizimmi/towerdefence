using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic.Turrets
{
	public abstract class Turret : MonoBehaviour
	{
		[SerializeField]
		protected float _range;
		[SerializeField]
		public int _value;

		public abstract void Attack();

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawWireSphere(transform.position, _range);
		}
	}
}