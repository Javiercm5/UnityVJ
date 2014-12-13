using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float walkSpeed = 0.4f;
	public float sprintSpeed = 1.0f;

	public float normalJump = 2.5f;
	public float sprintJump = 3.0f;

	private float speed;
	private float jump;

	public bool jumping = false;
	public bool colliding = false;
	public bool attacking = false;

	public int maxJumpCount = 1;
	public ParticleSystem jumpParticles;
	public ParticleSystem powerUpParticles;
	int actualJumpCount = 0;

	private Animator animPlayer;
	public Camera cam;

	Vector3 inc;
	Vector3 pos;


	public AudioClip runSound;
	public AudioClip jumpSound;
	public AudioClip powerSound;
	public AudioClip footSteps;

	private bool key = false;


	private AudioSource playerSource, bonusSource, walkSource;

	void Awake()
	{
		speed = walkSpeed;
		jump = normalJump;

		animPlayer = GetComponent<Animator>();

		inc = Vector3.zero;
		pos = transform.position;
		AudioSource[] sources = GetComponents<AudioSource>();
		playerSource = sources[0]; 
		bonusSource = sources[1];
		walkSource = sources[2];
		walkSource.loop = true;
	
	}
	
	void Update()
	{
		inc = transform.position - pos;
		cam.transform.position += inc;

		if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.Mouse1))
		{
			speed = sprintSpeed;
			jump = sprintJump;

		}
		else
		{
			speed = walkSpeed;
			jump = normalJump;


		}

		pos = transform.position;

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
	
	public void incrementJumpCount(int inc = 1)
	{
		maxJumpCount += inc;
		powerUpParticles.Play();
		bonusSource.PlayOneShot(powerSound, 5.0f);
	}

	void Move()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		float y = rigidbody.velocity.y;

		if(horizontal != 0.0f || vertical != 0.0f)
		{
			Vector3 f = cam.transform.forward; f.y = 0.0f;
			Vector3 r = cam.transform.right; r.y = 0.0f;
			Vector3 v = (vertical*f.normalized + horizontal*r.normalized).normalized;
			
			animPlayer.SetFloat("speed", speed);

			Vector3 tmp = v*speed; tmp.y = y;
			rigidbody.velocity = tmp;

			Quaternion q = Quaternion.LookRotation(v);
			if(colliding) rigidbody.transform.rotation = q;	//Avoid errors with ropes

			if(speed == sprintSpeed && colliding){ 
				walkSource.clip = runSound;
				walkSource.volume = 1.0f;
				walkSource.enabled = true;
			}
			else walkSource.enabled = false;
		}
		else{ 
			animPlayer.SetFloat("speed", 0.0f);
			walkSource.enabled = false;
		}
	}

	void Jump()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			++actualJumpCount;

			Vector3 velJump = rigidbody.velocity;
			velJump.y = jump;
			rigidbody.velocity = velJump;

			jumping = true;
			animPlayer.SetBool("isJumping", jumping);
			jumpParticles.Play();
			playerSource.PlayOneShot (jumpSound, 1.0f);
		}
	}

	void Attack()
	{
		attacking = Input.GetKeyDown(KeyCode.Mouse0);
		animPlayer.SetBool("isAttacking", attacking);
		if(attacking) speed = 0.01f;
	}

	public void setKey()
	{
		key = true;
	}

	public bool hasKey()
	{
		return key;
	}

	void OnCollisionEnter(Collision col)
	{
		colliding = true;
		jumping = false;
		animPlayer.SetBool("isJumping", jumping);

		actualJumpCount = 0;
	}

	void OnCollisionStay(Collision col)
	{
		colliding = true;
		jumping = false;
		animPlayer.SetBool("isJumping", jumping);


	}

	void OnCollisionExit(Collision col)
	{
		colliding = false;
	}

}
