using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	//init object which will be spawned
	public GameObject BasicEnemy;
	//vector to keep the position of the object which will be spawned
	Vector2 whereToSpawn;
	//rate in seconds gonna be randomised
	float spawnRate;
	//zeroing the time on the beggining
	float nextSpawn = 0f;

	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn) {
			spawnRate = Random.Range(1f,3f);
			nextSpawn = Time.time + spawnRate;
			whereToSpawn = new Vector2 (transform.position.x, transform.position.y);
			//instantiate the object
			Instantiate (BasicEnemy, whereToSpawn, Quaternion.identity);
		}
	}
}
