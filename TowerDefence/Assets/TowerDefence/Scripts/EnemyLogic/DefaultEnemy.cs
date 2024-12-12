using TowerDefence.Scripts.GameLogic;
using Zenject;

namespace TowerDefence.Scripts.EnemyLogic
{
	public class DefaultEnemy : Enemy
	{
		[Inject]
		private readonly MoneyManager _moneyManager;

		private void Start()
		{
			_healthComponent.Init(_buffManager.BaseStats.Health);
			_healthComponent.OnZeroHealth += OnZeroHealth;
			_buffManager.Init();
		}

		private void Update()
		{
			_movementComponent.Move(_buffManager.CurrentStats.MovementSpeed);
		}

		protected override void OnZeroHealth()
		{
			_moneyManager.AddBalance(_buffManager.BaseStats.KillValue);
			Destroy(gameObject);
		}

		private void OnDestroy()
		{
			_healthComponent.OnZeroHealth -= OnZeroHealth;
		}
	}
}