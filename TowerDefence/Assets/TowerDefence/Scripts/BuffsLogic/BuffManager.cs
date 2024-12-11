using System.Collections.Generic;
using TowerDefence.Scripts.EnemyLogic.EnemyStats;
using UnityEngine;

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
			if (_buffs.Contains(buff) & buff.IsEffectStackable == false)
			{
				return;
			}
			
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
				_currentStats = b.ApplyBuff(_currentStats);
			}
			
			Debug.Log(_currentStats._movementComponent._movementSpeed + "\t" + _baseStats._movementComponent._movementSpeed);
		}
	}
}