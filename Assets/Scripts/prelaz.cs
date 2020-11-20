using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prelaz : MonoBehaviour
{
    private void Start()
    {
        Invoke("Dalje",10f);
    }

    public void Dalje() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
