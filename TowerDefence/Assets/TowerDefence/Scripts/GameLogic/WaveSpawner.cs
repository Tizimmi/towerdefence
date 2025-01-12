using Plugins.ReactivePropertyModule;
using System.Collections;
using TowerDefence.Scripts.GlobalLogic;
using TowerDefence.Scripts.WaypointsSystem;
using UnityEngine;

namespace TowerDefence.Scripts.GameLogic
{
	public class WaveSpawner
	{
		public ReactiveProperty<float> WaveTimer { get; } = new(0);

		private int _currentWaveIndex;
		private readonly ICoroutineRunner _coroutineRunner;

		private readonly Transform _enemyRoot;

		private readonly WaveInfo[] _waveInfos;
		private readonly Waypoints _waypoints;

		public WaveSpawner(ICoroutineRunner coroutineRunner, WaveInfo[] waveInfos)
		{
			_coroutineRunner = coroutineRunner;
			_waveInfos = waveInfos;
		}

		private void TrySpawnWave()
		{
			if (WaveTimer.Value <= 0)
			{
				if (_currentWaveIndex < _waveInfos.Length)
				{
					_coroutineRunner.StartCoroutine(SpawnWave(_waveInfos[_currentWaveIndex]));
				}
				else
				{
					// TODO: конец уровня победой
					_currentWaveIndex = 0;
					_coroutineRunner.StartCoroutine(SpawnWave(_waveInfos[_currentWaveIndex]));
				}

				WaveTimer.Value = _waveInfos[_currentWaveIndex]._waveCooldown;
			}

			WaveTimer.Value -= Time.deltaTime;
		}

		private IEnumerator SpawnWave(WaveInfo wave)
		{
			foreach (var enemy in wave.GetEnemies())
				yield return new WaitForSeconds(_waveInfos[_currentWaveIndex]._spawnRate);

			_currentWaveIndex++;
		}
	}
}