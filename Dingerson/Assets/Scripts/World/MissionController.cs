using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour {

    private Mission _currentMission;
    public Mission CurrentMission { get { return _currentMission; } set { _currentMission = value; UpdateUI();  } }

    public Text MissionTextItem;
    public Button[] OptionButtons;

    private void UpdateUI()
    {
        ///Now take the mission stored in current mission and transpose its variable onto these UI elements on the View
        /// https://docs.unity3d.com/ScriptReference/UI.Button.html
        /// https://docs.unity3d.com/ScriptReference/UI.Text.html
    }

}
