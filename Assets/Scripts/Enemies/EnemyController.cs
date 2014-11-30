using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public int attackDamage = 10;
	public float attackDelay = 1.0f;

	private GameObject player;
	private PlayerHealth playerHealth;
	private bool playerInRange = false;
	private float timer;


	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponentInChildren <PlayerHealth> ();

	}
	

	void Update () {
		timer += Time.deltaTime;
		if(playerInRange && timer >= attackDelay) Attack ();
	}


	void Attack()
	{
		timer = 0.0f;
		playerHealth.TakeDamage(attackDamage);		
		

	}


	void OnTriggerEnter (Collider hit)
	{
		if(hit.gameObject == player){
			playerInRange = true;
		}
	}


	void OnTriggerExit(Collider hit)
	{
		if(hit.gameObject == player){
			playerInRange = false;
		}
	}

}
