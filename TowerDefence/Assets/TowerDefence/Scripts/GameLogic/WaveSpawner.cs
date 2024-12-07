using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

		private int _currentWaveIndex;

		private void Start()
		{
			StartCoroutine(SpawnWave(_waveInfos[0]));
		}

		private IEnumerator SpawnWave(WaveInfo wave)
		{
			_currentWaveIndex++;
			
			foreach (var enemy in wave.GetEnemies())
			{
				Instantiate(enemy, _enemyRoot.position, Quaternion.identity, _enemyRoot);
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