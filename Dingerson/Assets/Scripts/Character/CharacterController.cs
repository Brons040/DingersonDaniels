using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {

    public Text[] AttributeTextItems;
    public Text[] ResourceTextItems;
    public Text ExperienceTextItem;
    public GameObject LevelUpDialogue;
    public Text NameTextItem;
    Character ourCharacter;

    private static CharacterController _instance;
    public static CharacterController Instance { get { return _instance; } }

	// Use this for initialization
	void Start () {
        Random.Range(0, 100);
        _instance = this;
        ourCharacter = new Character();
        UpdateUI();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateUI()
    {
        ExperienceTextItem.text = "Experience: " + ourCharacter.Experience;
        NameTextItem.text = ourCharacter.name;
        for (int i = 0; i < AttributeTextItems.Length; i++)
        {
            AttributeTextItems[i].text = ourCharacter.attributes[i].type.ToString() + " " + ourCharacter.attributes[i].amount;            
        }
        for(int j = 0; j < ResourceTextItems.Length; j++)
        {
            ResourceTextItems[j].text = ourCharacter.resources[j].type.ToString() + " " + ourCharacter.attributes[j].amount;
        }
    }

    public void ChangeAttributeValue(Attribute.AttributeType type, int amount)
    {
        foreach(Attribute att in ourCharacter.attributes)
        {
            if (att.type == type)
            {
                att.amount += amount;
                AttributeTextItems[(int)type].text = att.type.ToString() + " " + amount;
            }
        }
        
    }

    public void ChangeResourceValue(ResourceType type, int amount)
    {
        foreach(Resource res in ourCharacter.resources)
        {
            if (res.type == type)
            {
                res.amount += amount;
                ResourceTextItems[(int)type].text = res.type.ToString() + " " + res.amount;
            }
        }
        
    }
}
