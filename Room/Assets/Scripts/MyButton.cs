using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyButton : Button, IPointerDownHandler, IPointerUpHandler { 

    public bool buttonIsPressed;

    override public void OnPointerDown(PointerEventData eventData)
    {
        buttonIsPressed = true;
    }

    override public void OnPointerUp(PointerEventData eventData)
    {
        buttonIsPressed = false;
    }

   public bool GetButtonIsPressed()
    {
        return buttonIsPressed;
    }
}
