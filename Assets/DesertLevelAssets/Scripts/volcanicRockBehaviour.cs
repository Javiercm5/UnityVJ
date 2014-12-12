using UnityEngine;
using System.Collections;

public class volcanicRockBehaviour : MonoBehaviour
{
	public int damage = 50;

	GameObject player;
	PlayerHealth playerC;

	bool beDestroyed = false;

	float actualTime = 0.0f;
	float timeToDestroy = 0.2f;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerC = player.GetComponent<PlayerHealth>();
	}

	void Update()
	{
		if(beDestroyed)
		{
			actualTime += Time.deltaTime;
			if(actualTime >= timeToDestroy) Destroy(gameObject);
		}

		if(transform.position.y <= -2.0f) Destroy(gameObject);
	}

	void OnCollisionEnter(Collision col)
	{
		if(beDestroyed) return;

		if(col.gameObject == player) playerC.TakeDamage(damage);

		GetComponent<ParticleSystem>().Play();
		GetComponent<AudioSource>().Play();

		destroyRock();
	}

	void destroyRock()
	{
		beDestroyed = true;
	}
}
