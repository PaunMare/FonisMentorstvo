using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    AudioSource audioSource;
    public InputField ime;
    public GameObject go;
    Text neki;

    private void Awake()
    {
        neki = go.GetComponent<Text>();
        //neki = GameObject.FindGameObjectWithTag("Skor").GetComponent<Text>();
        audioSource = GameObject.FindGameObjectWithTag("MenuSound").GetComponent<AudioSource>();
    }



    public void PlayGame() {

        DontDestroyOnLoad(go);
        neki.text = ime.text + '$' +'0';
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit() {
        Application.Quit();
    }
}
