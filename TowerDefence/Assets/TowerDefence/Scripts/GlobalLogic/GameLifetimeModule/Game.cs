using TowerDefence.Scripts.GameLogic.LevelLogic;
using TowerDefence.Scripts.GameUI;
using TowerDefence.Scripts.StateMachine;
using UnityEngine;

namespace TowerDefence.Scripts.GlobalLogic.GameLifetimeModule
{
	public class Game
	{
		public GameStateMachine StateMachine;

		public Game(
			ICoroutineRunner coroutineRunner,
			ViewProvider viewProvider,
			GameObject uiRoot,
			LevelsData levelsData)
		{
			StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner),
				coroutineRunner,
				viewProvider,
				uiRoot,
				levelsData);
		}
	}
}