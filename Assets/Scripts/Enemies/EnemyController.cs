using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public int attackDamage = 10;
	public float attackDelay = 1.0f;
	public float distFollowPlayer = 3.0f;

	private GameObject player;
	private PlayerHealth playerHealth;
	private bool playerInRange = false;
	private float timer;
	private NavMeshAgent agent;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponentInChildren<PlayerHealth>();

		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		timer += Time.deltaTime;
		if(playerInRange && timer >= attackDelay) Attack();

		if(agent)
		{
			Vector3 difference = player.transform.position - transform.position;
			float distance = Mathf.Sqrt(Mathf.Pow(difference.x, 2.0f) + Mathf.Pow(difference.y, 2.0f) + Mathf.Pow(difference.z, 2.0f));

			if(distance <= distFollowPlayer) agent.SetDestination(player.transform.position);
			else agent.Stop();
		}
	}

	void Attack()
	{
		timer = 0.0f;
		playerHealth.TakeDamage(attackDamage);
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
