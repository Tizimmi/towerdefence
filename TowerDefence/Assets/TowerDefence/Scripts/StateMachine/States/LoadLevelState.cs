using TowerDefence.Scripts.GameLogic.LevelLogic;
using TowerDefence.Scripts.GameUI;
using TowerDefence.Scripts.GlobalLogic;
using UnityEngine;

namespace TowerDefence.Scripts.StateMachine.States
{
	public class LoadLevelState : IPayloadedState<string>
	{
		private readonly LevelsData _levelsData;
		private readonly GameObject _canvas;
		private readonly ICoroutineRunner _coroutineRunner;
		private readonly GameStateMachine _gameStateMachine;
		private readonly SceneLoader _sceneLoader;
		private readonly ViewProvider _viewProvider;

		public LoadLevelState(
			GameStateMachine gameStateMachine,
			SceneLoader sceneLoader,
			ICoroutineRunner coroutineRunner,
			ViewProvider viewProvider,
			GameObject canvas,
			LevelsData levelsData)
		{
			_gameStateMachine = gameStateMachine;
			_sceneLoader = sceneLoader;
			_coroutineRunner = coroutineRunner;
			_viewProvider = viewProvider;
			_canvas = canvas;
			_levelsData = levelsData;
		}

		public void Enter(string sceneName)
		{
			_sceneLoader.Load(sceneName, OnLoaded);
		}

		public void Exit() { }

		private void OnLoaded()
		{
			var uiRoot = Object.Instantiate(_canvas).transform;
			var level = new Level(_levelsData.GetCurrentLevelConfig(),
				_coroutineRunner,
				_viewProvider,
				uiRoot);

			level.CreateUI();
			_gameStateMachine.Enter<GameLoopState>();
		}
	}
}