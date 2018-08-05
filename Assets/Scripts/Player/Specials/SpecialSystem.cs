using UnityEngine;
using System.Collections;

public class SpecialSystem : MonoBehaviour {

	public float currentTime = 0f;
	public float chargeTime = 10f;

	public float specialDelay = 1f;

	public float upSpecialDuration = 1f;
	public float sideSpecialDuration = 1f;
	public float downSpecialDuration = 1f;
	public float neutralSpecialDuration = 20f;

	public bool specialEnable = false;
	public bool specialInvincible = false;
	public bool timer = true;
	public bool end;

	public bool upActive = false;
	public bool sideActive = false;
	public bool downActive = false;
	public bool neutralActive = false;

	public bool specialunlock = false;

	private CharacterController2D playerControl;
	private PlayerHealthManager playerHealth;
	private FireBullet shoot;
	private AttackScript attack;
	private PlayerChargeMelee chargeAttack;
	private ElementSystem element;

	// Use this for initialization
	void Start () {
		playerControl = transform.root.GetComponent<CharacterController2D>();
		playerHealth = transform.root.GetComponent<PlayerHealthManager>();
		shoot = transform.GetComponentInChildren<FireBullet>();
		attack = transform.GetComponentInChildren<AttackScript>();
		chargeAttack = transform.GetComponentInChildren<PlayerChargeMelee>();
		element = transform.root.GetComponent<ElementSystem>();
	}	

	// Update is called once per frame
	void Update () {

		//Increment Timer
		if(currentTime < chargeTime && timer && specialunlock)
			currentTime += Time.deltaTime;
		//When Timer is Max
		if(currentTime >= chargeTime && timer)
		{
			currentTime = chargeTime;
			specialEnable = true;
			timer = false;
		}
		//Special Activated
		if(Input.GetButtonDown("Fire3") && specialEnable)
		{	
			specialInvincible = true;
			
			transform.root.GetComponent<Rigidbody2D>().gravityScale = 0;
			transform.root.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		}
		//Up Special
		if(Input.GetButtonDown("Fire3") && specialEnable && Input.GetKey(KeyCode.W))
		{
			specialEnable = false;

			//Set element to Fire
			element.fire = true;
			element.ice = false;
			element.lightning = false;
			element.wind = false;

			upActive = true;
		}
		//Side Special
		else if(Input.GetButtonDown("Fire3") && specialEnable && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
		{
			specialEnable = false;

			//Set element to Wind
			element.fire = false;
			element.ice = false;
			element.lightning = false;
			element.wind = true;

			sideActive = true;
		}
		//Down Special
		else if(Input.GetButtonDown("Fire3") && specialEnable && Input.GetKey(KeyCode.S))
		{
			specialEnable = false;

			//Set element to Lightning
			element.fire = false;
			element.ice = false;
			element.lightning = true;
			element.wind = false;

			downActive = true;
		}
		//Neutral Special
		else if(Input.GetButtonDown("Fire3") && specialEnable)
		{	
			specialEnable = false;

			//Set element to Ice
			element.fire = false;
			element.ice = true;
			element.lightning = false;
			element.wind = false;

			neutralActive = true;
		}
		//Provide player invincibility for duration of special
		if(specialInvincible)
		{
			playerControl.enabled = false;
			shoot.enabled = false;
			attack.enabled = false;
			chargeAttack.enabled = false;

			playerHealth.invincible = true;
		}
		//exit the special state and reset timer
		if(end)
		{
			currentTime = 0;
			timer = true;
			//reset gravity
			transform.root.GetComponent<Rigidbody2D>().gravityScale = 4;
			transform.root.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);

			playerControl.enabled = true;
			shoot.enabled = true;
			attack.enabled = true;
			chargeAttack.enabled = true;
			
			specialInvincible = false;
			playerHealth.invincible = false;

			end = false;
		}
	}
}
