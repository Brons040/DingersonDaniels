using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MissionController : MonoBehaviour {

    private Mission _currentMission;
    public Mission CurrentMission { get { return _currentMission; } set { _currentMission = value; UpdateUI();  } }

    public TextAsset jsonFile;
    public TextAsset langFile;

    public Language lang;

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
        lang = new Language();
        lang.ac = ReadLanguageInfo();
        lang.PrintAlphabet();    
        
        /**Option option1 = new Option("Yes", 1);
        Option option2 = new Option("No", 2);
        option1.dropChance = 50;
        option2.dropChance = 100;
        option1.resourceModifier = new Resource(ResourceType.Gold, 100);
        option2.resourceModifier = new Resource(ResourceType.Gold, -50);
        option1.attributeModifier = new Attribute(Attribute.AttributeType.Fortitude, 2);
        option2.attributeModifier = new Attribute(Attribute.AttributeType.Fortitude, -2);
        Mission m = new Mission();
        m.missionText = "Dump?";
        m.missionName = "Dump Test";
        m.missionId = 0;
        m.options = new Option[2] { option1, option2 };

        MissionCollection mc = new MissionCollection();
        mc.missions = new Mission[1] { m };*/

        //Debug.Log(JsonUtility.ToJson(m));
        //SaveMissionInfo(JsonUtility.ToJson(mc, true));
        ReadMissionInfo();
        //Missions.Add(m);
        CurrentMission = Missions[0];
        //CharacterController.Instance.UpdateUI();
       
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
        Option o = CurrentMission.options[buttonId];
        foreach(Mission missio in Missions)
        {
            if (missio.missionId == CurrentMission.options[buttonId]._missionId)  
                CurrentMission = missio;
        }
        CharacterController.Instance.ChangeAttributeValue(o.attributeModifier.type, o.attributeModifier.amount);
        CharacterController.Instance.ChangeResourceValue(o.resourceModifier.type, o.resourceModifier.amount);
        CharacterController.Instance.UpdateUI();

        //CurrentMission = CurrentMission.options[buttonId].resultantMission;

    }

    public void SaveMissionInfo(string json, string fileName)
    {        
        string path = null;
#if UNITY_EDITOR
        path = "Assets/Resources/GameJSONData/" + fileName + "ItemInfo.json";
#endif
#if UNITY_STANDALONE
        // You cannot add a subfolder, at least it does not work for me
        path = "Assets/Resources/" + fileName + ".json";
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

    public AlphabetCollection ReadLanguageInfo()
    {
        AlphabetCollection ac = JsonUtility.FromJson<AlphabetCollection>(langFile.text);
        return ac;
    }

    public void ReadMissionInfo()
    {
        MissionCollection mc = JsonUtility.FromJson<MissionCollection>(jsonFile.text);
        Mission[] tempMissions = mc.missions;
        Debug.Log(mc.missions.Length);
        foreach(Mission mission in tempMissions)
        {
            Missions.Add(mission);
            Debug.Log(mission.missionText + "!?");
        }
        Debug.Log(tempMissions.Length);
    }

}
