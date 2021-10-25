using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Component à ajouter au Player (qui possède l'inventaire)

public class Inventory : MonoBehaviour
{
    public bool inventoryEnabled = false;
    public GameObject panel;
    public GameObject inventory;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    //Sélectionne l'objet qui va être placé dans l'inventaire
    public GameObject[] listInventory;
    private int allItemsInventory;

    private bool makeUpdate = false;
    
    void Start()
    {   //Commence par lire toutes les cases de l'inventaire et marque vide celles qui le sont
        
        allSlots = 27; //A modifier si on modifie le nombre de cases de l'inventaire
        slot = new GameObject[allSlots];
        
        for (int i=0; i < allSlots; i++){
            slot[i] = inventory.transform.GetChild(i).gameObject;
            slot[i].GetComponent<Slot>().IDslot = i;
            if (slot[i].GetComponent<Slot>().item == null){
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
        GameObject object1;
        Items item;
        allItemsInventory = listInventory.Length;
        for (int i=0; i < allItemsInventory; i++){
            object1 = listInventory[i];
            item = object1.GetComponent<Items>();
            Debug.Log(item.ID);
            AddToInventory(object1, item.ID, item.description, item.icon);
        }

        
    }

    void AddToInventory(GameObject itemObject, int itemID, string itemDescription, Sprite itemIcon){
        for (int i = 0; i < allSlots; i++){
            if(slot[i].GetComponent<Slot>().empty){
                //add item to slot
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().description = itemDescription;

                //itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false); //On fait disparaître l'objet de la map

                
                slot[i].GetComponent<Slot>().empty = false; //La cellule n'est plus vide

                return;
            }
        }

    }
    
    public void OutOfInventory(int IDslot){
        GameObject itemObject = slot[IDslot].GetComponent<Slot>().item;

        Vector3 playerPosition = GetComponent<Transform>().position;
        Vector3 itemPosition = playerPosition + new Vector3(1f,0f,0f);
    
        GameObject clone = Instantiate(itemObject);
        clone.SetActive(true);
        Debug.Log("OutOfInventory");
    }


    void Update()
    {
        //Affichage de l'inventaire avec la touche I
        if (Input.GetKeyDown(KeyCode.I)){
            inventoryEnabled = !inventoryEnabled;
            if (inventoryEnabled == true)
            {   
                panel.SetActive(true);
            }
            else{
                panel.SetActive(false);
            }
            makeUpdate = true;
        }
    

        if (makeUpdate){
            for (int i = 0; i < allSlots; i++){
                    slot[i].GetComponent<Slot>().UpdateSlot(); //On fait apparaître l'icone de l'objet dans la cellule
                }
            makeUpdate = false;
        }
    }
}
