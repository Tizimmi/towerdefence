using Plugins.ReactivePropertyModule;
using System.Collections;
using System.Collections.Generic;
using TowerDefence.Scripts.EnemyLogic;
using TowerDefence.Scripts.GameUI;
using TowerDefence.Scripts.GlobalLogic;
using TowerDefence.Scripts.WaypointsSystem;
using UnityEngine;
using Zenject;

namespace TowerDefence.Scripts.GameLogic
{
	public class WaveSpawner : MonoBehaviour
	{
		[SerializeField]
		private float _waveCooldown;
		[SerializeField]
		private Transform _enemyRoot;
		[SerializeField]
		private List<WaveInfo> _waveInfos = new();
		[SerializeField]
		private Waypoints _waypoints;
		[SerializeField]
		private WaveCountdownView _waveCountdownView;
		
		private int _currentWaveIndex;
		
		private ReactiveProperty<float> _waveTimer = new(0);

		[Inject]
		private readonly GamePrefabFactory _gamePrefabFactory;

		private void Start()
		{
			_waveCountdownView.Bind(new(_waveTimer));
			_waveTimer.Value = _waveCooldown;
		}

		private void Update()
		{
			TrySpawnWave();
		}

		private void TrySpawnWave()
		{
			if (_waveTimer.Value <= 0)
			{
				if (_currentWaveIndex < _waveInfos.Count)
				{
					StartCoroutine(SpawnWave(_waveInfos[_currentWaveIndex]));
				}
				else
				{
					// TODO: конец уровня победой
					_currentWaveIndex = 0;
					StartCoroutine(SpawnWave(_waveInfos[_currentWaveIndex]));
				}
				
				_waveTimer.Value = _waveCooldown;
			}
			
			_waveTimer.Value -= Time.deltaTime;
		}

		private IEnumerator SpawnWave(WaveInfo wave)
		{
			_currentWaveIndex++;
			
			foreach (var enemy in wave.GetEnemies())
			{
				var c = _gamePrefabFactory.InstantiatePrefab<Enemy>(enemy,
					_enemyRoot.position,
					Quaternion.identity,
					_enemyRoot);
				
				c.Init(_waypoints);
				yield return new WaitForSeconds(.5f);
			}
		}
	}
}