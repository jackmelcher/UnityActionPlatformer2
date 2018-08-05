using UnityEngine;
using System.Collections;

public class NeutralSpecial : MonoBehaviour {

	public Rigidbody2D bullet;
	public float bulletSpeed = 30f;
	public float bulletCount = 0f;
	public float fireRate = 0.2f;

	private SpecialSystem special;
	private CharacterController2D playerControl;

	Animator anim;

	// Use this for initialization
	void Start () {
		special = transform.root.GetComponent<SpecialSystem>();
		playerControl = transform.root.GetComponent<CharacterController2D>();

		anim = transform.root.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Neutral Special
		if(special.neutralActive)
		{	
			special.neutralActive = false;

			anim.SetBool("isAttacking",true);
			anim.SetTrigger("SpecialAttack");
			
			InvokeRepeating("neutralSpecial",special.specialDelay,fireRate);
		}
	}

	void neutralSpecial()
	{
		anim.SetTrigger("NeutralSpecial");
		
		if(playerControl.facingRight)
		{
			Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(bulletSpeed, 0);
		}
		else
		{
			Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,180,0))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(-1*bulletSpeed, 0);
		}
		bulletCount++;
		
		if(bulletCount >= special.neutralSpecialDuration)
		{
			//end neutral special
			CancelInvoke("neutralSpecial");
			bulletCount = 0;
			anim.SetBool("isAttacking", false);
			//End special move
			special.end = true;
		}
	}
}
