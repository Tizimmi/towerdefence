using TowerDefence.Scripts.GameLogic;
using TowerDefence.Scripts.WaypointsSystem;
using UnityEngine;
using Zenject;

namespace TowerDefence.Scripts.EnemyLogic
{
	public class DefaultEnemy : Enemy
	{
		[Range(0.01f, 2f)]
		[SerializeField]
		private float _pathOffset = .01f;

		[Inject]
		private readonly MoneyManager _moneyManager;

		private void Update()
		{
			Move();
		}

		private void OnDisable()
		{
			_healthComponent.OnZeroHealth -= OnZeroHealth;
		}

		public override void Init(Waypoints path)
		{
			Path = path;
			_healthComponent.OnZeroHealth += OnZeroHealth;

			CurrentWaypoint = Path.GetNextWaypoint(CurrentWaypoint);
			transform.position = CurrentWaypoint.position;

			CurrentWaypoint = Path.GetNextWaypoint(CurrentWaypoint);
		}

		public override void Move()
		{
			if (CurrentWaypoint == null)
			{
				Destroy(gameObject);
				return;
			}

			transform.position = Vector3.MoveTowards(transform.position, CurrentWaypoint.position, _movementSpeed * Time.deltaTime);

			if (Vector3.Distance(transform.position, CurrentWaypoint.position) < _pathOffset)
				CurrentWaypoint = Path.GetNextWaypoint(CurrentWaypoint);
		}

		protected override void OnZeroHealth()
		{
			_moneyManager.AddBalance(_killValue);
			Destroy(gameObject);
		}
	}
}