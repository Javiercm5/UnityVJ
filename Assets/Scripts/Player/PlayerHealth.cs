using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startHealth = 100;
	public int actualHealth;


	private bool isDead = false;
	private bool damaged = false;
	private Color mainPlayerColor = new Color(0.5f,0.5f,0.5f,1.0f);
	private Renderer playerRender;


	void Awake () 
	{
		actualHealth = startHealth;
		playerRender = (Renderer) transform.GetComponentInChildren<Renderer>();
	}


	void Update () 
	{
		if (transform.position.y <= -2.0f) Die();
		
		if(damaged){
			playerRender.material.color = new Color(0.5f, 0.0f, 0.0f, 0.1f);
			transform.rigidbody.AddForce(transform.forward * -50.0f);
		}

		else playerRender.material.color = Color.Lerp (playerRender.material.color, mainPlayerColor, 5.0f * Time.deltaTime);


		if (isDead) {
			transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f) * Time.deltaTime;
			if(transform.localScale.x < 0.1) Application.LoadLevel(Application.loadedLevel);	
		}

		damaged = false;
	}


	public void TakeDamage(int amountDamage)
	{
		damaged = true;
		actualHealth -= amountDamage;
		if(actualHealth <= 0 && !isDead) Die ();
	}


	void Die()
	{
		isDead = true;
		playerRender.material.color = new Color (0.7f, 0.3f, 0.3f);
		gameObject.tag = "Untagged";
	}
}
