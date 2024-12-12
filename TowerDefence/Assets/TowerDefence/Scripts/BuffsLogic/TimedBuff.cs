using Plugins.Timer.SyncedTimer.Scripts;
using TowerDefence.Scripts.EnemyLogic.EnemyStats;

namespace TowerDefence.Scripts.BuffsLogic
{
	public class TimedBuff : IBuff
	{
		private readonly IBuffable _target;
		private readonly IBuff _coreBuff;
		private readonly float _seconds;

		private readonly SyncedTimer _timer;
		private bool _isTimerOn;

		public bool IsStackable { get; }

		public TimedBuff(IBuffable target, IBuff coreBuff, float seconds,
			bool isStackable)
		{
			_target = target;
			_coreBuff = coreBuff;
			_seconds = seconds;
			IsStackable = isStackable;
			_isTimerOn = false;

			_timer = new SyncedTimer(TimerType.UpdateTick);
		}

		public EnemyStats ApplyBuff(EnemyStats baseStats)
		{
			var newStats = _coreBuff.ApplyBuff(baseStats);

			if (_isTimerOn == false)
			{
				_isTimerOn = true;
				
				_timer.Start(_seconds);

				_timer.TimerFinished += () =>
				{
					_target.RemoveBuff(this);
				};
			}

			return newStats;
		}
	}
}