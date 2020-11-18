using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] voce;
    private int randBr;
    public float respawnTime = 0.5f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(voceWawe());
    }
    private void SpawnVoce() {
        randBr = Random.Range(0, 5);
        GameObject v = Instantiate(voce[randBr]) as GameObject;
        v.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
    }
    // Update is called once per frame
    IEnumerator voceWawe() {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            SpawnVoce();
        }
    }
}
