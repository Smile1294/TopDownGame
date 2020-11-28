using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float FireSpeed;
    public float speed;
    public Rigidbody2D rb;
    Vector2 movement;
    public Camera cam;
    Vector2 MousePos;
    public Animator animator;
 
    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
       MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))
        {
            Shooet();

        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed *Time.deltaTime);
        Vector2 lookDir = MousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

    }

    void Shooet()
    {

        Vector2 lookDir = MousePos- rb.position ;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x )* Mathf.Rad2Deg;
        Vector2 shootingDirection = new Vector2(lookDir.x, lookDir.y);

        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrow.GetComponent<Rigidbody2D>().velocity = shootingDirection*FireSpeed;
        arrow.transform.Rotate(0.0f, 0.0f,angle);
        

    }



}
