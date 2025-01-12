using TowerDefence.Scripts.EnemyLogic;
using UnityEngine;

namespace TowerDefence.Scripts.StaticData
{
	[CreateAssetMenu(fileName = "EnemyData", menuName = "Static Data/Enemy")]
	public class EnemyStaticData : ScriptableObject
	{
		public EnemyType EnemyType;
		public int Health;
		public float MovementSpeed;
		public int KillValue;

		public GameObject EnemyPrefab;
	}
}