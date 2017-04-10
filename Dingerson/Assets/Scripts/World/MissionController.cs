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
         
    public void UpdateMission(int buttonId)
    {
        ///Create a switch statement based on the buttonId to update current Mission to the resultant mission of the Option held
        ///at the same index of the OptionButton array.
        ///Simple tutorial for a switch can be found here https://www.tutorialspoint.com/csharp/switch_statement_in_csharp.htm
        ///buttonId 
    }
}
