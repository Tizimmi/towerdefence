using Plugins.MVVMModule;
using System.Collections.Generic;
using TowerDefence.Scripts.BuildingsLogic;
using TowerDefence.Scripts.BuildingsLogic.Turrets;
using UnityEngine;

namespace TowerDefence.Scripts.GameUI
{
	public class TurretStoreView : View<TurretStoreViewModel>
	{
		[SerializeField]
		private List<TurretStoreItemView> _childViews = new();
		[SerializeField]
		private Transform _childRoot;

		protected override void OnBind(TurretStoreViewModel viewModel)
		{
			for (var index = 0; index < viewModel.ChildModels.Count; index++)
			{
				var instance = Instantiate(_childViews[index], _childRoot);
				instance.Bind(viewModel.ChildModels[index]);
			}
		}

		protected override void OnUnbind(TurretStoreViewModel viewModel)
		{
			foreach (var view in _childViews)
				view.Unbind();
		}
	}

	public class TurretStoreViewModel : ViewModel
	{
		private readonly BuildingManager _buildingManager;
		public readonly List<TurretStoreItemViewModel> ChildModels = new();

		public TurretStoreViewModel(Turret[] availableTurrets, BuildingManager buildingManager)
		{
			_buildingManager = buildingManager;
			foreach (var turret in availableTurrets)
			{
				var model = new TurretStoreItemViewModel(turret, buildingManager.SelectedTurret);
				ChildModels.Add(model);
				model.OnSelectTurret += SetTurret;
			}
		}

		private void SetTurret(Turret turret)
		{
			_buildingManager.SetCurrentTurret(turret);
		}
	}
}