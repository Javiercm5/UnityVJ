using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

	private bool dead = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dead) {
			transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f) * Time.deltaTime;
			if(transform.localScale.x < 0.1) Application.LoadLevel(Application.loadedLevel);	
		}
		if (transform.position.y <= -2.0f) dead = true;

	}

	void Die()
	{
		dead = true;
		rigidbody.isKinematic = true;
		renderer.material.color = new Color (0.7f, 0.3f, 0.3f);
		//gameObject.GetComponent("PlayerController").enable = false;
		gameObject.tag = "Untagged";
	}
}
