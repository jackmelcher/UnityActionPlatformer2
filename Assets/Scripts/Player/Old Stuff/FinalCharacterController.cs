using UnityEngine;
using System.Collections;

public class FinalCharacterController : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool abletojump = true;			// Condition for whether the player should jump.
	[HideInInspector]
	public bool abletodash = true;			//Condition for dashing
	[HideInInspector]
	public bool onSlant = false;			//Check if on slanted platform
	[HideInInspector]
	public bool dashTimeOn = false;			
	[HideInInspector]
	public bool attacking = false;			//Check if attacking so player doesnt flip in the middle of an attack
	
	public bool Lance = false;				//Check which weapon is equipped
	public bool Sword = false;
	public bool Axe = false;
	
	public float moveSpeed = 10f;			// The fastest the player can travel in the x axis.
	public float jumpSpeed = 20f;			// Amount of force added when the player jumps.
	public float dashSpeed = 20f;			//How fast player dashes
	public float dashTime = 1.0f;			//How long the player dashes for
	public float dashTimeReset = 1.0f;		//Reset Dash Timer
	
	Animator anim;
	
	void Start ()
	{
		//Initialize Animator and reset animator booleans
		anim = GetComponent<Animator>();
		anim.SetBool ("isJumping", false);
		anim.SetBool ("isDashing", false);
		
		anim.SetBool ("Lance", false);
		anim.SetBool ("Sword", false);
		anim.SetBool ("Axe", false);
	}
	
	void FixedUpdate ()
	{
		// Cache the horizontal input for flip check
		float move = Input.GetAxis("Horizontal");
		//Set velocity values to variables
		float horizontalmovement = GetComponent<Rigidbody2D>().velocity.x;
		float verticalmovement = GetComponent<Rigidbody2D>().velocity.y;
		
		//Cache movement for animations
		anim.SetFloat ("hSpeed", Mathf.Abs (horizontalmovement));
		anim.SetFloat ("vSpeed", Mathf.Abs (verticalmovement));
		
		// If the input is moving the player right and the player is facing left flip the player.
		if(move > 0.1 && !facingRight && !attacking)
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right flip the player.
		else if(move < -0.1 && facingRight && !attacking)
			Flip();
		
		//enable dash animation
		if(!abletodash && abletojump)
			anim.SetBool ("isDashing", true);
		//disable dash animation
		if (abletodash || !abletojump)
			anim.SetBool ("isDashing", false);
	}
	
	void Update ()
	{
		//Use axis to determine positive/negative direction.
		float movementDirection = Input.GetAxis("Horizontal");
		
		//running
		if(Input.GetButton ("Horizontal") && abletodash)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (movementDirection*moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		//if dashing is activated
		else if(Input.GetButton ("Horizontal") && !abletodash)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (movementDirection*dashSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		
		//stop
		if(Input.GetButtonUp ("Horizontal") && !onSlant) //flat surface
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y);
		}
		else if(Input.GetButtonUp ("Horizontal") && onSlant) //slants or stairs
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
		}
		
		//jump
		if(Input.GetButtonDown ("Jump") && abletojump)
		{
			abletojump = false;
			anim.SetBool ("isJumping", true);
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpSpeed);
		}
		//dash
		if (Input.GetKeyDown (KeyCode.J) && Input.GetButton ("Horizontal") && abletodash && abletojump)
		{
			abletodash = false;
			dashTimeOn = true;
		}
		if(dashTimeOn)
			dashTime = dashTime - Time.deltaTime;
		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) < 1 || (abletojump && dashTime <= 0))
		{
			abletodash = true;
			dashTimeOn = false;
			dashTime = dashTimeReset;
		}
		
		//Switch Weapons
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			anim.SetBool ("Lance", true);
			anim.SetBool ("Sword", false);
			anim.SetBool ("Axe", false);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			anim.SetBool ("Lance", false);
			anim.SetBool ("Sword", true);
			anim.SetBool ("Axe", false);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			anim.SetBool ("Lance", false);
			anim.SetBool ("Sword", false);
			anim.SetBool ("Axe", true);
		}
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void OnCollisionEnter2D (Collision2D reEnable)
	{
		
	}
	
	void OnCollisionStay2D (Collision2D Enable)
	{
		//ReEnable jumping while touching floor
		if (Enable.gameObject.tag == "Floor" || Enable.gameObject.tag == "Slant") 
		{
			abletojump = true;
			anim.SetBool ("isJumping", false);
		}
		//enable onSlant check
		if (Enable.gameObject.tag == "Slant") 
		{
			onSlant = true;
		}
	}
	
	void OnCollisionExit2D (Collision2D Disable)
	{
		//Disable Jumping and Dasing while airborne
		if (Disable.gameObject.tag == "Floor" || Disable.gameObject.tag == "Slant")
		{
			abletojump = false;
			anim.SetBool ("isJumping", true);
		}
		//disable onSlant check
		if (Disable.gameObject.tag == "Slant")
		{
			onSlant = false;
		}
	}
}
