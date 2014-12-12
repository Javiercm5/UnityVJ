using UnityEngine;
using System.Collections;

public class dieFallScript : MonoBehaviour {

	GameObject player;
	PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponentInChildren<PlayerHealth>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject == player){
			playerHealth.Die();		
		}
	}
}
