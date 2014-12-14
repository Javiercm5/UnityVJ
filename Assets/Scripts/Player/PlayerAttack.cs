using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public int damage = 2;

	private int attackDelay = 0;
	private bool impact = false;

	public AudioClip attackSound;
	private AudioSource source;
	private EnemyHealth eh;
	private int enemiesKilled = 0;

	void Awake () {
		source = GetComponent<AudioSource>();
	}
	
	void Update () {
		bool attack = GetComponentInParent<PlayerController>().attacking && attackDelay <= 0;
		if(attack){
			if(impact){
				if(eh){ 
					eh.TakeDamage(damage);
					if(eh.dead()) enemiesKilled++;
				}
			}
			attackDelay = 50;
			source.PlayOneShot(attackSound, 1.0f);
		}

		if(attackDelay > 0) --attackDelay;
	}


	void OnTriggerStay(Collider  hit)
	{
			impact = hit.gameObject.tag == "Enemy";
			if(impact) eh = hit.gameObject.GetComponent<EnemyHealth>();
	}
	void OnTriggerExit(Collider  hit)
	{
		if(hit.gameObject.tag == "Enemy") impact = false;
	}

	public int GetEnemiesKilled()
	{
		return enemiesKilled;
	}

}
