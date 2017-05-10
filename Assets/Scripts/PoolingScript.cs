using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingScript : MonoBehaviour { //failed attempt at using object pooling to create an infinite loop of obstacles

	public int columnPoolSize = 5;
	public GameObject columnPrefab;
	public float spawnRate = 4f;
	public float columnMin = -1f;
	public float columnMax = 3.5f;

	private GameObject[] columns;
	private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
	private float timeSinceLastSpawned;
	private float spawnXPosition = 10f;
	private int currentColumn = 0;

	void Start () {
		timeSinceLastSpawned = 0f; 
		columns = new GameObject[columnPoolSize]; //amount of obstacles loaded into the pool (in my case it's 5)
		for (int i = 0; i < columnPoolSize; i++) {

			columns [i] = (GameObject)Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity); //instantiates objects in specified position
		}
	}
	
	void Update () {
		timeSinceLastSpawned += Time.deltaTime; 

		if (PlayerController.instance.gameOver = false && timeSinceLastSpawned >= spawnRate) { //if player is alive and the right amount of time has passed
			timeSinceLastSpawned = 0f;
			float spawnYPosition = Random.Range (columnMin, columnMax); //spawns objects within a set random min/max height range
			columns [currentColumn].transform.position = new Vector2 (spawnXPosition, spawnYPosition); //moves the first obstacle over to the last, infinitely
			currentColumn++;

			if (currentColumn >= columnPoolSize) { //assures that column is never over the amount assigned within pool size
				currentColumn = 0;
			}
		}
	}
}

//aspects of this script adapted from official Unity "Recycling Obstacles With Object Pooling" tutorial
//https://www.youtube.com/watch?v=hn5LD17n1wc