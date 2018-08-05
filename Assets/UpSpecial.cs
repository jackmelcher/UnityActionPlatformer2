using UnityEngine;
using System.Collections;

public class UpSpecial : MonoBehaviour {

	public float hSpeed = 1f;
	public float vSpeed = 20f;
	public float currentTime = 0f;
	public bool timer = false;

	private CharacterController2D playerControl;
	private SpecialSystem special;
	private BoxCollider2D hitbox;
	private SpriteRenderer effect;

	Animator anim;

	// Use this for initialization
	void Start () {
		special = transform.root.GetComponent<SpecialSystem>();
		hitbox = GetComponent<BoxCollider2D>();
		effect = GetComponent<SpriteRenderer>();
		playerControl = transform.root.GetComponent<CharacterController2D>();

		anim = transform.root.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Up Special
		if(special.upActive)
		{
			special.upActive = false;

			anim.SetBool("isAttacking",true);
			anim.SetTrigger("SpecialAttack");

			if(!playerControl.facingRight)
				Invoke("upSpecialLeft",special.specialDelay);
			else if(playerControl.facingRight)
				Invoke("upSpecialRight",special.specialDelay);
		}
		if(timer)
		{
			currentTime = currentTime + Time.deltaTime;
		}
		if(currentTime >= special.upSpecialDuration)
		{
			currentTime = 0f;
			timer = false;
			effect.enabled = false;
			hitbox.enabled = false;
			anim.SetBool("isAttacking", false);
			//End special move
			special.end = true;
			
		}
	}
	
	void upSpecialLeft ()
	{
		timer = true;
		
		anim.SetTrigger("UpSpecial");

		transform.root.GetComponent<Rigidbody2D>().velocity = new Vector2(-1*hSpeed,vSpeed);
		
		effect.enabled = true;
		hitbox.enabled = true;
	}
	void upSpecialRight ()
	{
		timer = true;
		
		anim.SetTrigger("UpSpecial");
		
		transform.root.GetComponent<Rigidbody2D>().velocity = new Vector2(hSpeed,vSpeed);
		
		effect.enabled = true;
		hitbox.enabled = true;
	}
}
