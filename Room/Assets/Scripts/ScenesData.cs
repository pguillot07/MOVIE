using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ScenesData
{
    public string sceneName; //Nom de la scene qu'on sauvegarde
    public List<ObjectData> itemsList = new List<ObjectData>(); //Liste des objets de la scène qu'on sauvegarde

    public ScenesData (string name, List<GameObject> list)
    {
        this.sceneName = name;
        this.itemsList = new List<ObjectData>();
        
        for (int i = 0; i < list.Count; i ++)
        {
            GameObject go = list[i];
            ObjectData oD = new ObjectData
            {
                position = go.transform.position,
                rotation = go.transform.rotation,
                indexInList = i
            };
            this.itemsList.Add(oD);
        }   
    }
}
