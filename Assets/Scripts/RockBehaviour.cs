using UnityEngine;
using System.Collections;

public class RockBehaviour : MonoBehaviour {

	public int damage = 20;

	private bool destroyed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision hit)
	{
		if(!destroyed){
			if(hit.gameObject.CompareTag("Floor")) {
				gameObject.particleSystem.Play();
				gameObject.GetComponent<AudioSource>().Play ();
			}
			if(hit.gameObject.CompareTag("Player")){
				destroyed= true;
				gameObject.particleSystem.gravityModifier = 0;

				gameObject.particleSystem.Play();
				gameObject.GetComponent<MeshRenderer>().enabled = false;
				gameObject.GetComponent<Collider>().enabled = false;
				gameObject.GetComponent<Rigidbody>().detectCollisions = false;
				hit.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
			}
		}
	}

}
