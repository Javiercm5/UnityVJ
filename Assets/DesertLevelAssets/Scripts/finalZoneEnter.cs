using UnityEngine;
using System.Collections;

public class finalZoneEnter : MonoBehaviour
{
	GameObject player;
	public GameObject blocking;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject == player) blocking.SetActive(true);
	}
}
