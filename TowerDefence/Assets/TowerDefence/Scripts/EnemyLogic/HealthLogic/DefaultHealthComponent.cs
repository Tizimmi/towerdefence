namespace TowerDefence.Scripts.EnemyLogic.HealthLogic
{
	public class DefaultHealthComponent : HealthComponent
	{ 
		public override void ReduceHealth(float value)
		{
			_health -= value;
			
			if (_health > 0)
				return;

			_health = 0;
            
			OnZeroHealth?.Invoke();
		}
	}
}