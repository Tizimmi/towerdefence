using UnityEngine;
using Zenject;

namespace TowerDefence.Scripts.BuildingsLogic.Turrets
{
	public class TurretStand : MonoBehaviour
	{
		[SerializeField]
		private Color _hoverColor;
		[SerializeField]
		private Transform _turretRoot;

		[Inject]
		private BuildingManager _builder;

		private Turret _currentTurret;

		private Color _defaultColor;
		private Renderer _renderer;

		private void Start()
		{
			_renderer = GetComponent<Renderer>();
			_defaultColor = _renderer.material.color;
			_currentTurret = null;
		}

		private void OnMouseDown()
		{
			if (_currentTurret != null)
				return;

			_builder.BuildTurret(this);
		}

		private void OnMouseEnter()
		{
			if (_currentTurret != null)
				return;

			_renderer.material.color = _hoverColor;
		}

		private void OnMouseExit()
		{
			_renderer.material.color = _defaultColor;
		}

		public void SpawnTurret(Turret turret)
		{
			_currentTurret = turret;
			var t = Instantiate(turret, _turretRoot);
			t.transform.localScale = Vector3.one;
		}
	}
}