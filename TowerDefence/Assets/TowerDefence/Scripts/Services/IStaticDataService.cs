using TowerDefence.Scripts.EnemyLogic;
using TowerDefence.Scripts.StaticData;

namespace TowerDefence.Scripts.Services
{
	public interface IStaticDataService : IService
	{
		void LoadEnemies();
		EnemyStaticData ForEnemy(EnemyType type);
	}
}