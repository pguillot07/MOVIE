using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Component à ajouter au Player (qui possède l'inventaire)

public class Inventory : MonoBehaviour
{
    public bool inventoryEnabled;
    public GameObject inventory;
    public GameObject slotHolder;

    //Sélectionne l'objet qui va être placé dans l'inventaire
    public GameObject object1;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;


    void Start()
    { 

        allSlots = 27; //A modifier si on modifie le nombre de cases de l'inventaire
        slot = new GameObject[allSlots];

        //Commence par lire toutes les cases de l'inventaire et marque vide celles qui le sont
        for (int i=0; i < allSlots; i++){
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
                slot[i].GetComponent<Slot>().empty = true;
        }

        //Fait disparaître object1 de la map pour le placer dans l'inventaire 
        Items item = object1.GetComponent<Items>();
        AddToInventory(object1, item.ID, item.description, item.icon);
    }

    void AddToInventory(GameObject itemObject, int itemID, string itemDescription, Sprite itemIcon){
        for (int i = 0; i < allSlots; i++){
            if(slot[i].GetComponent<Slot>().empty){
                //add item to slot
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().description = itemDescription;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false); //On fait disparaître l'objet de la map

                slot[i].GetComponent<Slot>().UpdateSlot(); //On fait apparaître l'icone de l'objet dans la cellule
                slot[i].GetComponent<Slot>().empty = false; //La cellule n'est plus vide
            }
            return;
        }
    }


    void Update()
    {
        //Affichage de l'inventaire avec la touche I
        if (Input.GetKeyDown(KeyCode.I))
            inventoryEnabled = !inventoryEnabled;
        
        if (inventoryEnabled == true)
        {
            inventory.SetActive(true);
        }
        else{
            inventory.SetActive(false);
        }
    }

}
