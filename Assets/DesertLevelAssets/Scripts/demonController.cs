using UnityEngine;
using System.Collections;

public class demonController : MonoBehaviour
{
	public int attackDamage = 20;
	public float attackDelay = 8.0f;
	public float distFollowPlayer = 15.0f;

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

	float actualIT = 0.0f;
	public float invokingTime = 3.0f;

	bool invoking = false;
	bool startBattle = false;

	public GameObject blocking;

	float count = 0.0f;
	public float finCount = 10.0f;
	public GameObject invocation;

	public GameObject inv0;
	public GameObject inv1;
	public GameObject inv2;
	public GameObject inv3;
	public GameObject inv4;

	GameObject[] invs;

	public GameObject blockingI;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponentInChildren<PlayerHealth>();
		eh = GetComponent<EnemyHealth>();

		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animation>();

		invs = new GameObject[5];
		invs[0] = inv0; invs[1] = inv1; invs[2] = inv2; invs[3] = inv3; invs[4] = inv4;
	}

	void Update()
	{
		if(!startBattle && blockingI.activeSelf) startBattle = true;

		if(invoking)
		{
			actualIT += Time.deltaTime;
			if(actualIT >= invokingTime)
			{
				actualIT = 0.0f;
				invoking = false;
			}
		}

		if(startBattle)
		{
			count += Time.deltaTime;
			if(count >= finCount)
			{
				count = 0.0f;

				Random r = new Random(); int i = Random.Range(0, 4);
				GameObject invocationI = (GameObject)Instantiate(invocation, invs[i].transform.position, invs[i].transform.rotation);
				invocationI.GetComponent<DesertSpiderController>().throwPotion = true;
				invocationI.GetComponent<NavMeshAgent>().baseOffset = -1.2f;

				agent.Stop();
				anim.Play("Fury");

				invoking = true;
			}
		}

		if (isDead){
			if(deadTimer < 0) Destroy(gameObject);
			else --deadTimer;
		}

		else if(eh.dead()){
			// enemyWalkSource.Stop();
			
			agent.enabled = false;
			Die ();
		}

		else if(eh.isDamaged()){
			// enemyWalkSource.Stop();
			
			if(hurtTimer == 0){
				// enemySource.PlayOneShot(hurtClip, 2.0f);
				++hurtTimer;
			}
			else if(hurtTimer > 50){
				hurtTimer = 0;
				eh.setDamaged(false);
			}
			else ++hurtTimer;
		}

		else if (!invoking){
			timer += Time.deltaTime;
			if(timer > 1.2f){
				if(isAttacking)playerHealth.TakeDamage(attackDamage);
				isAttacking = false;
			}
			
			if(playerInRange && timer >= attackDelay){
				agent.Stop();
				// enemyWalkSource.Stop();
				Attack();
			}
			
			if(agent)
			{
				
				Vector3 difference = player.transform.position - transform.position;
				float distance = Mathf.Sqrt(Mathf.Pow(difference.x, 2.0f) + Mathf.Pow(difference.y, 2.0f) + Mathf.Pow(difference.z, 2.0f));

				NavMeshPath path = new NavMeshPath();
				bool hasFoundPath = agent.CalculatePath(player.transform.position, new NavMeshPath());

				if (!hasFoundPath){
					anim.Play ("Idle");
				}
				else if(distance <= distFollowPlayer && !isAttacking){ 
					// if(!enemyWalkSource.isPlaying) enemyWalkSource.Play();
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
		invoking = false;
		anim.Play ("Death");

		Destroy (blocking);
	}

	void Attack()
	{
		timer = 0.0f;
		isAttacking = true;
		anim.Play ("Attack2");
		// enemySource.PlayOneShot(attackClip, 2.0f);
		
		
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
