using TowerDefence.Scripts.EnemyLogic.EnemyStats;

namespace TowerDefence.Scripts.BuffsLogic.ConcreteBuffs
{
	public class SpeedBuff : IBuff
	{
		private readonly float _speedMultiplier;

		public SpeedBuff(float speedMultiplier)
		{
			_speedMultiplier = speedMultiplier;
		}
		
		public void ApplyBuff(EnemyStats baseStats)
		{
			baseStats._movementComponent._movementSpeed *= _speedMultiplier ;
		}
	}
}