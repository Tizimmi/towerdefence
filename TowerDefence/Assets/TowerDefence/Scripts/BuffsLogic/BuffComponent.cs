using System.Collections.Generic;
using TowerDefence.Scripts.EnemyLogic.EnemyStats;

namespace TowerDefence.Scripts.BuffsLogic
{
	public class BuffComponent : IBuffable
	{
		private EnemyStats _baseStats;
		private EnemyStats _currentStats;
		
		public BuffComponent(EnemyStats baseStats)
		{
			_baseStats = baseStats;
			_currentStats = baseStats;
		}
		
		protected readonly List<IBuff> Buffs = new();

		public void AddBuff(IBuff buff)
		{
			Buffs.Add(buff);
			
			ApplyBuffs();
		}

		public void RemoveBuff(IBuff buff)
		{
			Buffs.Remove(buff);
		}

		private void ApplyBuffs()
		{
			_currentStats = _baseStats;

			foreach (var b in Buffs)
			{
				b.ApplyBuff(_currentStats);
			}
		}
	}
}