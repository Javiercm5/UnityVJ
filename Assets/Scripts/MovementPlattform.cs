using UnityEngine;
using System.Collections;

public class MovementPlattform : MonoBehaviour {



	/*public Vector3 limit;
	public float speed = 5;

	private float dist;
	private int  direction = 1;
	private float currDist = 0.0f;


	void Start () {
		dist = limit.magnitude;
		limit.Normalize();
	}
	

	void Update () {
		Vector3 newPosition = transform.position + direction*speed*limit*0.1f;
		rigidbody.MovePosition(newPosition);
		currDist += speed*Time.deltaTime*0.1f;

		if(currDist >= dist){
			currDist = 0;
			direction = -direction;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position, limit);

	}*/

	public Transform platform;
	public Transform startTransform;
	public Transform endTransform;

	public float platformSpeed;
	private Vector3 direction;
	private Transform destination;

	void Awake()
	{
		SetDestination(startTransform);
	}

	void FixedUpdate()
	{
		platform.rigidbody.MovePosition(platform.position + direction * platformSpeed * Time.fixedDeltaTime);
		if(Vector3.Distance(platform.position, destination.position) < platformSpeed * Time.fixedDeltaTime){
			SetDestination(destination == startTransform ? endTransform : startTransform);
		}
	}

	void SetDestination(Transform dest)
	{
		destination = dest;
		direction = (destination.position - platform.position).normalized;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(startTransform.position, platform.localScale);

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(endTransform.position, platform.localScale);
		
	}

}
