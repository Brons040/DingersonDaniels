using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LanguageController : MonoBehaviour {

    private static LanguageController _instance;
    public static LanguageController Instance { get { return _instance; } }

    Language ourLanguage;
    public TextAsset langFile;
    public TextAsset langCollectionFile;

    void Start () {
        ourLanguage = new Language();
        ourLanguage.ac = ReadLangInfo();
        ReadLanguageCollectionInfo();
        RandomizeSentence("josh braden kevin");
        SaveDictionary("Language");
	}
    
    public void RandomizeWord(string word)
    {
        ourLanguage.RandomizeWord(word);
    }	

    public void RandomizeSentence(string sentence)
    {
        ourLanguage.RandomizeSentence(sentence);
    }          

    private AlphabetCollection ReadLangInfo()
    {
        AlphabetCollection ac = JsonUtility.FromJson<AlphabetCollection>(langFile.text);
        return ac;
    }

    private LanguageCollection ReadLanguageCollectionInfo()
    {
        LanguageCollection lc = JsonUtility.FromJson<LanguageCollection>(langCollectionFile.text);
        ourLanguage.languageDictionary = lc.CollectionToDictionary();
        return lc;
    }  

    private void SaveDictionary(string fileName)
    {
        string json = JsonUtility.ToJson(LanguageCollection.DictionaryToCollection(ourLanguage.languageDictionary), true);
#if UNITY_EDITOR
        string path = "Assets/Resources/GameJSONData/" + fileName + "ItemInfo.json";
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
}
