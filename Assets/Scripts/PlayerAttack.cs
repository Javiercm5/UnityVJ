using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	private int attackDelay = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(attackDelay > 0) --attackDelay;
	}

	void OnTriggerStay(Collider  hit)
	{
		if(hit.gameObject.tag == "Enemy" && GetComponentInParent<PlayerController>().attacking 
		   && attackDelay <= 0){

			EnemyLife el = hit.gameObject.GetComponent<EnemyLife>();
			el.life -= 1;
			attackDelay = 50;
		}
	}
}
