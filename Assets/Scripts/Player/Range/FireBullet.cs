using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour 
{
	public Rigidbody2D bullet;
	public Rigidbody2D chargedBullet;

	public Rigidbody2D Fire;
	public Rigidbody2D chargedFire;
	public Rigidbody2D Ice;
	public Rigidbody2D chargedIce;
	public Rigidbody2D Lightning;
	public Rigidbody2D chargedLightning;
	public Rigidbody2D Wind;
	public Rigidbody2D chargedWind;

	public float bulletSpeed = 30f;
	public float bulletSpeedFire = 30f;
	public float bulletSpeedIce = 30f;
	public float bulletSpeedLightning = 30f;
	public float bulletSpeedWind = 30f;
	public float chargeDelayTime = 3.0f;
	public float chargeReset = 3.0f;

	public float RateOfFire = 1f;
	public bool fireEnabled = true;
	
	public bool Charged = false;

	private CharacterController2D player;
	private ElementSystem element;
	private Animator anim;


	void Awake()
	{
		anim = transform.root.gameObject.GetComponent<Animator>();
		player = transform.root.GetComponent<CharacterController2D>();
		element = transform.root.GetComponent<ElementSystem>();
	}
	
	void Update () 
	{
		//Charging Mechanism
		if(Input.GetButton ("Fire1"))
		{
			chargeDelayTime = chargeDelayTime - Time.deltaTime;
		}
		
		if(Input.GetButtonUp ("Fire1") && chargeDelayTime > 0)
		{
			chargeDelayTime = chargeReset;
		}
		
		if(chargeDelayTime <=0)
			Charged = true;

		//No Element
		if(!element.fire && !element.ice && !element.lightning && !element.wind)
		{	
			if(Input.GetButtonDown("Fire1") && fireEnabled && !player.attacking)
			{
				anim.SetTrigger("RangeAttack");
				anim.SetBool("isAttacking",true);

				fireEnabled = false;
				player.attacking = true;

				if(player.facingRight)
				{
					Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(bulletSpeed, 0);
				}
				else
				{
					Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,180,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(-1*bulletSpeed, 0);
				}

				Invoke ("fireTrue", RateOfFire);
			}
			//Charged Shot
			if(Input.GetButtonUp ("Fire1") && Charged)
			{
				anim.SetTrigger("RangeAttack");

				fireEnabled = false;

				if(player.facingRight)
				{
					Rigidbody2D bulletInstance = Instantiate(chargedBullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(bulletSpeed, 0);
				}
				else
				{
					Rigidbody2D bulletInstance = Instantiate(chargedBullet, transform.position, Quaternion.Euler(new Vector3(0,180,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(-1*bulletSpeed, 0);
				}

				Invoke ("fireTrue", RateOfFire);

				Charged = false;
				chargeDelayTime = chargeReset;
			}
		}
		//Fire
		if(element.fire)
		{
			if(Input.GetButtonDown("Fire1") && fireEnabled && !player.attacking)
			{
				anim.SetTrigger("RangeAttack");
				anim.SetBool("isAttacking",true);
				
				fireEnabled = false;
				player.attacking = true;
				
				if(player.facingRight)
				{
					Rigidbody2D bulletInstance = Instantiate(Fire, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(bulletSpeedFire, 0);
				}
				else
				{
					Rigidbody2D bulletInstance = Instantiate(Fire, transform.position, Quaternion.Euler(new Vector3(0,180,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(-1*bulletSpeedFire, 0);
				}
				
				Invoke ("fireTrue", RateOfFire);
			}
			//Charged (Fire)
			if(Input.GetButtonUp ("Fire1") && Charged)
			{
				anim.SetTrigger("RangeAttack");
				
				fireEnabled = false;
				
				if(player.facingRight)
				{
					Rigidbody2D bulletInstance = Instantiate(chargedFire, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(bulletSpeed, 0);
				}
				else
				{
					Rigidbody2D bulletInstance = Instantiate(chargedFire, transform.position, Quaternion.Euler(new Vector3(0,180,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(-1*bulletSpeed, 0);
				}
				
				Invoke ("fireTrue", RateOfFire);
				
				Charged = false;
				chargeDelayTime = chargeReset;
			}
		}
		//Ice
		if(element.ice)
		{
			if(Input.GetButtonDown("Fire1") && fireEnabled && !player.attacking)
			{
				anim.SetTrigger("RangeAttack");
				anim.SetBool("isAttacking",true);
				
				fireEnabled = false;
				player.attacking = true;
				
				if(player.facingRight)
				{
					Rigidbody2D bulletInstance = Instantiate(Ice, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(bulletSpeed, 0);
				}
				else
				{
					Rigidbody2D bulletInstance = Instantiate(Ice, transform.position, Quaternion.Euler(new Vector3(0,180,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(-1*bulletSpeed, 0);
				}
				
				Invoke ("fireTrue", RateOfFire);
			}
			//Charged (Ice)
			if(Input.GetButtonUp ("Fire1") && Charged)
			{
				anim.SetTrigger("RangeAttack");
				
				fireEnabled = false;
				
				if(player.facingRight)
				{
					Rigidbody2D bulletInstance = Instantiate(chargedIce, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(bulletSpeed, 0);
				}
				else
				{
					Rigidbody2D bulletInstance = Instantiate(chargedIce, transform.position, Quaternion.Euler(new Vector3(0,180,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(-1*bulletSpeed, 0);
				}
				
				Invoke ("fireTrue", RateOfFire);
				
				Charged = false;
				chargeDelayTime = chargeReset;
			}
		}
		//Lightning
		if(element.lightning)
		{
			if(Input.GetButtonDown("Fire1") && fireEnabled && !player.attacking)
			{
				anim.SetTrigger("RangeAttack");
				anim.SetBool("isAttacking",true);
				
				fireEnabled = false;
				player.attacking = true;
				
				if(player.facingRight)
				{
					Rigidbody2D bulletInstance = Instantiate(Lightning, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(bulletSpeed, 0);
				}
				else
				{
					Rigidbody2D bulletInstance = Instantiate(Lightning, transform.position, Quaternion.Euler(new Vector3(0,180,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(-1*bulletSpeed, 0);
				}
				
				Invoke ("fireTrue", RateOfFire);
			}
			//Charged (Lightning)
			if(Input.GetButtonUp ("Fire1") && Charged)
			{
				anim.SetTrigger("RangeAttack");
				
				fireEnabled = false;
				
				if(player.facingRight)
				{
					Rigidbody2D bulletInstance = Instantiate(chargedLightning, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(bulletSpeed, 0);
				}
				else
				{
					Rigidbody2D bulletInstance = Instantiate(chargedLightning, transform.position, Quaternion.Euler(new Vector3(0,180,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(-1*bulletSpeed, 0);
				}
				
				Invoke ("fireTrue", RateOfFire);
				
				Charged = false;
				chargeDelayTime = chargeReset;
			}
		}
		//Wind
		if(element.wind)
		{
			if(Input.GetButtonDown("Fire1") && fireEnabled && !player.attacking)
			{
				anim.SetTrigger("RangeAttack");
				anim.SetBool("isAttacking",true);
				
				fireEnabled = false;
				player.attacking = true;
				
				if(player.facingRight)
				{
					Rigidbody2D bulletInstance = Instantiate(Wind, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(bulletSpeed, 0);
				}
				else
				{
					Rigidbody2D bulletInstance = Instantiate(Wind, transform.position, Quaternion.Euler(new Vector3(0,180,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(-1*bulletSpeed, 0);
				}
				
				Invoke ("fireTrue", RateOfFire);
			}
			//Charged (Wind)
			if(Input.GetButtonUp ("Fire1") && Charged)
			{
				anim.SetTrigger("RangeAttack");
				
				fireEnabled = false;
				
				if(player.facingRight)
				{
					Rigidbody2D bulletInstance = Instantiate(chargedWind, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(bulletSpeed, 0);
				}
				else
				{
					Rigidbody2D bulletInstance = Instantiate(chargedWind, transform.position, Quaternion.Euler(new Vector3(0,180,0))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2(-1*bulletSpeed, 0);
				}
				
				Invoke ("fireTrue", RateOfFire);
				
				Charged = false;
				chargeDelayTime = chargeReset;
			}
		}
	}

	void fireTrue ()
	{
		fireEnabled = true;
		player.attacking = false;
		anim.SetBool("isAttacking", false);
	}

}
