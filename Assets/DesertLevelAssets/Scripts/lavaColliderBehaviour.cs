using UnityEngine;
using System.Collections;

public class lavaColliderBehaviour : MonoBehaviour
{
	GameObject player;
	PlayerHealth playerC;
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerC = player.GetComponent<PlayerHealth>();
	}

	void Update()
	{}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject == player) playerC.Die();
	}
}
