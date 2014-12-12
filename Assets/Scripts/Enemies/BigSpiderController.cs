using UnityEngine;
using System.Collections;

public class BigSpiderController : MonoBehaviour {

	public int attackDamage = 15;
	public float attackDelay = 4.0f;
	public float distFollowPlayer = 3.0f;

	public AudioClip attackClip, walkClip, hurtClip;
	
	private GameObject player;
	private PlayerHealth playerHealth;
	private bool playerInRange = false;
	private float timer;
	private NavMeshAgent agent;
	private Animation anim;
	private bool isAttacking = false;
	private EnemyHealth eh;
	private bool isDead = false;
	private int deadTimer = 100;
	private int hurtTimer = 0;

	private AudioSource enemySource, enemyWalkSource;
	
	
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponentInChildren<PlayerHealth>();
		eh = GetComponent<EnemyHealth>();
		
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animation>();
		AudioSource[] sources  = GetComponents<AudioSource>();
		enemySource = sources[0]; enemyWalkSource = sources[1];
		
		enemyWalkSource.clip = walkClip;
		enemyWalkSource.loop = true;
		enemyWalkSource.volume = 1.0f;
	}
	
	
	void Update()
	{
		if (isDead){
			if(deadTimer < 0) Destroy(gameObject);
			else --deadTimer;
		}
		
		else if(eh.dead()){
			enemyWalkSource.Stop();
			
			agent.enabled = false;
			Die ();
		}
		
		else if(eh.isDamaged()){
			enemyWalkSource.Stop();
			
			if(hurtTimer == 0){
				enemySource.PlayOneShot(hurtClip, 2.0f);
				++hurtTimer;
			}
			else if(hurtTimer > 50){
				hurtTimer = 0;
				eh.setDamaged(false);
			}
			else ++hurtTimer;
		}
		
		else{
			timer += Time.deltaTime;
			if(timer > 1.2f){
				if(isAttacking)playerHealth.TakeDamage(attackDamage);
				isAttacking = false;
			}
			
			if(playerInRange && timer >= attackDelay){
				agent.Stop();
				enemyWalkSource.Stop();
				Attack();
			}
			
			if(agent)
			{
				
				Vector3 difference = player.transform.position - transform.position;
				float distance = Mathf.Sqrt(Mathf.Pow(difference.x, 2.0f) + Mathf.Pow(difference.y, 2.0f) + Mathf.Pow(difference.z, 2.0f));
				
				if(distance <= distFollowPlayer && !isAttacking){ 
					if(!enemyWalkSource.isPlaying) enemyWalkSource.Play();
					agent.SetDestination(player.transform.position);
					anim.Play("Walk");
				}
				else if (!isAttacking){
					agent.Stop();
					anim.Play("Idle");
				}
			}
			
			
		}
	}
	
	void Die()
	{
		isDead = true;
		anim.Play ("Death");
	}
	
	
	void Attack()
	{
		timer = 0.0f;
		isAttacking = true;
		anim.Play ("Attack");	
		enemySource.PlayOneShot(attackClip, 2.0f);
		
		
	}
	
	void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject == player) playerInRange = true;
	}
	
	void OnTriggerExit(Collider hit)
	{
		if(hit.gameObject == player) playerInRange = false;
	}

}
