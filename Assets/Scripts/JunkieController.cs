using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkieController : MonoBehaviour {

    public Transform target; 
    public float moveSpeed;
    
    //public bool canMove;
    public int rotationSpeed;
    public bool movingRight; 

    // Use this for initialization
    void Start() {   
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /* if (canMove)
         {
             myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
         }*/

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), moveSpeed * Time.deltaTime);

        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1); //flipping the player when we move to the left
        }
        else if (target.position.x < transform.position.x) //flipping the player back to the right (the ONES are actually XYZ) (again negative/positive value, makes sense really)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    
/*void OnBecameVisible()
    {
        canMove = true;
    }*/



    void OnTriggerEnter2D(Collider2D other) //enemy gets destroyed by on-trigger colliders and goes out of the game (saving resources) 
    {

        if(other.tag == "Bullet")
        {
            Destroy(gameObject);
        }

    }

}