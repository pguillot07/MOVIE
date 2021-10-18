using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMenuController : MonoBehaviour
{

    public Canvas CreateMenu;

    void Start()
    {
        CreateMenu.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (CreateMenu.GetComponent<Canvas>().enabled == false)
            {
                CreateMenu.GetComponent<Canvas>().enabled = true;
            }
            else
            {
                CreateMenu.GetComponent<Canvas>().enabled = false;
            }
        }
    }

}
