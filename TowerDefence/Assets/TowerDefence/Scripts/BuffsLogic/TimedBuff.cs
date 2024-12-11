using Plugins.Timer.SyncedTimer.Scripts;
using TowerDefence.Scripts.EnemyLogic.EnemyStats;
using UnityEngine;

namespace TowerDefence.Scripts.BuffsLogic
{
	public class TimedBuff : IBuff
	{
		private readonly IBuffable _target;
		private readonly IBuff _coreBuff;
		private readonly float _seconds;

		private readonly SyncedTimer _timer;

		public bool IsEffectStackable { get; }

		public TimedBuff(IBuffable target, IBuff coreBuff, float seconds,
			bool isEffectStackable)
		{
			_target = target;
			_coreBuff = coreBuff;
			_seconds = seconds;
			IsEffectStackable = isEffectStackable;

			_timer = new SyncedTimer(TimerType.UpdateTick);
		}

		public EnemyStats ApplyBuff(EnemyStats baseStats)
		{
			var newStats = _coreBuff.ApplyBuff(baseStats);
			
			_timer.Start(_seconds);

			_timer.TimerFinished += () =>
			{
				Debug.Log("REMOVE BUFF");
				_target.RemoveBuff(_coreBuff);
			};

			return newStats;
		}
	}
}