using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

		
	public float walkSpeed = 0.4f;
	public float sprintSpeed = 1.0f;

	public float normalJump = 65.0f;
	public float sprintJump = 75.0f;

	private float speed;
	private float jump;


	public bool jumping = false;
	public bool colliding = false;


	private Animator animPlayer;


	//public GameObject camera;
	//Vector3 cameraOriginalRotation;

	public Camera cam;




	void Awake () {
		animPlayer = GetComponent <Animator> ();
		speed = walkSpeed;
		jump = normalJump;
		//cameraOriginalRotation = camera.transform.rotation.eulerAngles;
	}


	
	void Update () {

		if(Input.GetKey(KeyCode.LeftShift)){
			speed = sprintSpeed;
			jump = sprintJump;
		}
		else {
			speed = walkSpeed;
			jump = normalJump;
		}



		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		if(colliding) Attack ();

		Move (h, v);

		if(colliding && Input.GetKey(KeyCode.Space)){
			Jump ();
		}
		
		Attack ();



	}
	
		
	void Move(float horizontal, float vertical)
	{
		
		if (horizontal != 0.0f || vertical != 0.0f) {
			//Vector3 v1 = (vertical*Vector3.forward.normalized + horizontal*Vector3.right.normalized).normalized;
			
			Vector3 f = cam.transform.forward;
			f.y = 0.0f;
			
			Vector3 r = cam.transform.right;
			r.y = 0.0f;
			
			Vector3 v = (vertical*f.normalized + horizontal*r.normalized).normalized;
			
			animPlayer.SetFloat("speed", speed);
			
			transform.position += v * Time.deltaTime * speed;
			Quaternion q = Quaternion.LookRotation(v);
			rigidbody.transform.rotation = q;
			
		}
		
		else 	animPlayer.SetFloat("speed", 0.0f);
	}

	/* 
	 * El que teniem abans
	 * 
	void Move(float horizontal, float vertical)
	{

		if (horizontal != 0.0f || vertical != 0.0f) {
			animPlayer.SetFloat("speed", speed);

			camera.transform.Rotate(-cameraOriginalRotation); //solucionar problemes amb calculs posteriors
			
			Vector3 mov = Vector3.zero;
			Vector3 rot = Vector3.zero;


			mov += new Vector3 (horizontal, 0.0f, vertical);
			rot += camera.transform.right * horizontal;
			rot += camera.transform.forward * vertical;

			
		
			
			mov *= speed*Time.fixedDeltaTime;
			
			camera.transform.Translate(mov, camera.transform);
			gameObject.transform.Translate(mov, camera.transform);
			
			gameObject.transform.LookAt(gameObject.transform.position + rot);
			
			camera.transform.Rotate(cameraOriginalRotation); //recuperar la rotacio original


		}
		else 	animPlayer.SetFloat("speed", 0.0f);
	}
*/






	void Jump()
	{
		Vector3 movement = new Vector3();

		animPlayer.SetBool("isJumping", true);
		movement.Set (0.0f, jump * Time.deltaTime, 0.0f);
		rigidbody.AddForce (new Vector3(0.0f, jump, 0.0f));
	}

	void Attack()
	{
		bool attacking = Input.GetKey (KeyCode.Mouse0);
		animPlayer.SetBool("isAttacking", attacking);
		if(attacking) speed = 0.01f;
	}
	
	void OnCollisionEnter(Collision hit)
	{
		//if(hit.collider.tag == "Floor")	
			colliding = true;
			animPlayer.SetBool("isJumping", false);
	}

	void OnCollisionExit(Collision hit)
	{
		//if(hit.collider.tag == "Floor") 
			colliding = false;

	}
}
