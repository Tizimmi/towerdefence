using TowerDefence.Scripts.GameLogic.LevelLogic;
using UnityEngine;

namespace TowerDefence.Scripts.GameUI
{
	public class GameUIManager
	{
		private readonly RectTransform _uiRoot;
		private readonly Level _level;
		private readonly LevelConfig _levelConfig;

		private MoneyView _moneyView;
		private WaveCountdownView _waveCountdownView;

		public GameUIManager(RectTransform uiRoot, Level level, LevelConfig levelConfig)
		{
			_uiRoot = uiRoot;
			_level = level;
			_levelConfig = levelConfig;

			_moneyView = _levelConfig.MoneyView;
			_waveCountdownView = _levelConfig.WaveCountdownView;
			
			InstantiateUi();
		}

		public void InstantiateUi()
		{
			_moneyView = Object.Instantiate(_moneyView, _uiRoot);
			_moneyView.Bind(new(_level.MoneyManager.CurrentBalance));

			_waveCountdownView = Object.Instantiate(_waveCountdownView, _uiRoot);
			_waveCountdownView.Bind(new(_level.WaveSpawner.WaveTimer));
		}
	}
}