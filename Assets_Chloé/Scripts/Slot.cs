using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Component commun à tous les Slots de l'inventaire

public class Slot : MonoBehaviour
{
    //Possède les mêmes caractéristiques que Items
    public GameObject item;
    public int ID;
    public string description;
    //Deux caract. supplémentaires
    public bool empty;
    public Sprite icon;

    //Permet d'afficher l'icone de l'objet dans la cellule
    public void UpdateSlot(){
        this.GetComponent<Image>().sprite = icon;
    }
}
