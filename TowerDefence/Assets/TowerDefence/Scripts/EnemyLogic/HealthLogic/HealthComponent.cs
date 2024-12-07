using UnityEngine;

namespace TowerDefence.Scripts.EnemyLogic.HealthLogic
{
	public abstract class HealthComponent : MonoBehaviour
	{ 
		[SerializeField]
		protected int _health;
		
		public abstract void ReduceHealth(int value);
		protected abstract void OnZeroHealth();
	}
}