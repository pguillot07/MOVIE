using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemController : MonoBehaviour, IDragHandler
{
    Vector3 worldPosition;

    public void OnDrag(PointerEventData eventData){
        Debug.Log("drag");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if(Physics.Raycast(ray, out hitData, 1000))
        {
            transform.position  = hitData.point;
        }
    }


}
