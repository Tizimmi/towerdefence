using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic
{
	public abstract class Turret : MonoBehaviour
	{
		[SerializeField]
		protected float _range;

		public abstract void Attack();

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawWireSphere(transform.position, _range);
		}
	}
}