using UnityEngine;
using System.Collections;

public class PlayerChargeMelee : MonoBehaviour {

	public float chargeDelayTime = 3.0f;
	public float chargeReset = 3.0f;

	public bool isCharging = false;
	public bool Charged = false;

	private CharacterController2D playerControl;
	private BoxCollider2D hitbox;
	private Animator anim;
	private SpriteRenderer effect;

	private ElementSystem element;
	Animator animMelee;

	void Awake()
	{
		anim = transform.root.gameObject.GetComponent<Animator>();
		hitbox = GetComponent<BoxCollider2D>();
		effect = GetComponent<SpriteRenderer> ();
		playerControl = transform.root.GetComponent<CharacterController2D>();

		animMelee = GetComponent<Animator>();
		element = transform.root.GetComponent<ElementSystem>();

		anim.SetBool("isAttacking",false);
		effect.enabled = false;
		hitbox.enabled = false;
	}

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
		//Charge Mechanism
		if(Input.GetButton ("Fire2"))
		{
			chargeDelayTime = chargeDelayTime - Time.deltaTime;
		}
		
		if(Input.GetButtonUp ("Fire2") && chargeDelayTime > 0)
		{
			isCharging = false;
			chargeDelayTime = chargeReset;
		}

		if(Input.GetButtonUp ("Fire2") && Charged)
		{
			playerControl.attacking = true;
			anim.SetBool("isAttacking",true);
			anim.SetTrigger("ChargeMeleeAttack");
			effect.enabled = true;
			hitbox.enabled = true;
			isCharging = false;
			Charged = false;
			chargeDelayTime = chargeReset;
			Invoke ("endAttack",0.2f);
		}

		if(chargeDelayTime <=0)
			Charged = true;
	}
	
	void endAttack ()
	{
		playerControl.attacking = false;
		effect.enabled = false;
		hitbox.enabled = false;
		anim.SetBool("isAttacking", false);
	}
}