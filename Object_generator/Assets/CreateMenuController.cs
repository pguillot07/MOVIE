using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMenuController : MonoBehaviour
{

    public Canvas CreateMenu;

    void Start()
    {
        //Le menu est d�sactiv� au d�but du jeu
        CreateMenu.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        //Si la touche "C" est appuy�e, le menu s'affiche
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
