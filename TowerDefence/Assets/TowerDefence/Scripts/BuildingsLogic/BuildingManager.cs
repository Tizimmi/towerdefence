using TowerDefence.Scripts.BuildingsLogic.Turrets;
using TowerDefence.Scripts.GameLogic;
using UnityEngine;
using Zenject;

namespace TowerDefence.Scripts.BuildingsLogic
{
	public class BuildingManager : MonoBehaviour
	{
		[SerializeField]
		private Turret _selectedTurret;

		[Inject]
		private readonly MoneyManager _moneyManager;
		
		public Turret GetCurrentTurret()
		{
			return _selectedTurret;
		}

		public void BuildTurret(TurretStand stand)
		{
			if (_moneyManager.TrySpendBalance(_selectedTurret._value))
			{
				stand.SpawnTurret(_selectedTurret);
			}
			else
			{
				Debug.LogError("dont have enough money");
			}
		}
	}
}