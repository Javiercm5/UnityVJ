using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth = 5;

	public ParticleSystem bloodParticles;

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
		if(!isDead){
			damaged = true;
			health -= amountDamage;
			bloodParticles.Play();
			if(health <= 0) Die ();
		}

	}

	void Die()
	{
		isDead = true;
	}

	public bool dead()
	{
		return isDead;
	}

	public bool isDamaged()
	{
		return damaged;
	}

	public void setDamaged(bool d)
	{
		damaged = d;
	}
}
