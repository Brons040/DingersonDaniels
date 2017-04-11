using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Option {

    public Option(string text, int id)
    {
        optionsText = text;
        _missionId = id;
    }

    public string optionsText;
    public int _missionId;
    public int MissionId { get { return _missionId; } set { _missionId = value;  resultantMission = MissionController.Instance.Missions[value]; } }
    [System.NonSerialized]
    public Mission resultantMission;  
	
}
