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
        //Au démarrage, les input prennent les valeurs par défaut dans le menu, c'est-à-dire les dernières valeurs en mémoire
        WidthText = PlayerPrefs.GetString("WidthFile");
        inputWidth.text = WidthText;
        LengthText = PlayerPrefs.GetString("LengthFile");
        inputLength.text = LengthText;
        HeightText = PlayerPrefs.GetString("HeightFile");
        inputHeight.text = HeightText;
    }

    public void SaveInfo()
    {
        //La fonction est déclenchée quand l'utilisateur clique sur "Placer dans l'inventaire"
        //La string "WidthText" prend la valeur de l'input rentré par l'utilisateur.
        //Puis elle associe cette string au fichier "WidthFile" qui la garde en mémoire pour être réutilisée
        WidthText = inputWidth.text;
        PlayerPrefs.SetString("WidthFile", WidthText);

        //idem pour les autres dimensions
        LengthText = inputLength.text;
        PlayerPrefs.SetString("LengthFile", LengthText);
        HeightText = inputHeight.text;
        PlayerPrefs.SetString("HeightFile", HeightText);
    }
}
