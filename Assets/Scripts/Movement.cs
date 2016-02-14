using UnityEngine;

public class Movement : MonoBehaviour
{
	Controller ctr;
	public GroundCheck gr;
	Rigidbody2D rb;
	Animator anim;

	float jumpTimer;

	bool moving;
	bool walking;
	bool jumping;
	bool falling;
	bool crouching;
	Vector3 moveVector;
	public float movestrength;
	public float jumpStrength;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		ctr = GetComponent<Controller>();
		anim = GetComponent<Animator>();
	}
	
	void Update ()
	{
		//Moving
		moveVector = new Vector3(ctr.horizontalRaw * (movestrength) * Time.deltaTime, 0f, 0f);
		walking = ctr.walk;
		
		if (walking)
		{
			moveVector /= 2;
		}

		if (!jumping && !falling)
		{
			rb.AddForce(moveVector);
		}
		else //When jumping or falling.
		{
			if (ctr.horizontalRaw * rb.velocity.x <= 0) // If you're moving the opposite way of your velocity.
			{
				//You may struggle a bit against the jumping direction.
				rb.AddForce(moveVector * 2f);
			}
		}

		RaycastHit2D hit = Physics2D.Raycast(gr.transform.position, Vector3.down, 0.2f, gr.groundLayer);

		//Prevent sliding down walkable slopes
		if (hit)
		{
			rb.velocity -= new Vector2(hit.normal.x * gr.antiSlide, 0);

			transform.position += new Vector3(0f, -hit.normal.x * Mathf.Abs(rb.velocity.x) * Time.deltaTime * (rb.velocity.x - hit.normal.x > 0 ? 1 : -1), 0f) * 0.5f;
		}

		moving = moveVector.x != 0f;

		if (gr.isGrounded)
		{
			rb.drag = 13f;
		}
		else
		{
			rb.drag = 0f;
		}

		//Crouching
		if (ctr.crouch && gr.isGrounded)
		{
			crouching = true;
		}
		else
		{
			crouching = false;
		}

		//Jumping
		if (ctr.jump && (gr.isGrounded || gr.fallTimer < 0.1f)) //One frame only //Remember: jump spam, hill-fall thing.
		{
			jumping = true;
			rb.AddForce(Vector2.up * jumpStrength * Time.deltaTime, ForceMode2D.Impulse);

			//Animation
			anim.SetTrigger("Jump");
		}

		if (jumping)
		{
			jumpTimer += Time.deltaTime;

			if (jumpTimer > 0.1f && gr.isGrounded)
			{
				jumping = false;
				jumpTimer = 0f;
			}
		}

		//Falling
		if (!gr.isGrounded && !jumping)
		{
			falling = true;
		}
		else
		{
			falling = false;
		}


		//Animations
		anim.SetFloat("RunSpeed", ctr.horizontal);
		anim.SetBool("Walking", walking);
		anim.SetBool("Grounded", gr.isGrounded);
		anim.SetFloat("Falltimer", gr.fallTimer);
		anim.SetBool("Crouching", crouching);
	}
}
