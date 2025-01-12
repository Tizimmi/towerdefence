using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Scripts.GameLogic.LevelLogic
{
	[CreateAssetMenu(menuName = "ScriptableObject/" + nameof(LevelsData), fileName = nameof(LevelsData))]
	public class LevelsData : ScriptableObject
	{
		[SerializeField]
		private List<LevelConfig> _infos;

		private LevelConfig _currentLevel;

		public LevelConfig GetCurrentLevelConfig()
		{
			return _currentLevel == null ? _currentLevel = _infos[0] : _currentLevel;
		}
	}
}