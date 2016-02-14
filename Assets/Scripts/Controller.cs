using UnityEngine;

public class Controller : MonoBehaviour
{
	[HideInInspector]public float horizontal;
	[HideInInspector]public float horizontalRaw;
	[HideInInspector]public float vertical;
	[HideInInspector]public float mouseX;
	[HideInInspector]public float mouseY;

	[HideInInspector]public bool walk;
	[HideInInspector]public bool attack;
	[HideInInspector]public bool attackHold;
	[HideInInspector]public bool parry;
	[HideInInspector]public bool parryHold;
	[HideInInspector]public bool jump;
	[HideInInspector]public bool jumpHold;
	[HideInInspector]public bool crouch;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		
	}
}
