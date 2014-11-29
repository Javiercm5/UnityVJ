using UnityEngine;
using System.Collections;

public class MovementPlattform : MonoBehaviour {

	public Vector3 limit;
	public float speed = 5;

	private float dist;
	private int  direction = -1;
	private float currDist = 0.0f;

	// Use this for initialization
	void Start () {
		dist = limit.magnitude;
		limit.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.velocity = direction*limit*speed;
		currDist += speed*Time.deltaTime;
		if(currDist >= dist){
			currDist = 0;
			direction = -direction;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position, limit);

	}
	
}
