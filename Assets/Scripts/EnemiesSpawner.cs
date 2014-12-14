using UnityEngine;
using System.Collections;

public class EnemiesSpawner : MonoBehaviour {


	public GameObject enemy;
	public float spawnTime = 120.0f;
	public int maxSpawned = 3;
	public Transform[] spawnPoints;


	private GameObject player;
	private PlayerHealth playerHealth;
	private int enemiesSpawned = 0;
	private bool enabled = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponentInChildren<PlayerHealth>();
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn()
	{
		if(enabled){
			if(playerHealth.isDead || enemiesSpawned > maxSpawned) return;
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
			++enemiesSpawned;
		}
	}

	void OnTriggerStay(Collider hit)
	{
		if(hit.gameObject.tag == "Player"){
			enabled = true;
		}
	}

	void OnTriggerExit(Collider hit)
	{
		if(hit.gameObject.tag == "Player"){
			enabled = false;
		}
	}
}
