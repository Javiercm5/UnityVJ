using UnityEngine;
using System.Collections;

public class SkeletonController : MonoBehaviour {

	public int attackDamage = 15;
	public float attackDelay = 2.0f;
	public float distFollowPlayer = 2.0f;
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
	private bool isEnabled = true;
	
	
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
				anim.Play ("gethit");
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
			if(timer > 1.0f)isAttacking = false;
			
			if(playerInRange && timer >= attackDelay){
				agent.Stop();
				enemyWalkSource.Stop();
				Attack();
			}
			
			if(agent)
			{
				
				Vector3 difference = player.transform.position - transform.position;
				float distance = Mathf.Sqrt(Mathf.Pow(difference.x, 2.0f) + Mathf.Pow(difference.y, 2.0f) + Mathf.Pow(difference.z, 2.0f));

				NavMeshPath path = new NavMeshPath();
				bool hasFoundPath = agent.CalculatePath(player.transform.position, path);

				if (!hasFoundPath){
					anim.Play ("dance");
				}

				else if(distance <= distFollowPlayer && !isAttacking){ 
					if(!enemyWalkSource.isPlaying) enemyWalkSource.Play();
					agent.SetDestination(player.transform.position);
					anim.Play("run");
				}
				else if (!isAttacking){
					agent.Stop();
					anim.Play("idle");
				} 
			}
			
			
		}
	}
	
	void Die()
	{
		isDead = true;
		anim.Play ("die");
	}
	
	
	void Attack()
	{
		timer = 0.0f;
		playerHealth.TakeDamage(attackDamage);
		isAttacking = true;
		anim.Play ("attack");	
		enemySource.PlayOneShot(attackClip, 2.0f);
		
		
	}

	public void SetEnabled(bool enable)
	{
		isEnabled = enable;
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
