using TowerDefence.Scripts.BuildingsLogic;
using TowerDefence.Scripts.GameLogic;
using UnityEngine;
using Zenject;

namespace TowerDefence.Scripts.GlobalLogic
{
	public class GameSceneInstaller : MonoInstaller
	{
		[SerializeField]
		private BuildingManager _buildingManager;
		[SerializeField]
		private MoneyManager _moneyManager;
		public override void InstallBindings()
		{
			Container.BindInstance(_buildingManager).AsSingle().NonLazy();
			Container.BindInstance(_moneyManager).AsSingle().NonLazy();
		}
	}
}