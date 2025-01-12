using System.Collections;
using UnityEngine;

namespace TowerDefence.Scripts.GlobalLogic
{
	public interface ICoroutineRunner
	{
		Coroutine StartCoroutine(IEnumerator coroutine);
	}
}