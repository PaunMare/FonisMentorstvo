using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class voce : MonoBehaviour
{
    Text skor;
    
    int poeni = 0;
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;


    private void Awake()
    {
        skor = GameObject.FindGameObjectWithTag("Skor").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            string trenutniP = skor.text;
            poeni = int.Parse(trenutniP);
            poeni = poeni + 10;
            skor.text = poeni.ToString();
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -screenBounds.y*2) {
            Destroy(this.gameObject);
        }
       // Debug.Log(transform.position.y + " " + screenBounds.y);
    }
}
