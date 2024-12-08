using TowerDefence.Scripts.BuildingsLogic;
using UnityEngine;
using Zenject;

namespace TowerDefence.Scripts.GlobalLogic
{
	public class GameSceneInstaller : MonoInstaller
	{
		[SerializeField]
		private BuildingManager _buildingManager;
		public override void InstallBindings()
		{
			Container.BindInstance(_buildingManager).AsSingle().NonLazy();
		}
	}
}