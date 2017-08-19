using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Interplay.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Interplay.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class Blocker : MonoBehaviour, IPointerClickHandler {

		private CanvasGroup canvasGroup;
		public UnityEvent onClickHandler;

		public void OnPointerClick(PointerEventData data) {
			onClickHandler.Invoke ();
			Hide ();
		}

		public void Show (float delay = 0f) {
			if (canvasGroup == null)
				canvasGroup = GetComponent<CanvasGroup> ();
			RectTransform parentTransform = transform.root.GetComponent<RectTransform> ();
			RectTransform thisTransform = GetComponent<RectTransform> ();
			thisTransform.sizeDelta = parentTransform.sizeDelta*10;
			TweenManager.TweenFloat ((alpha) => {
				canvasGroup.alpha = alpha;
			}, canvasGroup.alpha, 1, 0.2f, delay);
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
		}

		public void Hide(bool isOn = false) {
			if (!isOn) {
				TweenManager.TweenFloat ((alpha) => {
					canvasGroup.alpha = alpha;
				}, canvasGroup.alpha, 0, 0.1f);
				canvasGroup.interactable = false;
				canvasGroup.blocksRaycasts = false;
			}
		}

	}
}
