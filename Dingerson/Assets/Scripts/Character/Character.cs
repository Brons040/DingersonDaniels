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

   
    
    public void LevelUp()
    {

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
