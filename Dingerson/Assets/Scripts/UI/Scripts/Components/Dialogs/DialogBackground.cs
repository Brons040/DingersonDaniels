//  Copyright 2016 MaterialUI for Unity http://materialunity.com
//  Please see license file for terms and conditions of use, and more information.

using UnityEngine;
using UnityEngine.EventSystems;

namespace Interplay.UI
{
    [AddComponentMenu("InterplayUI/Dialogs/Background", 100)]
    public class DialogBackground : MonoBehaviour, IPointerClickHandler
    {
        private DialogAnimator m_DialogAnimator;
        public DialogAnimator dialogAnimator
        {
            get { return m_DialogAnimator; }
            set { m_DialogAnimator = value; }
        }

		[SerializeField]
		private MaterialButton m_BackButton;
		public MaterialButton backButton
		{
			get { return m_BackButton; }
			set { m_BackButton = value; }
		}

		void Awake() {
			m_BackButton.gameObject.SetActive (false);
		}

		public void ShowBackButton() {
			m_BackButton.gameObject.SetActive (true);
			m_BackButton.buttonObject.onClick.AddListener (() => {
				OnPointerClick(null);
			});
		}

        public void OnPointerClick(PointerEventData eventData)
        {
            if (m_DialogAnimator != null)
            {
                m_DialogAnimator.OnBackgroundClick();
            }
        }
    }
}