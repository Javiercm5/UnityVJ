using UnityEngine;
using System.Collections;

public class HealthKit : MonoBehaviour {
	public int healAmount = 10;

	GameObject player;
	PlayerController playerC;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject == player)
		{
			player.GetComponent<PlayerHealth>().Heal(healAmount);
			Destroy(gameObject);
		}
	}
}
