using TowerDefence.Scripts.EnemyLogic.EnemyStats;

namespace TowerDefence.Scripts.BuffsLogic.ConcreteBuffs
{
	public class SpeedBuff : IBuff
	{
		private readonly float _speedMultiplier;

		public bool IsStackable { get; }

		public SpeedBuff(float speedMultiplier, bool isStackable)
		{
			_speedMultiplier = speedMultiplier;
			IsStackable = isStackable;
		}

		public EnemyStats ApplyBuff(EnemyStats baseStats)
		{
			var newStats = baseStats;
			newStats.MovementSpeed *= _speedMultiplier;
			return newStats;
		}
	}
}