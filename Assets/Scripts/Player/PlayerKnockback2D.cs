using UnityEngine;
using System.Collections;

public class PlayerKnockback2D : MonoBehaviour {

	public float knockbackSpeed = 10f;
	public float knockupSpeed = 10f;

	public int enemyProjectileDamage = 1;
	public int enemyDamage = 2;

	private CharacterController2D playerControl;
	private PlayerHealthManager playerHealth;
	private Rigidbody2D playerBody;

	//Wall Jump ability
	public bool abletowalljump = false;
	public bool walljumpunlocked = true;
	public float walljumpduration = 0.2f;
	public float hspeed = 10f;
	public float vspeed = 20f;

	void Awake()
	{
		playerControl = transform.root.GetComponent<CharacterController2D>();
		playerHealth = transform.root.GetComponent<PlayerHealthManager>();
		playerBody = transform.root.GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		//walljump
		if(Input.GetButtonDown ("Jump") && Input.GetButton ("Horizontal") && abletowalljump && walljumpunlocked && !playerControl.abletojump)
		{
			if(playerControl.facingRight)
			{
				playerBody.GetComponent<Rigidbody2D>().velocity = new Vector2(-1*hspeed,vspeed);
				playerControl.enabled = false;
				Invoke("reenable",walljumpduration);
			}
			else if(!playerControl.facingRight)
			{
				playerBody.GetComponent<Rigidbody2D>().velocity = new Vector2(hspeed,vspeed);
				playerControl.enabled = false;
				Invoke("reenable",walljumpduration);
			}
		}
	}

	//Knockback and Damage
	void OnTriggerEnter2D (Collider2D damage)
	{
		if(!playerHealth.invincible && !playerHealth.hit && playerControl.facingRight)
		{
			if(damage.gameObject.tag == "EnemyProjectile")
			{
				playerHealth.hit = true;
				playerBody.GetComponent<Rigidbody2D>().velocity = new Vector2 (knockbackSpeed,knockupSpeed);
				playerHealth.health = playerHealth.health - enemyProjectileDamage;
			}

			if(damage.gameObject.tag == "Enemy")
			{
				playerHealth.hit = true;
				playerBody.GetComponent<Rigidbody2D>().velocity = new Vector2 (knockbackSpeed,knockupSpeed);
				playerHealth.health = playerHealth.health - enemyDamage;
			}
		}

		if(!playerHealth.invincible && !playerHealth.hit && !playerControl.facingRight)
		{
			if(damage.gameObject.tag == "EnemyProjectile")
			{
				playerHealth.hit = true;
				playerBody.GetComponent<Rigidbody2D>().velocity = new Vector2 (-1*knockbackSpeed,knockupSpeed);
				playerHealth.health = playerHealth.health - enemyProjectileDamage;
			}
			
			if(damage.gameObject.tag == "Enemy")
			{
				playerHealth.hit = true;
				playerBody.GetComponent<Rigidbody2D>().velocity = new Vector2 (-1*knockbackSpeed,knockupSpeed);
				playerHealth.health = playerHealth.health - enemyDamage;
			}
		}
	}
	//Enable Wall Jump
	void OnTriggerStay2D (Collider2D walljumpenable)
	{
		if (walljumpenable.gameObject.tag == "Wall")
		{
			abletowalljump = true;
		}
	}
	//Enable Wall Jump
	void OnTriggerExit2D (Collider2D walljumpdisable)
	{
		if (walljumpdisable.gameObject.tag == "Wall")
		{
			abletowalljump = false;
		}
	}
	void reenable()
	{
		playerControl.enabled = true;
	}

}
