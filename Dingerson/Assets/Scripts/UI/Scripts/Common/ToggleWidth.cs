using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Interplay.UI;
using UnityEngine.UI;

namespace Interplay.UI {
	public class ToggleWidth : MonoBehaviour {

		private RectTransform rectTransform;
		[SerializeField]
		private float minWidth;
		[SerializeField]
		private float maxWidth;

		protected bool isOn = false;
		protected bool isHovered = false;

		void Awake() {
			rectTransform = GetComponent<RectTransform> ();
		}

		public void OnPointerDown(BaseEventData data) {
			isOn = !isOn;
			if (!isOn)
				isHovered = false;
			Toggle ();
		}
			
		public void OnPointerEnter(BaseEventData data) {
			if (isOn)
				HoverTimer ();
			else
				Invoke ("HoverTimer", 2f);
		}
			
		public void OnPointerExit(BaseEventData data) {
			CancelInvoke ("HoverTimer");
			isHovered = false;
			Toggle ();
		}

		void HoverTimer() {
			isHovered = true;
			Toggle ();
		}
			
		public void OnSelect(BaseEventData eventData) {
			isOn = !isOn;
			if (!isOn)
				isHovered = false;
			Toggle ();
		}

		public virtual void Toggle(bool isOn) {
			this.isOn = isOn;
			Toggle ();
		}

		protected virtual void Toggle() {
			TweenManager.TweenFloat ((width) => {
				rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
			}, rectTransform.sizeDelta.x, (isOn || isHovered) ? maxWidth : minWidth, 0.5f);
		}
	}
}
