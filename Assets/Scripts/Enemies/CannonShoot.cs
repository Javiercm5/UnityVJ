using UnityEngine;
using System.Collections;

public class CannonShoot : MonoBehaviour {

	public Rigidbody projectile;
	public float bulletSpeed = 15;
	public float iniDelay = 0.0f;
	public float rateOfFire = 1.0f;

	private float cont;

	void Start () {
		cont = iniDelay;
	}
	

	void Update () {
		cont += Time.deltaTime;
		if(cont >= 1/rateOfFire){
			cont = 0;

			Rigidbody bullet = (Rigidbody) Instantiate(projectile, transform.position, transform.rotation);
			Destroy (bullet.gameObject, 6);

			bullet.velocity = transform.up * bulletSpeed;
			Physics.IgnoreCollision (bullet.collider, gameObject.collider);
		}
	}


	//DEBUG
	void OnDrawGizmos(){
		Gizmos.color = Color.white;
		Gizmos.DrawRay (transform.position, transform.up);
	}
}
