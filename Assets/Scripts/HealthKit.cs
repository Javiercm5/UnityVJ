using UnityEngine;
using System.Collections;

public class HealthKit : MonoBehaviour
{
	public int healAmount = 10;

	GameObject player;
	PlayerHealth playerH;
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerH = player.GetComponent<PlayerHealth>();
	}

	void Update()
	{}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject == player && !playerH.hasFullHealth())
		{
			playerH.Heal(healAmount);
			Destroy(gameObject);
		}
	}
}
