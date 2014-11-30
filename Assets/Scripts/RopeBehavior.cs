using UnityEngine;
using System.Collections;

public class RopeBehavior : MonoBehaviour {

	public float jumpDist = 0.5f;

	private FixedJoint joint;
	private bool ignore = false;
	private GameObject obj;


	void Start () {
	
	}


	void Update () {
		if(joint){
			obj.GetComponent<PlayerController>().colliding = false;

			if(Input.GetKeyDown(KeyCode.Space)){
				Destroy (joint);

				Vector3 velJump = rigidbody.velocity;
				velJump.y = jumpDist;
				obj.rigidbody.velocity = velJump;
				obj.GetComponent<PlayerController>().jumping = true;
				ignore = true;
			}
			float v = Input.GetAxisRaw ("Vertical");
			//obj.rigidbody.position+= v*transform.forward * 1 * Time.deltaTime;
		}
	}


	void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.tag == "Player" && !ignore){
			joint = (FixedJoint) gameObject.AddComponent("FixedJoint");
			joint.connectedBody = collision.rigidbody;
			obj = collision.gameObject;
			obj.GetComponent<PlayerController>().colliding = false;
		}
	}


	void OnTriggerExit(Collider collision)
	{
		if(collision.gameObject.tag == "Player") ignore = false;
	}
}
