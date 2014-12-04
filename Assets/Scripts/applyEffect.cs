using UnityEngine;
using System.Collections;

public class applyEffect : MonoBehaviour
{
	GameObject player;
	PlayerController playerC;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerC = player.GetComponent<PlayerController>();
	}

	void Update()
	{}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject == player)
		{
			playerC.incrementJumpCount();
			Destroy(gameObject);
		}
	}
}
