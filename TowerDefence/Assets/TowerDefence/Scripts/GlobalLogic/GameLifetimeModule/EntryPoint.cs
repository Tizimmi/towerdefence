using TowerDefence.Scripts.GameLogic.LevelLogic;
using TowerDefence.Scripts.GameUI;
using TowerDefence.Scripts.StateMachine.States;
using UnityEngine;
using Zenject;

namespace TowerDefence.Scripts.GlobalLogic.GameLifetimeModule
{
	public class EntryPoint : MonoBehaviour, ICoroutineRunner, IInitializable
	{
		[SerializeField]
		private ViewProvider _viewProvider;
		[SerializeField]
		private GameObject _uiRoot;
		[SerializeField]
		private LevelsData _levelsData;

		private Game _game;

		public void Initialize()
		{
			_game = new Game(this,
				_viewProvider,
				_uiRoot,
				_levelsData);

			_game.StateMachine.Enter<EntryPointState>();

			DontDestroyOnLoad(this);
		}
	}
}