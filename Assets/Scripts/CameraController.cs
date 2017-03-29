using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target; //GameObject is a type of variable that let's use use in any object in our world
    public float followAhead; //value that lets us manipulate the amount of which the camera will go ahead/behind of the player 
    private Vector3 targetPosition; //Vector3 is a vector with three values XYZ
    public float smoothing; //value to manipulate camera smoothing
 
	//use this for initalization
	void Start () {
		
	}
	
	// Update is called once per frame (update loop happens every moment of the game)
	void Update () {
        targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z); //follow HoboCop

        if(target.transform.localScale.x > 0f)
        {
            targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y, targetPosition.z); //move the camera ahead (x) if we are facing RIGHT
        }
        else
        {
            targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z); //move the camera ahead (x) if we are facing LEFT
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime); //lerp is an amazing tool, it basically sets the vector as a = where we want our camera to be, b = what do we want it to follow, c = how fast do we want it to follow the target
                                                                                                           //Time.deltaTime = how long it takes between 1 frame of animation to another? 30 fps = 1/30 of a second = deltaTime 

        
     
    }

}
