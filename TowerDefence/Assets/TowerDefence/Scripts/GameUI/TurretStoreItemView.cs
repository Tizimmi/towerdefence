using Plugins.MVVMModule;
using Plugins.ReactivePropertyModule;
using System;
using TMPro;
using TowerDefence.Scripts.BuildingsLogic.Turrets;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.Scripts.GameUI
{
	public class TurretStoreItemView : View<TurretStoreItemViewModel>
	{
		[SerializeField]
		private TextMeshProUGUI _valueField;
		[SerializeField]
		private Button _selectButton;
		[SerializeField]
		private Image _background;
		[SerializeField]
		private Color _pressedColor;

		private Color _startColor;

		private void Start()
		{
			_startColor = _background.color;
			UpdateSelected(ViewModel.IsSelected.Value);
		}

		protected override void OnBind(TurretStoreItemViewModel viewModel)
		{
			_valueField.text = viewModel.Value + " $";
			_selectButton.onClick.AddListener(viewModel.SetThisTurret);
			viewModel.IsSelected.OnValueChange += UpdateSelected;
		}
		
		protected override void OnUnbind(TurretStoreItemViewModel viewModel)
		{
			_selectButton.onClick.RemoveListener(viewModel.SetThisTurret);
			viewModel.IsSelected.OnValueChange -= UpdateSelected;
		}

		private void UpdateSelected(bool isSelected)
		{
			_background.color = isSelected ? _pressedColor : _startColor;
		}
	}

	public class TurretStoreItemViewModel : ViewModel
	{
		public Action<Turret> OnSelectTurret;
		public readonly int Value;
		private readonly Turret _turretType;

		private readonly ReactiveProperty<bool> _isSelected = new(false);
		public IReadOnlyReactiveProperty<bool> IsSelected => _isSelected;

		public TurretStoreItemViewModel(Turret turretType, IReadOnlyReactiveProperty<Turret> selectedTurret)
		{
			_turretType = turretType;
			Value = turretType._value;
			selectedTurret.OnValueChange += UpdateSelected;
			IsSelected.Value = selectedTurret.Value == _turretType;
		}

		private void UpdateSelected(Turret newTurret)
		{
			IsSelected.Value = newTurret == _turretType;
		}
		
		public void SetThisTurret()
		{
			IsSelected.Value = true;
			OnSelectTurret?.Invoke(_turretType);
		}
	}
}