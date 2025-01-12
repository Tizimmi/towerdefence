using UnityEngine;

namespace TowerDefence.Scripts.GameUI
{
	[CreateAssetMenu(menuName = "ScriptableObject/" + nameof(ViewProvider), fileName = nameof(ViewProvider))]
	public class ViewProvider : ScriptableObject
	{
		[field: SerializeField]
		public MoneyView MoneyView { get; private set; }

		[field: SerializeField]
		public WaveCountdownView WaveCountdownView { get; private set; }

		[field: SerializeField]
		public TurretStoreView TurretStoreView { get; private set; }

		[field: SerializeField]
		public TipPopupView TipPopupView { get; private set; }
	}
}