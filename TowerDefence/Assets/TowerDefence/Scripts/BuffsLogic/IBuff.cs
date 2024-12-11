using TowerDefence.Scripts.EnemyLogic.EnemyStats;

namespace TowerDefence.Scripts.BuffsLogic
{
	public interface IBuff
	{
		EnemyStats ApplyBuff(EnemyStats baseStats);
	}
}