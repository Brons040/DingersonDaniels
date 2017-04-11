using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MissionController : MonoBehaviour {

    private Mission _currentMission;
    public Mission CurrentMission { get { return _currentMission; } set { _currentMission = value; UpdateUI();  } }

    public TextAsset jsonFile;

    private static MissionController _instance;
    public static MissionController Instance { get { return _instance; } }

    public List<Mission> Missions;

    public Text MissionTextItem;
    public Button[] OptionButtons;

    void Start()
    {
        Missions = new List<Mission>();
        _instance = this;
        Character c = new Character();
        c.Experience += 100;

        
        //Debug.Log(JsonUtility.ToJson(m));
        //SaveMissionInfo(JsonUtility.ToJson(mc, true));
        ReadMissionInfo();
        CurrentMission = Missions[0];
       
    }

    private void UpdateUI()
    {
        ///Now take the mission stored in current mission and transpose its variable onto these UI elements on the View
        /// https://docs.unity3d.com/ScriptReference/UI.Button.html
        /// https://docs.unity3d.com/ScriptReference/UI.Text.html
        /// 
        MissionTextItem.text = CurrentMission.missionText;

        Debug.Log(CurrentMission.missionText + "!!");
        
        for(int i = 0; i < OptionButtons.Length; i++)
        {
            OptionButtons[i].GetComponentInChildren<Text>().text = CurrentMission.options[i].optionsText;
        }
    } 
         
    public void UpdateMission(int buttonId)
    {       
        foreach(Mission missio in Missions)
        {
            if (missio.missionId == CurrentMission.options[buttonId]._missionId)
                CurrentMission = missio;
        }

        //CurrentMission = CurrentMission.options[buttonId].resultantMission;

    }

    public void SaveMissionInfo(string json)
    {        
        string path = null;
#if UNITY_EDITOR
        path = "Assets/Resources/GameJSONData/ItemInfo.json";
#endif
#if UNITY_STANDALONE
        // You cannot add a subfolder, at least it does not work for me
        path = "Assets/Resources/ItemInfo.json";
     #endif

        string str = json;
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.Write(str);
            }
        }
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }

    public void ReadMissionInfo()
    {
        MissionCollection mc = JsonUtility.FromJson<MissionCollection>(jsonFile.text);
        Mission[] tempMissions = mc.missions;
        foreach(Mission mission in tempMissions)
        {
            Missions.Add(mission);
            Debug.Log(mission.missionText + "!?");
        }
        Debug.Log(tempMissions.Length);
    }

}
