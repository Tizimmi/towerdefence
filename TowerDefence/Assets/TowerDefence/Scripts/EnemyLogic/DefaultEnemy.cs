using TowerDefence.Scripts.BuffsLogic;
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
			CurrentStats._healthComponent.OnZeroHealth += OnZeroHealth;
		}

		private void Update()
		{
			CurrentStats._movementComponent.Move();
		}

		protected override void OnZeroHealth()
		{
			_moneyManager.AddBalance(CurrentStats._killValue);
			Destroy(gameObject);
		}

		private void OnDestroy()
		{
			CurrentStats._healthComponent.OnZeroHealth -= OnZeroHealth;
		}
	}
}