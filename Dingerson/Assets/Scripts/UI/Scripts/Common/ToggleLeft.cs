using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interplay.UI;

public class ToggleLeft : MonoBehaviour {

	private RectTransform rectTransform;
	[SerializeField]
	private float startLeft;
	[SerializeField]
	private float endLeft;

	public void Toggle(bool isOn) {
		if (rectTransform == null)
			rectTransform = GetComponent<RectTransform> ();
		TweenManager.TweenFloat ((left) => {
			rectTransform.offsetMin = new Vector2(left, rectTransform.offsetMin.y);
		}, rectTransform.offsetMin.x, isOn ? startLeft : endLeft, 0.5f);
	}
}
