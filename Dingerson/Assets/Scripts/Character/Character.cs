using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character {

    ///TODO: Create the properties relevant to Characters keeping in mind the Resource class.
    ///Use getters and setters to protect key properties
    private int _level;    
    public int Level { get { return _level; } set { _level = value; LevelUp(); } }

    public string name;

    private int _exampleInt;
    public int ExampleInt { get { return _exampleInt; } set { _exampleInt = value; } }

    private int _experience;
    public int Experience { get { return _experience; } set { _experience = value; CheckLevelUp(); } }

    public Equipment[] equipment;
    public Attribute[] attributes;
    public Resource[] resources;   
    
    public void LevelUp()
    {
        ///Show Level Up Dialog
        Debug.Log("Leveled Up!");
    }

    public void CheckLevelUp()
    {
       
        if (_experience >= 100)
        {
            Level++;
            _experience = 0;
        }
    }

    public Character()
    {
        resources = new Resource[3] { new Resource(ResourceType.Food, 10), new Resource(ResourceType.Gold, 100) , new Resource(ResourceType.Water, 100)};
        attributes = new Attribute[4] { new Attribute(Attribute.AttributeType.Dexterity, 5), new Attribute(Attribute.AttributeType.Fortitude, 5), new Attribute(Attribute.AttributeType.Intelligence, 5), new Attribute(Attribute.AttributeType.Strength, 5)};
    }
}
