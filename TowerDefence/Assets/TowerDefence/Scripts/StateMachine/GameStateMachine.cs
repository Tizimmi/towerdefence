using System;
using System.Collections.Generic;
using TowerDefence.Scripts.GameLogic.LevelLogic;
using TowerDefence.Scripts.GameUI;
using TowerDefence.Scripts.GlobalLogic;
using TowerDefence.Scripts.StateMachine.States;
using UnityEngine;

namespace TowerDefence.Scripts.StateMachine
{
	public class GameStateMachine
	{
		private IExitableState _currentState;
		private readonly Dictionary<Type, IExitableState> _states;

		public GameStateMachine(
			SceneLoader sceneLoader,
			ICoroutineRunner coroutineRunner,
			ViewProvider viewProvider,
			GameObject uiRoot,
			LevelsData levelData)
		{
			_states = new Dictionary<Type, IExitableState>
			{
				[typeof(EntryPointState)] = new EntryPointState(this, sceneLoader),
				[typeof(LoadLevelState)] = new LoadLevelState(this,
					sceneLoader,
					coroutineRunner,
					viewProvider,
					uiRoot,
					levelData),
				[typeof(GameLoopState)] = new GameLoopState(this),
			};
		}

		public void Enter<TState>()
			where TState : class, IState
		{
			IState state = ChangeState<TState>();
			state.Enter();
		}

		public void Enter<TState, TPayload>(TPayload payload)
			where TState : class, IPayloadedState<TPayload>
		{
			var state = ChangeState<TState>();
			state.Enter(payload);
		}

		private TState ChangeState<TState>()
			where TState : class, IExitableState
		{
			_currentState?.Exit();

			var state = GetState<TState>();
			_currentState = state;

			return state;
		}

		private TState GetState<TState>()
			where TState : class, IExitableState
		{
			return _states[typeof(TState)] as TState;
		}
	}
}