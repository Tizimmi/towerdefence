using TowerDefence.Scripts.GameLogic;
using Zenject;

namespace TowerDefence.Scripts.EnemyLogic
{
	public class DefaultEnemy : Enemy
	{
		[Inject]
		private readonly MoneyManager _moneyManager;

		private new void Start()
		{
			base.Start();
			_healthComponent.OnZeroHealth += OnZeroHealth;
		}

		private void Update()
		{
			_movementComponent.Move();
		}

		protected override void OnZeroHealth()
		{
			_moneyManager.AddBalance(CurrentStats.KillValue);
			Destroy(gameObject);
		}

		private void OnDestroy()
		{
			_healthComponent.OnZeroHealth -= OnZeroHealth;
		}
	}
}