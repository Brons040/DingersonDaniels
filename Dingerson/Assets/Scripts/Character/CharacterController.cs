using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {

    private string playerName = "dingerson";

    private Character CurrentCharacter;
    private static CharacterController _instance;
    public static CharacterController Instance
    {
          
        get { return _instance; }
    }
    public Text[] AttributeTextItems;



    public string PlayerName
    {
        get
        {
            return playerName;
        }

        set
        {
            playerName = value;
        }
    }

    void Start()
        {
        CurrentCharacter = new Character();

        _instance = this;
        }   

    public void UpdateUI()
        {
        AttributeTextItems[0].text = PlayerName;
        for(int i = 1; i < AttributeTextItems.Length; i++)
        {
            AttributeTextItems[i].GetComponentInChildren<Text>().text = CurrentCharacter.attributes[i - 1].ammount.ToString();
        }
        }

    public void ChangeAttributeValue(string type)
        {
        switch(type)
        {
            case "Dexterity":
                foreach(Attribute att in CurrentCharacter.attributes)
                {
                    if (att.type == Attribute.AttributeType.Dexterity)
                    {
                        att.ammount++;

                    }
                }
                break;

            case "Strength":
                foreach(Attribute att in CurrentCharacter.attributes)
                {
                    if (att.type == Attribute.AttributeType.Stength)
                    {
                        att.ammount++;
                    }
                }
                break;

            case "Intelligence":
                foreach(Attribute att in CurrentCharacter.attributes)
                {
                    if(att.type == Attribute.AttributeType.Intelligence)
                    {
                        att.ammount++;
                    }
                }
                break;

            case "Fortitude":
                foreach(Attribute att in CurrentCharacter.attributes)
                {
                    if (att.type == Attribute.AttributeType.Fortitude)
                    {
                        att.ammount++;
                    }

                }
                break;






        }
        UpdateUI();

            
        }
    public void ChangeAttributeValue(Attribute curAtt)
    {
                foreach (Attribute att in CurrentCharacter.attributes)
                {
                    if (att.type == curAtt.type)
                    {
                        att.ammount +=curAtt.ammount;
                    }
                }
    }



    public void ChangeResourceValue(Resource curRes)
    {
        foreach(Resource res in CurrentCharacter.recources)
        {
            if (res.type == curRes.type)
            {
                res.type += curRes.amount;
            }
        }
    }



    public void GenerateEquipment()
    {
        int slot = Random.Range(0, 3);
        int type = Random.Range(0, 3);
        int amt = Random.Range(0, 15);

        Attribute.AttributeType attType = Attribute.AttributeType.Dexterity;

        Equipment.EquipmentSlot equipType = Equipment.EquipmentSlot.Feet;

        switch (slot)
        {
            case 0:
                equipType = Equipment.EquipmentSlot.Feet;
                break;
            case 1: equipType = Equipment.EquipmentSlot.Finger;
                break;
            case 2:equipType = Equipment.EquipmentSlot.Head;
                break;
            case 3:equipType = Equipment.EquipmentSlot.Weapon;
                break;
        }
        switch (type)
        {
            case 0:
                attType = Attribute.AttributeType.Dexterity;
                break;
            case 1:
                attType = Attribute.AttributeType.Fortitude;
                break;
            case 2:
                attType = Attribute.AttributeType.Intelligence;
                break;
            case 3:
                attType = Attribute.AttributeType.Stength;
                break;
        }

        Attribute a = new Attribute(attType);
        a.ammount = amt;
        Attribute[] atts = new Attribute[1];

        CurrentCharacter.equipment[0] = new Equipment(equipType, atts);
        Debug.Log(CurrentCharacter.equipment[0].modifiers[0].ammount);

    }



}





