using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth = 5;

	private int health;
	private bool damaged = false;
	private bool isDead = false;


	void Start () {
		health = maxHealth;
	}
	

	void Update () {

	}


	public void TakeDamage(int amountDamage)
	{
		damaged = true;
		health -= amountDamage;
		if(health <= 0 && !isDead) Die ();
	}


	void Die()
	{
		Destroy(gameObject);
	}
}
