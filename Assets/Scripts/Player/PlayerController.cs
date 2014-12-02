using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float walkSpeed = 0.4f;
	public float sprintSpeed = 1.0f;

	public float normalJump = 2.0f;
	public float sprintJump = 3.0f;

	private float speed;
	private float jump;

	public bool jumping = false;
	public bool colliding = false;
	public bool attacking = false;

	public int maxJumpCount = 1;
	int actualJumpCount = 0;

	private Animator animPlayer;
	public Camera cam;

	void Awake()
	{
		speed = walkSpeed;
		jump = normalJump;

		animPlayer = GetComponent<Animator>();
	}
	
	void Update()
	{
		if(Input.GetKey(KeyCode.LeftShift))
		{
			speed = sprintSpeed;
			jump = sprintJump;
		}
		else
		{
			speed = walkSpeed;
			jump = normalJump;
		}

		if(canMove()) Move();
		if(canJump()) Jump();
		if(canAttack()) Attack();
	}

	bool canMove()
	{
		return true;
	}
		
	bool canJump()
	{
		return actualJumpCount < maxJumpCount;
	}

	bool canAttack()
	{
		return colliding;
	}
	
	void incrementJumpCount(int inc = 1)
	{
		maxJumpCount += inc;
	}

	void Move()
	{
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		if(horizontal != 0.0f || vertical != 0.0f)
		{
			Vector3 f = cam.transform.forward; f.y = 0.0f;
			Vector3 r = cam.transform.right; r.y = 0.0f;
			Vector3 v = (vertical*f.normalized + horizontal*r.normalized).normalized;
			
			animPlayer.SetFloat("speed", speed);
			
			transform.position += v*Time.fixedDeltaTime*speed;

			Quaternion q = Quaternion.LookRotation(v);
			if(colliding) rigidbody.transform.rotation = q;	//Avoid errors with ropes
		}
		else animPlayer.SetFloat("speed", 0.0f);
	}

	void Jump()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			++actualJumpCount;
			Vector3 velJump = rigidbody.velocity;
			velJump.y = actualJumpCount*jump;
			rigidbody.velocity = velJump;

			jumping = true;
			animPlayer.SetBool("isJumping", jumping);
			

		}
	}

	void Attack()
	{
		attacking = Input.GetKey (KeyCode.Mouse0);
		animPlayer.SetBool("isAttacking", attacking);
		if(attacking) speed = 0.01f;
	}

	void OnCollisionEnter(Collision col)
	{
		colliding = true;
		jumping = false;
		animPlayer.SetBool("isJumping", jumping);

		actualJumpCount = 0;
		Debug.Log ("Jump ended: "+col.collider.gameObject.name);

	}

	void OnCollisionExit(Collision col)
	{
		colliding = false;
	}
}
