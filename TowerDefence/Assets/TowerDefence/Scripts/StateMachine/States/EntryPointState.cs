using TowerDefence.Scripts.GlobalLogic;

namespace TowerDefence.Scripts.StateMachine.States
{
	public class EntryPointState : IState
	{
		private const string InitialScene = "EntryPoint";
		private const string GameScene = "GameScene";

		private readonly GameStateMachine _gameStateMachine;
		private readonly SceneLoader _sceneLoader;

		public EntryPointState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
		{
			_gameStateMachine = gameStateMachine;
			_sceneLoader = sceneLoader;
		}

		public void Enter()
		{
			_sceneLoader.Load(InitialScene, EnterLevelLoad);
		}

		public void Exit() { }

		private void EnterLevelLoad()
		{
			_gameStateMachine.Enter<LoadLevelState, string>(GameScene);
		}
	}
}