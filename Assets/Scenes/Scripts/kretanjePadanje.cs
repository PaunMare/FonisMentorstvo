using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kretanjePadanje : MonoBehaviour
{

    public Vector2 brzina = new Vector2(50, 0);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 kretanje = new Vector3(brzina.x*inputX,0);
        transform.Translate(kretanje);
    }
}
