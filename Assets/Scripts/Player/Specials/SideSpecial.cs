using UnityEngine;
using System.Collections;

public class SideSpecial : MonoBehaviour {

	public float hSpeed = 20f;
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
		//Side Special
		if(special.sideActive)
		{
			special.sideActive = false;

			anim.SetBool("isAttacking",true);
			anim.SetTrigger("SpecialAttack");

			if(!playerControl.facingRight)
				Invoke("sideSpecialLeft",special.specialDelay);
			else if(playerControl.facingRight)
				Invoke("sideSpecialRight",special.specialDelay);
		}
		if(timer)
		{
			currentTime = currentTime + Time.deltaTime;
		}
		if(currentTime >= special.sideSpecialDuration)
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

	void sideSpecialLeft ()
	{
		timer = true;

		anim.SetTrigger("SideSpecial");

		transform.root.GetComponent<Rigidbody2D>().velocity = new Vector2(-1*hSpeed,0);

		effect.enabled = true;
		hitbox.enabled = true;
	}

	void sideSpecialRight ()
	{
		timer = true;
		
		anim.SetTrigger("SideSpecial");

		transform.root.GetComponent<Rigidbody2D>().velocity = new Vector2(hSpeed,0);
		
		effect.enabled = true;
		hitbox.enabled = true;
	}

}
