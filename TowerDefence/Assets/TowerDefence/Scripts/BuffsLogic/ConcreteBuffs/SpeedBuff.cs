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
		
		public EnemyStats ApplyBuff(EnemyStats baseStats)
		{
			var newStats = baseStats;
			newStats.MovementSpeed *= _speedMultiplier;
			return newStats;
		}
	}
}