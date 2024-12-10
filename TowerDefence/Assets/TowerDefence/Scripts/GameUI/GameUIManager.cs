using JetBrains.Annotations;
using TowerDefence.Scripts.GameLogic.LevelLogic;
using UnityEngine;

namespace TowerDefence.Scripts.GameUI
{
	[UsedImplicitly]
	public class GameUIManager
	{
		private MoneyView _moneyView;
		private WaveCountdownView _waveCountdownView;
		private readonly Level _level;
		private readonly LevelConfig _levelConfig;
		private readonly RectTransform _uiRoot;

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
			_moneyView.Bind(new MoneyViewModel(_level.MoneyManager.CurrentBalance));

			_waveCountdownView = Object.Instantiate(_waveCountdownView, _uiRoot);
			_waveCountdownView.Bind(new WaveCountdownViewModel(_level.WaveSpawner.WaveTimer));
		}
	}
}