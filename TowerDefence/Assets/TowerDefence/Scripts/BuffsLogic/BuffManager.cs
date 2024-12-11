using System.Collections.Generic;
using TowerDefence.Scripts.EnemyLogic.EnemyStats;

namespace TowerDefence.Scripts.BuffsLogic
{
	public class BuffManager : IBuffable
	{
		private readonly EnemyStats _baseStats;
		private EnemyStats _currentStats;
		
		public BuffManager(EnemyStats baseStats)
		{
			_baseStats = baseStats;
			_currentStats = baseStats;
		}

		private readonly List<IBuff> _buffs = new();

		public void AddBuff(IBuff buff)
		{
			_buffs.Add(buff);
			
			ApplyBuffs();
		}

		public void RemoveBuff(IBuff buff)
		{
			_buffs.Remove(buff);
		}

		private void ApplyBuffs()
		{
			_currentStats = _baseStats;

			foreach (var b in _buffs)
			{
				b.ApplyBuff(_currentStats);
			}
		}
	}
}