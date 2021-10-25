using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Component commun à tous les Slots de l'inventaire

public class Slot : MonoBehaviour, IPointerClickHandler //, IDragHandler, IEndDragHandler
{
    //Possède les mêmes caractéristiques que Items
    public GameObject item;
    public int ID;
    public string description;
    //Quatre caract. supplémentaires
    public bool empty;
    public Sprite icon;
    public int IDslot;
    public GameObject Player;

    private Vector3 initialPosition; 

    //Permet d'afficher l'icone de l'objet dans la cellule
    public void UpdateSlot(){
        this.GetComponent<Image>().sprite = icon;
        initialPosition = transform.position;
        Debug.Log(initialPosition);
    }

    public void OnPointerClick(PointerEventData pointerEventData){
        if (!empty){
            Debug.Log("pop!");
            Inventory inventory = Player.GetComponent<Inventory>();
            inventory.OutOfInventory(IDslot);
        }
        
    }
/* 
    public void OnDrag(PointerEventData eventData){
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData){
        transform.position = initialPosition;
    } */
}
