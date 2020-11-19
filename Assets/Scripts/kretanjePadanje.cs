using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class kretanjePadanje : MonoBehaviour
{

    string ime;
    string[] stringovi;
    private GameObject go;
    public Text tajmer;
    float pocetnoV=60;
    static float trenutnoV = 0;
    public Text score;
    public float moveSpeed = 30f;
    public float horizontalMove=0f;
    public Sprite left, right;
   
    public SpriteRenderer player;
    public Animator animator;

   
    private void Awake()
    {
        go = GameObject.FindGameObjectWithTag("SadINIkad");
        stringovi = go.GetComponent<Text>().text.Split('$');
        ime = stringovi[0];
        Debug.Log(ime);
    }

    // Start is called before the first frame update
    void Start()
    {
        trenutnoV = pocetnoV;  
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        trenutnoV -= 1 * Time.deltaTime;
        tajmer.text = trenutnoV.ToString("0");
        if (trenutnoV <= 0) {
            trenutnoV = 0;
            stringovi[1] = score.text;
            go.GetComponent<Text>().text = stringovi[0] + '$' + stringovi[1];
            SceneManager.LoadScene(2);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
           if (Input.GetKeyDown(KeyCode.A))
           {
               player.sprite = left;

           }
           else if(Input.GetKeyDown(KeyCode.D)){
               player.sprite = right;
           }
           Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
           transform.position += movement * Time.deltaTime * moveSpeed;
           horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;


        animator.SetFloat("Speed", horizontalMove);
    }
}
