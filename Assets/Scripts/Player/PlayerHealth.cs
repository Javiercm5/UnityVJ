using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startHealth = 100;
	private int actualHealth;
	public Slider healthSlider;
	public ParticleSystem bloodParticles;
	public ParticleSystem dieParticles;
	public ParticleSystem healParticles;

	public AudioClip hurtSound;
	public AudioClip dieSound;
	public AudioClip healSound;

	public GameObject gameManagement;

	public bool isDead = false;
	private bool damaged = false;
	private Color mainPlayerColor = new Color(0.5f,0.5f,0.5f,1.0f);
	private Renderer playerRender;
	private AudioSource playerSource, bonusSource;



	void Awake () 
	{
		actualHealth = startHealth;
		playerRender = (Renderer) transform.GetComponentInChildren<Renderer>();
		AudioSource[] sources = GetComponents<AudioSource>();
		playerSource = sources[0]; bonusSource = sources[1];
	}


	void Update () 
	{
		if (transform.position.y <= -2.0f && !isDead) Die(); //Game management
		
		if(damaged){
			playerRender.material.color = new Color(0.5f, 0.0f, 0.0f, 0.1f);
			transform.rigidbody.AddForce(transform.forward * -50.0f);
		}

		else playerRender.material.color = Color.Lerp (playerRender.material.color, mainPlayerColor, 5.0f * Time.deltaTime);


		if (isDead) {
			transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f) * Time.deltaTime;
			if(transform.localScale.x < 0.1) gameManagement.GetComponent<GameManagement>().LooseGame();//Application.LoadLevel(Application.loadedLevel);	
			bloodParticles.Play();
		}

		damaged = false;
		healthSlider.value = actualHealth;
	}


	public void TakeDamage(int amountDamage)
	{
		damaged = true;
		actualHealth -= amountDamage;
		bloodParticles.Play();
		if(actualHealth <= 0 && !isDead) Die ();
		playerSource.PlayOneShot(hurtSound, 2.0f);
	}

	public void Heal(int amountHeal)
	{
		actualHealth = Mathf.Min(startHealth, actualHealth + amountHeal);
		healParticles.Play();
		playerSource.PlayOneShot(healSound, 5.0f);
	}


	public void Die()
	{
		isDead = true;
		playerRender.material.color = new Color (0.7f, 0.3f, 0.3f);
		//gameObject.tag = "Untagged";
		dieParticles.Play();
		bonusSource.PlayOneShot(dieSound, 5.0f);
	}

	public bool hasFullHealth()
	{
		return actualHealth == startHealth;
	}

}
