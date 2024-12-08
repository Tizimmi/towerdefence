using TowerDefence.Scripts.BuildingsLogic.Turrets;
using UnityEngine;

namespace TowerDefence.Scripts.BuildingsLogic
{
	public class BuildingManager : MonoBehaviour
	{
		[SerializeField]
		private Turret _selectedTurret;

		public Turret GetCurrentTurret()
		{
			return _selectedTurret;
		}
	}
}