using System;
using UnityEngine;

namespace TowerDefence.Scripts.EnemyLogic.HealthLogic
{
	public abstract class HealthComponent : MonoBehaviour
	{
		[SerializeField]
		protected float _health;

		public Action OnZeroHealth;
		public abstract void ReduceHealth(float value);
	}
}