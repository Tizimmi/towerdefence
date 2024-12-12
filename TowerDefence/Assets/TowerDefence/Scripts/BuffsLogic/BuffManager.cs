using System;
using System.Collections.Generic;
using TowerDefence.Scripts.EnemyLogic.EnemyStats;
using UnityEngine;

namespace TowerDefence.Scripts.BuffsLogic
{
	[Serializable]
	public class BuffManager : IBuffable
	{
		[field:SerializeField] 
		public EnemyStats BaseStats { get; private set; }
		
		public EnemyStats CurrentStats { get; set; }

		public void Init()
		{
			CurrentStats = BaseStats;
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
			
			ApplyBuffs();
		}
		
		private void ApplyBuffs()
		{
			CurrentStats = BaseStats;

			var buffs = new List<string>(); // blyat' costyl' pizdec prosto
			
			foreach (var b in _buffs)
			{
				if (buffs.Contains(nameof(b)) & !b.IsStackable)
					return;
				buffs.Add(nameof(b));
				CurrentStats = b.ApplyBuff(CurrentStats);
			}
			
			buffs.Clear();
		}
	}
}