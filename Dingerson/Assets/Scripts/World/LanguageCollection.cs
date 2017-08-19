using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LanguageCollection  {

    public string[] keys;
    public string[] values;
    
    public Dictionary<string, string> CollectionToDictionary()
    {
        Dictionary<string, string> langDictionary = new Dictionary<string, string>();
        for(int i = 0; i < keys.Length; i++)
        {
            langDictionary.Add(keys[i], values[i]);
        }
        return langDictionary;
    }

    public static LanguageCollection DictionaryToCollection(Dictionary<string, string> langDictionary)
    {
        LanguageCollection lc = new LanguageCollection();
        lc.keys = new string[langDictionary.Count];
        lc.values = new string[langDictionary.Count];       
        langDictionary.Values.CopyTo(lc.values, 0);
        langDictionary.Keys.CopyTo(lc.keys, 0);
       
        return lc;
            
    }  
    
    

}
