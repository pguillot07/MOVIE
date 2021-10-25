using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDimensions : MonoBehaviour
{

    public InputField inputWidth;
    public InputField inputLength;
    public InputField inputHeight;
    private string WidthText;
    private string LengthText;
    private string HeightText;

    private void Start()
    {
        //Au d�marrage, les input prennent les valeurs par d�faut dans le menu, c'est-�-dire les derni�res valeurs en m�moire
        WidthText = PlayerPrefs.GetString("WidthFile");
        inputWidth.text = WidthText;
        LengthText = PlayerPrefs.GetString("LengthFile");
        inputLength.text = LengthText;
        HeightText = PlayerPrefs.GetString("HeightFile");
        inputHeight.text = HeightText;
    }

    public void SaveInfo()
    {
        //La fonction est d�clench�e quand l'utilisateur clique sur "Placer dans l'inventaire"
        //La string "WidthText" prend la valeur de l'input rentr� par l'utilisateur.
        //Puis elle associe cette string au fichier "WidthFile" qui la garde en m�moire pour �tre r�utilis�e
        WidthText = inputWidth.text;
        PlayerPrefs.SetString("WidthFile", WidthText);

        //idem pour les autres dimensions
        LengthText = inputLength.text;
        PlayerPrefs.SetString("LengthFile", LengthText);
        HeightText = inputHeight.text;
        PlayerPrefs.SetString("HeightFile", HeightText);
    }
}
