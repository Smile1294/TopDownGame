using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public Vector2 velocity = new Vector2(0.0f,0.0f);
    public GameObject Player; 
    private void Update()
    {
        Vector2 currentposition = new Vector2(transform.position.x, transform.position.y);
        Vector2 newposition = currentposition + velocity * Time.deltaTime;
        RaycastHit2D[] hits = Physics2D.LinecastAll(currentposition, newposition);
        foreach(RaycastHit2D hit in hits)
        {
            GameObject other = hit.collider.gameObject;
            if(other != Player)
            {
                if (other.CompareTag("Player"))
                {
                    Player = other.gameObject;
                    Player.GetComponent<PlayerMovement>().takedmg(20);
                    Destroy(gameObject);
                    break;                   
                }
            }
          }
        transform.position = newposition;

    }
  
}
