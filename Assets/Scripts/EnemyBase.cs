using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour {
    public Transform playerTarget;
    public int hitPoints;
    public float movementSpeed;
    protected HoboCop hoboCop;
    public int scoreValue;

    // Use this for initialization
    public void Start () {
        playerTarget = GameObject.FindWithTag("Player").transform;

        GameObject hoboCopObject = GameObject.FindWithTag("Player");

        if (hoboCopObject) {
            hoboCop = hoboCopObject.GetComponent<HoboCop>();
        }
		float speedFactor = 1f + HoboCop.score/50;
		increaseSpeed (speedFactor);
    }

    // Update is called once per frame
    public void Update () {
        /*
            Checkes on each frame if the hitpoints are less than or equal to 0
            If so add score to scoreboard and destroy enemy
         */
        if (hitPoints <= 0) {
            hoboCop.AddScore(scoreValue);
            Destroy(gameObject);
        }

        // Keeps track of the enemies current position and changes it based on the location of the playerTarget AKA The Player
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerTarget.position.x, playerTarget.position.y), movementSpeed * Time.deltaTime);
        // Compares the location of the enemy to the postion of the player and sets the movement in that direction.
        if (playerTarget.position.x > transform.position.x) {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if (playerTarget.position.x < transform.position.x) {
            transform.localScale = new Vector3(1, 1, 1);
        } else {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    //enemy gets destroyed by on-trigger colliders and goes out of the game (saving resources) 
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Bullet") {
            hitPoints--;
        }
    }
    /*
      Checks current player score and multiplies the attributes of the enemy based on it.
      scoreThreshold is the number of points jump by, doubles number
      isSpeed checks if the method is changing the speed or the hitpoints. True changes speed, False changes hitpoints
    */
    protected void checkScore(int scoreThreshold, bool isSpeed) {

        if(HoboCop.score <= scoreThreshold) {
            if(isSpeed) {
                increaseSpeed(1);
            } else {
                increaseHitpoints(1);
            }
        } else if(HoboCop.score >= scoreThreshold) {
            if (isSpeed) {
                increaseSpeed(1.5f);
            } else {
                increaseHitpoints(2);
            }
        } else if(HoboCop.score >= scoreThreshold * 2) {
            if (isSpeed) {
                increaseSpeed(2);
            } else {
                increaseHitpoints(3);
            }
        } else if(HoboCop.score >= scoreThreshold * 4) {
            if (isSpeed) {
                increaseSpeed(2.5f);
            } else {
                increaseHitpoints(4);
            }
        }
    }

    private void increaseSpeed(float speedMultiplier) {
        this.movementSpeed *= speedMultiplier;
    }

    private void increaseHitpoints(int hitpointMultiplier) {
        this.hitPoints *= hitpointMultiplier;
    }
}