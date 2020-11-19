using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Prelazni : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;

    string funfacts;
    string[] niz; 
    void Start()
    {
        StreamReader sr = new StreamReader("Assets/funfacts.txt", true);
        funfacts = sr.ReadToEnd();
        sr.Close();
        niz = funfacts.Split('$');
        int i = Random.Range(0, niz.Length);
        text.text = niz[i];
        Invoke("predjiNaIgru", 15f);
        


    }

    public void predjiNaIgru()
    {
        SceneManager.LoadScene(3);
    }

    
}
