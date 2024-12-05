using System;
using System.Collections;
using TowerDefence.Scripts.EnemyLogic;
using Unity.VisualScripting;
using UnityEngine;

namespace TowerDefence.Scripts.GameLogic
{
	public class WaveSpawner : MonoBehaviour
	{
		[SerializeField]
		private Enemy _enemyPrefab;
		[SerializeField]
		private float _waveCooldown;
		[SerializeField]
		private Transform _enemyRoot;

		private void Start()
		{
			StartCoroutine(WaveTimer(_waveCooldown));
		}

		private IEnumerator WaveTimer(float timeInSec)
		{
			yield return new WaitForSeconds(timeInSec);

			SpawnWave();
		}

		private void SpawnWave()
		{
			Debug.Log("Wave incoming");
			Instantiate(_enemyPrefab, _enemyRoot.root);
			StartCoroutine(WaveTimer(_waveCooldown));
		}
	}
}