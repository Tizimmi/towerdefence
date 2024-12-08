using System.Collections;
using System.Collections.Generic;
using TowerDefence.Scripts.EnemyLogic;
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

		private int _currentWaveIndex;

		[Inject]
		private readonly GamePrefabFactory _gamePrefabFactory;

		private void Start()
		{
			StartCoroutine(SpawnWave(_waveInfos[0]));
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
			
			yield return StartCoroutine(WaveCooldownTimer(_waveCooldown));
		}

		private IEnumerator WaveCooldownTimer(float time)
		{
			yield return new WaitForSeconds(time);

			if (_currentWaveIndex < _waveInfos.Count)
				yield return StartCoroutine(SpawnWave(_waveInfos[_currentWaveIndex]));

			Debug.Log("Restart");
			_currentWaveIndex = 0;
			yield return StartCoroutine(SpawnWave(_waveInfos[_currentWaveIndex]));
		}
	}
}