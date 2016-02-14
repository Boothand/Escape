using UnityEngine;

public class PlayerController : Controller
{
	public string horizontalStr = "Horizontal";
	public string verticalStr = "Vertical";
	public string mouseXstr = "Mouse X";
	public string mouseYstr = "Mouse Y";
	public string attackStr = "Attack";
	public string parryStr = "Parry";
	public string jumpStr = "Jump";
	public string walkStr = "Walk";
	public string crouchStr = "Crouch";


	void Start ()
	{
	
	}
	
	void Update ()
	{
		horizontal = Input.GetAxis(horizontalStr);
		horizontalRaw = Input.GetAxisRaw(horizontalStr);
		vertical = Input.GetAxis(verticalStr);
		mouseX = Input.GetAxis(mouseXstr);
		mouseY = Input.GetAxis(mouseYstr);

		attack = Input.GetButtonDown(attackStr);
		attackHold = Input.GetButton(attackStr);
		parry = Input.GetButtonDown(parryStr);
		parryHold = Input.GetButton(parryStr);
		jump = Input.GetButtonDown(jumpStr);
		jumpHold = Input.GetButton(jumpStr);
		walk = Input.GetButton(walkStr);
		crouch = Input.GetButton(crouchStr);
	}
}
