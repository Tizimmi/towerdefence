using TowerDefence.Scripts.BuildingsLogic.Turrets;
using UnityEngine;

namespace TowerDefence.Scripts.GameLogic.LevelLogic
{
	[CreateAssetMenu(menuName = "ScriptableObject/" + nameof(LevelConfig), fileName = nameof(LevelConfig))]
	public class LevelConfig : ScriptableObject
	{
		[field: SerializeField]
		public int StartingBalance { get; private set; }

		[field: SerializeField]
		public Turret[] AvailableTurrets { get; private set; }

		[field: Header("Wave information")]
		[field: SerializeField]
		public WaveInfo[] WaveInfos { get; private set; }
	}
}