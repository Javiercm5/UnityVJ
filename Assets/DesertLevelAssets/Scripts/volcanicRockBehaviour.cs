using UnityEngine;
using System.Collections;

public class volcanicRockBehaviour : MonoBehaviour
{
	GameObject player;
	PlayerHealth playerC;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerC = player.GetComponent<PlayerHealth>();
	}

	void Update()
	{
		if(transform.position.y <= -2.0f) Destroy(gameObject);
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject == player) playerC.TakeDamage(50);
		Destroy(gameObject);
	}
}
