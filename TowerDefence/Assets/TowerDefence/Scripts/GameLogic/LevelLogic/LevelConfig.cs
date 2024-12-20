using TowerDefence.Scripts.BuildingsLogic.Turrets;
using TowerDefence.Scripts.GameUI;
using UnityEngine;

namespace TowerDefence.Scripts.GameLogic.LevelLogic
{
	[CreateAssetMenu(menuName = "ScriptableObject/" + nameof(LevelConfig), fileName = nameof(LevelConfig))]
	public class LevelConfig : ScriptableObject //Installer<LevelConfig>
	{
		[field: SerializeField]
		public int StartingBalance { get; private set; }

		[field: SerializeField]
		public WaveInfo[] WaveInfos { get; private set; }

		[field: SerializeField]
		public MoneyView MoneyView { get; private set; }

		[field: SerializeField]
		public WaveCountdownView WaveCountdownView { get; private set; }
		
		[field: SerializeField]
		public TurretStoreView TurretStoreView { get; private set; }
		
		[field: SerializeField]
		public TipPopupView TipPopupView { get; private set; }
		
		[field: SerializeField]
		public Turret[] AvailableTurrets { get; private set; }
	}
}