using Plugins.ReactivePropertyModule;
using System.Collections;
using TowerDefence.Scripts.EnemyLogic;
using TowerDefence.Scripts.GameLogic.LevelLogic;
using TowerDefence.Scripts.GlobalLogic;
using TowerDefence.Scripts.WaypointsSystem;
using UnityEngine;
using Zenject;

namespace TowerDefence.Scripts.GameLogic
{
	public class WaveSpawner : MonoBehaviour
	{
		[Inject]
		private readonly GamePrefabFactory _gamePrefabFactory;
		[Inject]
		private readonly LevelConfig _levelConfig;
		[Inject]
		private readonly Waypoints _waypoints;
		[Inject]
		private readonly Transform _enemyRoot;
		
		private WaveInfo[] _waveInfos;
		
		private int _currentWaveIndex;

		private ReactiveProperty<float> _waveTimer = new(0);
		public ReactiveProperty<float> WaveTimer => _waveTimer;
		
		private void Start()
		{
			_waveInfos = _levelConfig.WaveInfos;
			
			WaveTimer.Value = _waveInfos[_currentWaveIndex]._waveCooldown; // TODO: Мэйби сделать отдельную переменную для определения первого таймера?
		}

		private void Update()
		{
			TrySpawnWave();
		}

		private void TrySpawnWave()
		{
			if (WaveTimer.Value <= 0)
			{
				if (_currentWaveIndex < _waveInfos.Length)
				{
					StartCoroutine(SpawnWave(_waveInfos[_currentWaveIndex]));
				}
				else
				{
					// TODO: конец уровня победой
					_currentWaveIndex = 0;
					StartCoroutine(SpawnWave(_waveInfos[_currentWaveIndex]));
				}
				
				WaveTimer.Value = _waveInfos[_currentWaveIndex]._waveCooldown;
			}
			
			WaveTimer.Value -= Time.deltaTime;
		}

		private IEnumerator SpawnWave(WaveInfo wave)
		{
			foreach (var enemy in wave.GetEnemies())
			{
				var c = _gamePrefabFactory.InstantiatePrefab<Enemy>(enemy,
					_enemyRoot.position,
					Quaternion.identity,
					_enemyRoot);
				
				c.Init(_waypoints);
				yield return new WaitForSeconds(_waveInfos[_currentWaveIndex]._spawnRate);
			}
			
			_currentWaveIndex++;
		}
	}
}