using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

    ///TODO: Create the properties relevant to Characters keeping in mind the Resource class.
    ///Use getters and setters to protect key properties
    private int _level;
    public int Level { get { return _level; } set { _level = value; LevelUp(); } }

    private int _exampleInt;
    public int ExampleInt { get { return _exampleInt; } set { _exampleInt = value; } }

    private int _experience;
    public int Experience { get { return _experience; } set { _experience = value; CheckLevelUp(); } }

    public Equipment[] equipment;

    public Attribute[] attributes;

    public Resource[] recources;

    public Character()
    {
        attributes = new Attribute[4] {new Attribute(Attribute.AttributeType.Dexterity),

                                       new Attribute(Attribute.AttributeType.Intelligence),
                                       new Attribute(Attribute.AttributeType.Fortitude),
                                       new Attribute(Attribute.AttributeType.Stength) };



        recources = new Resource[3]
        {
            new Resource(ResourceType.Food),
            new Resource(ResourceType.Gold),
            new Resource(ResourceType.Water)
        };


  


    }
    public void LevelUp()
    {
        Debug.Log("Leveled Up");
    }

    public void CheckLevelUp()
    {
       
        if (_experience >= 100)
        {
            Level++;
            _experience = 0;
        }
    }

    




}
