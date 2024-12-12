using TowerDefence.Scripts.EnemyLogic.EnemyStats;

namespace TowerDefence.Scripts.BuffsLogic
{
	public interface IBuff
	{
		bool IsStackable { get; }
		EnemyStats ApplyBuff(EnemyStats baseStats);
	}
}