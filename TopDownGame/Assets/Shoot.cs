using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float FireSpeed;
    public Rigidbody2D player;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shooet();
            
        }
    }
     
    void Shooet()
    {

        GameObject arrow = Instantiate(arrowPrefab, transform.position,Quaternion.identity);
        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(FireSpeed, 0.0f);
        
    }
}
