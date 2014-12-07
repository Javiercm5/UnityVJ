using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public int damage = 1;

	private int attackDelay = 0;

	public AudioClip attackSound;
	private AudioSource source;

	void Awake () {
		source = GetComponent<AudioSource>();
	}
	
	void Update () {
		if(attackDelay > 0) --attackDelay;
		if(attackDelay <= 0 && GetComponentInParent<PlayerController>().attacking){
			source.PlayOneShot(attackSound, 1.0f);
			attackDelay = 50;

		}
	}


	void OnTriggerStay(Collider  hit)
	{
		if(hit.gameObject.tag == "Enemy" && GetComponentInParent<PlayerController>().attacking 
		   && attackDelay <= 0){


			EnemyHealth eh = hit.gameObject.GetComponent<EnemyHealth>();
			eh.TakeDamage(damage);
			attackDelay = 50;
		}
	}


}
