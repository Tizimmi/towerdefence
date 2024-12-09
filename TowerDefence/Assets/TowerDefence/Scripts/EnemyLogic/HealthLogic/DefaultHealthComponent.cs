using TowerDefence.Scripts.GameLogic;
using UnityEngine;
using Zenject;

namespace TowerDefence.Scripts.EnemyLogic.HealthLogic
{
	public class DefaultHealthComponent : HealthComponent
	{
		[SerializeField]
		private ParticleSystem _onHitParticle;
		
		private void Start()
		{
			_onHitParticle.startColor = gameObject.GetComponent<Renderer>().material.color;
		}

		public override void ReduceHealth(int value)
		{
			_health -= value;

			_onHitParticle.Play();
			
			if (_health > 0)
				return;

			_health = 0;
			OnZeroHealth.Invoke();
		}
	}
}