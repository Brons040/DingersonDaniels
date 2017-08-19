//  Copyright 2016 MaterialUI for Unity http://materialunity.com
//  Please see license file for terms and conditions of use, and more information.

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Interplay.UI
{
    [AddComponentMenu("InterplayUI/Dialogs/Progress", 1)]
    public class DialogProgress : MaterialDialog
    {
        [SerializeField]
        private DialogTitleSection m_TitleSection = new DialogTitleSection();
        public DialogTitleSection titleSection
        {
            get { return m_TitleSection; }
            set { m_TitleSection = value; }
        }

		[SerializeField]
		private DialogButtonSection m_ButtonSection = new DialogButtonSection();
		public DialogButtonSection buttonSection
		{
			get { return m_ButtonSection; }
			set { m_ButtonSection = value; }
		}

        [SerializeField]
        private Text m_BodyText;
        public Text bodyText
        {
            get { return m_BodyText; }
        }

        private ProgressIndicator m_ProgressIndicator;
        public ProgressIndicator progressIndicator
        {
            get { return m_ProgressIndicator; }
            set { m_ProgressIndicator = value; }
        }

        [SerializeField]
        private ProgressIndicator m_LinearIndicator;

        [SerializeField]
        private ProgressIndicator m_CircularIndicator;

		public void Initialize(string bodyText, string titleText, ImageData icon, bool startStationaryAtZero = true)
        {
            m_TitleSection.SetTitle(titleText, icon);

			m_ButtonSection.affirmativeButton.gameObject.SetActive (false);
			m_ButtonSection.dismissiveButton.gameObject.SetActive (false);

            if (string.IsNullOrEmpty(bodyText))
            {
                m_BodyText.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                m_BodyText.text = bodyText;
            }

            if (!startStationaryAtZero)
            {
                m_ProgressIndicator.StartIndeterminate();
            }
            else
            {
                m_ProgressIndicator.SetProgress(0f, false);
            }

            Initialize();
        }

		public virtual void Hide() {
			StartCoroutine (HideDelayed());
		}

		IEnumerator HideDelayed() {
			yield return new WaitForSeconds (0.5f);
			base.Hide ();
		}

        public void SetupIndicator(bool isLinear)
        {
            m_LinearIndicator.gameObject.SetActive(isLinear);
            m_CircularIndicator.gameObject.SetActive(!isLinear);
            m_ProgressIndicator = isLinear ? m_LinearIndicator : m_CircularIndicator;
            m_ProgressIndicator.transform.parent.GetComponent<VerticalLayoutGroup>().childForceExpandWidth = isLinear;
        }

		public void Complete() {
			m_ProgressIndicator.SetColor (Color.green);
			Hide ();
		}

		public void Error(string errorText, Action onAffirmativeButtonClicked, string affirmativeButtonText, Action onDismissiveButtonClicked, string dismissiveButtonText) {
			m_BodyText.text = errorText;
			m_ProgressIndicator.SetColor (Color.red);
			m_ButtonSection.affirmativeButton.gameObject.SetActive (true);
			m_ButtonSection.dismissiveButton.gameObject.SetActive (true);
			m_ButtonSection.SetButtons(onAffirmativeButtonClicked, affirmativeButtonText, onDismissiveButtonClicked, dismissiveButtonText);
			m_ButtonSection.SetupButtonLayout(rectTransform);
		}

		public void AffirmativeButtonClicked()
		{
			m_ButtonSection.OnAffirmativeButtonClicked ();
			base.Hide ();
		}

		public void DismissiveButtonClicked()
		{
			m_ButtonSection.OnDismissiveButtonClicked();
			base.Hide ();
		}
    }
}