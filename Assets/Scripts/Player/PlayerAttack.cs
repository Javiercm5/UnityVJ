using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public int damage = 1;

	private int attackDelay = 0;


	void Start () {
	
	}
	
	void Update () {
		if(attackDelay > 0) --attackDelay;
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
