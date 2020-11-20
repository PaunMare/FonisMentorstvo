using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using UnityEngine.SceneManagement;
public class saljiNaSajt : MonoBehaviour
{
    GameObject go;

    private void Awake()
    {
        go = GameObject.FindGameObjectWithTag("SadINIkad");
        Invoke("Promeni", 16f);
    }
    public void Promeni() {
        Submit();
        Application.OpenURL("https://unity-testing-49c5b.web.app/");
        Application.OpenURL("https://aplauz.fonis.rs");
        SceneManager.LoadScene(0);
    }
    
    public void Submit()
    {
        PostOnDatebase();
    }
    private void PostOnDatebase()
    {
        string[] strings = go.GetComponent<Text>().text.Split('$');
        Player player = new Player();
        player.name = strings[0];
        player.score = strings[1];
        RestClient.Post("https://unity-testing-49c5b.firebaseio.com/.json", player);
        Destroy(go.gameObject);
    }
}
[System.Serializable]
public class Player
{
    public string name, score;
}