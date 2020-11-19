using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScene : MonoBehaviour
{
    #region Fields

    [SerializeField] // da bismo mogli da pristupimo preko ediota u unity-u i dodelimo panel
    private Transform memoryCard;

    [SerializeField] 
    private GameObject button;

    #endregion

    void Awake(){ 
        for(int i = 0; i <18; i++){ // kreira 18 polja i kaci ih na panel
            GameObject btn = Instantiate(button);
            btn.name = ""+ i;
            btn.transform.SetParent(memoryCard,false);
        }
    }
}
