﻿using System;
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

			foreach (var b in _buffs)
			{
				CurrentStats = b.ApplyBuff(CurrentStats);
			}
		}
	}
}