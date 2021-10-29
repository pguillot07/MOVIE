using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public Dictionary<string, ScenesData> dataDictionary;

    #region Unity Functions
    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.S))
        {
            dataDictionary = new Dictionary<string, ScenesData>();
            foreach (KeyValuePair<string, List<GameObject>> pair in DataHolder.dataHolder.GetItemsDictionary())
            {
                dataDictionary.Add(pair.Key, new ScenesData(pair.Key, pair.Value));
                SaveToJson(pair.Key);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadFromJson();
        }
    }
    #endregion

    public void SaveToJson(string key)
    {
        string inventoryData = JsonUtility.ToJson(dataDictionary[key]);
        string filePath = Application.persistentDataPath + "/" + key + ".json";
        System.IO.File.WriteAllText(filePath, inventoryData);
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/inventoryData.json";
        string inventoryData = System.IO.File.ReadAllText(filePath);
        dataDictionary = JsonUtility.FromJson<Dictionary<string, ScenesData>>(inventoryData);
        Rebuild();
    }

    public void Rebuild()
    {
        /*
        foreach (ObjectData oD in data.itemsList)
        {
            GameObject obj = DataHolder.dataHolder.GetItems()[oD.indexInList];
            obj.transform.position = oD.position;
            obj.transform.rotation = oD.rotation;
        }*/
    }   
}



