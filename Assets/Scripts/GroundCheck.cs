using UnityEngine;

public class GroundCheck : MonoBehaviour
{
	public LayerMask groundLayer;
	public bool isGrounded;
	public float impact;
	public RaycastHit2D hit;

	public float fallTimer;
	public float impactTimer;
	public float maxImpact = 0.8f;
	public float antiSlide = 0.5f;

	void FallCheck()
	{
		if (!isGrounded)
		{
			fallTimer += Time.deltaTime;
			impact = 0;
		}
		else
		{
			if (fallTimer > 0)
			{
				impact = fallTimer;
			}
			fallTimer = 0;
		}
	}

	void CheckImpact()
	{
		if (impact != 0)
		{
			impactTimer += Time.deltaTime;

			if (impactTimer > maxImpact)
			{
				impact = 0;
				impactTimer = 0;
			}
		}
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			isGrounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			isGrounded = false;
		}
	}

	void Update ()
	{
		FallCheck();
		CheckImpact();
	}
}
