using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	//object to follow
	public GameObject objectToFollow;
	//default speed of camera
	public float speed = 2.0f;

	void Update () {
		float interpolation = speed * Time.deltaTime;
		//new position of camera
		Vector3 position = this.transform.position;
		position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);

		this.transform.position = position;
	}
}
