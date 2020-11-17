using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kretanjePadanje : MonoBehaviour
{

    public float moveSpeed = 30f;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

    }
}
