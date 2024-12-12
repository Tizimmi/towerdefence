namespace TowerDefence.Scripts.EnemyLogic.HealthLogic
{
	public class DefaultHealthComponent : HealthComponent
	{
		public override void Init(float maxHealth)
		{
			Health = maxHealth;
		}

		public override void ReduceHealth(float value)
		{
			Health -= value;
			
			if (Health > 0)
				return;

			Health = 0;
            
			OnZeroHealth?.Invoke();
		}
	}
}