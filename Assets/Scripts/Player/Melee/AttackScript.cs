using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

	private CharacterController2D playerControl;
	private BoxCollider2D hitbox;
	private Animator anim;
	private SpriteRenderer effect;

	private ElementSystem element;
	private Animator animMelee;

	void Awake()
	{
		anim = transform.root.gameObject.GetComponent<Animator>();
		hitbox = GetComponent<BoxCollider2D>();
		playerControl = transform.root.GetComponent<CharacterController2D>();
		effect = GetComponent<SpriteRenderer> ();

		animMelee = GetComponent<Animator>();
		element = transform.root.GetComponent<ElementSystem>();

		anim.SetBool("isAttacking",false);
		hitbox.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		//Element Check
		if(element.fire)
		{
			animMelee.SetTrigger("Fire");
		}
		if(element.ice)
		{
			animMelee.SetTrigger("Ice");
		}
		if(element.lightning)
		{
			animMelee.SetTrigger("Lightning");
		}
		if(element.wind)
		{
			animMelee.SetTrigger("Wind");
		}
		if(!element.fire && !element.ice && !element.lightning && !element.wind)
		{
			animMelee.SetTrigger("No Element");
		}

		if (Input.GetButtonDown ("Fire2") && !playerControl.attacking) 
		{
			hitbox.enabled = true;
			playerControl.attacking = true;
			effect.enabled = true;
			anim.SetBool("isAttacking",true);
			anim.SetTrigger("MeleeAttack");
			Invoke ("endAttack",0.2f);
		}

	}

	void endAttack ()
	{
		hitbox.enabled = false;
		playerControl.attacking = false;
		effect.enabled = false;
		anim.SetBool("isAttacking", false);
	}
}
