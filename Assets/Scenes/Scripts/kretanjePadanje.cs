using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kretanjePadanje : MonoBehaviour
{

    public float moveSpeed = 30f;

    public Sprite left, right;
  
    public SpriteRenderer player;

    private void Awake()
    {
        player.sprite = right;
    }


    // Start is called before the first frame update
    void Start()
    {
       
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

    }
}
