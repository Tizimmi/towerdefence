using System.Collections.Generic;
using TowerDefence.Scripts.EnemyLogic;
using static TowerDefence.Scripts.EnemyLogic.EnemyType;

namespace TowerDefence.Scripts.Services
{
	public static class ResourcesPathProvider
	{
		private const string DefaultGoblinPath = "";
		public static readonly Dictionary<EnemyType, string> EnemyPathMap = new()
		{
			{DefaultGoblin, DefaultGoblinPath},
		};
	}
}