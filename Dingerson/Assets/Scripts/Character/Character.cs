using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

    ///TODO: Create the properties relevant to Characters keeping in mind the Resource class.
    ///Use getters and setters to protect key properties
    ///






    private int _exampleInt;
    public int ExampleInt { get { return _exampleInt; } set { _exampleInt = value; } }

    ///For the experience property add an additional funciton call to the set block called CheckLevelUp.  
    ///Then write that function in this class.  It should check the experience of the Character against a level up barrier, then increment
    ///the characters level if applicable
}
