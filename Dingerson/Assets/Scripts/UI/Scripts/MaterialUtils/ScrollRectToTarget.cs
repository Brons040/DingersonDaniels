using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interplay.UI;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class ScrollRectToTarget : MonoBehaviour {

	private RectTransform rectTransform;
	private ScrollRect scrollRect;

	public void ScrollTo(RectTransform target) {
		Canvas.ForceUpdateCanvases();

		if (rectTransform == null)
			rectTransform = GetComponent<RectTransform> ();
		Vector2 viewportSize = rectTransform.rect.size;
		if (scrollRect == null)
			scrollRect = GetComponent<ScrollRect> ();
		Vector2 contentSize = scrollRect.content.rect.size;
		Vector2 positionOfTarget = target.anchoredPosition;

		float x = 0;
		float y = Mathf.Clamp((Mathf.Abs (positionOfTarget.y) - (target.rect.size.y / 2)) - ((viewportSize.y/2) - (target.rect.size.y/2)), 0, contentSize.y-viewportSize.y);
		TweenManager.TweenVector2 ((anchoredPosition) => {
			scrollRect.content.anchoredPosition = anchoredPosition;
		}, scrollRect.content.anchoredPosition, new Vector2(x, y), 0.3f);
	}
}
