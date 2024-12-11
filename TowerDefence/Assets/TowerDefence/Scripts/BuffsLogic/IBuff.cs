using TowerDefence.Scripts.EnemyLogic.EnemyStats;

namespace TowerDefence.Scripts.BuffsLogic
{
	public interface IBuff
	{
		void ApplyBuff(EnemyStats baseStats);
	}
}