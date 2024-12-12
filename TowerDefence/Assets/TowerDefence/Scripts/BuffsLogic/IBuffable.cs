﻿namespace TowerDefence.Scripts.BuffsLogic
{
	public interface IBuffable
	{
		void AddBuff(IBuff buff);
		void RemoveBuff(IBuff buff);
	}
}