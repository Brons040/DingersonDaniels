using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interplay.UI;

public class ToggleAnchor : MonoBehaviour {

	private RectTransform rectTransform;
	[SerializeField]
	private Vector2 startAnchor;
	[SerializeField]
	private Vector2 endAnchor;

	public void Toggle(bool isOn) {
		if (rectTransform == null)
			rectTransform = GetComponent<RectTransform> ();
		TweenManager.TweenVector2 ((anchoredPosition) => {
			rectTransform.anchoredPosition = anchoredPosition;
		}, rectTransform.anchoredPosition, isOn ? startAnchor : endAnchor, 0.5f);
	}
}
