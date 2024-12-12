using System;
using UnityEngine;

namespace TowerDefence.Scripts.EnemyLogic.HealthLogic
{
	public abstract class HealthComponent : MonoBehaviour
	{
		protected float Health;

		public Action OnZeroHealth;
		public abstract void ReduceHealth(float value);
		public abstract void Init(float maxHealth);
	}
}