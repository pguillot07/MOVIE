using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMeasure : MonoBehaviour, IPointerClickHandler
{
    public GameObject Player;

    public void OnPointerClick(PointerEventData eventData){
        Debug.Log("bouton");
        Measure measure = Player.GetComponent<Measure>();
        measure.Reinitialise();
    } 

}
