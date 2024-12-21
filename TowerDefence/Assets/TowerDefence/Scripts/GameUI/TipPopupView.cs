using Plugins.MVVMModule;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace TowerDefence.Scripts.GameUI
{
	public class TipPopupView : View<TipPopupViewModel>
	{
		[SerializeField]
		private TextMeshProUGUI _tipField;
		[SerializeField]
		private float _showDuration;
		[SerializeField]
		private float _fadeDuration;

		private Coroutine _currentCoroutine;
		
		private Color _originalColor;

		private void StartAnimation()
		{
			if (_currentCoroutine != null)
			{
				StopCoroutine(_currentCoroutine);
				_tipField.gameObject.SetActive(false);
				_tipField.color = _originalColor;
			}
			
			_tipField.text = ViewModel.TextValue;
			_currentCoroutine = StartCoroutine(nameof(ShowAndFade));
		}
		
		private IEnumerator ShowAndFade()
		{
			_tipField.gameObject.SetActive(true);

			yield return new WaitForSeconds(_showDuration);
			
			var elapsedTime = 0f;

			while (elapsedTime < _fadeDuration)
			{
				var alpha = Mathf.Lerp(1, 0, elapsedTime / _fadeDuration);
				_tipField.color = new Color(_originalColor.r, _originalColor.g, _originalColor.b, alpha);
				elapsedTime += Time.deltaTime;
				yield return null;
			}

			_currentCoroutine = null;
			_tipField.gameObject.SetActive(false);
			_tipField.color = _originalColor;
		}

		protected override void OnBind(TipPopupViewModel viewModel)
		{
			_originalColor = _tipField.color;
			_tipField.text = viewModel.TextValue;
			_tipField.gameObject.SetActive(false);
			viewModel.OnCall += StartAnimation;
		}

		protected override void OnUnbind(TipPopupViewModel viewModel)
		{
			viewModel.OnCall -= StartAnimation;
		}
	}

	public class TipPopupViewModel : ViewModel
	{
		public Action OnCall;
		
		public string TextValue { get; private set; }

		public TipPopupViewModel(string value = "")
		{
			TextValue = value;
		}

		private void SetValue(string newValue)
		{
			TextValue = newValue;
		}

		public void ShowTip(string tipText)
		{
			SetValue(tipText);
			OnCall?.Invoke();
		}
	}
}