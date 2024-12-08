using System;
using UnityEngine;

namespace TowerDefence.Scripts.EnemyLogic.HealthLogic
{
	public abstract class HealthComponent : MonoBehaviour
	{ 
		[SerializeField]
		protected int _health;

		public Action OnZeroHealth;
		public abstract void ReduceHealth(int value);
	}
}