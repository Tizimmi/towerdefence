using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace TowerDefence.Scripts.GlobalLogic
{
	public class SceneLoader
	{
		private readonly ICoroutineRunner _coroutineRunner;

		public SceneLoader(ICoroutineRunner coroutineRunner)
		{
			_coroutineRunner = coroutineRunner;
		}

		public void Load(string name, Action onLoad = null)
		{
			_coroutineRunner.StartCoroutine(LoadScene(name, onLoad));
		}

		private IEnumerator LoadScene(string name, Action onLoad = null)
		{
			if (SceneManager.GetActiveScene().name == name)
			{
				onLoad?.Invoke();
				yield break;
			}

			var loadSceneAsync = SceneManager.LoadSceneAsync(name);

			while (!loadSceneAsync.isDone)
				yield return null;

			onLoad?.Invoke();
		}
	}
}