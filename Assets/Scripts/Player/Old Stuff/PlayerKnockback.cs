using UnityEngine;
using System.Collections;

public class PlayerKnockback : MonoBehaviour {

	public Transform lineStart1, lineEnd1;
	public Transform lineStart2, lineEnd2;

	public float knockbackSpeed = 10f;
	public float knockupSpeed = 10f;

	public int health = 10;
	public int maxHealth = 10;

	public float invincibilityTime = 2.0f;

	public bool invincible = false;

	private BoxCollider2D playerCollision1;
	private CircleCollider2D playerCollision2;

	private CharacterController2D player;
	private SpriteRenderer image;

	private PixelPerfect maincamera;

	RaycastHit2D hit1;
	RaycastHit2D hit2;

	void Awake()
	{
		player = transform.root.GetComponent<CharacterController2D>();
		image = GetComponent<SpriteRenderer> ();
		playerCollision1 = GetComponent<BoxCollider2D>();
		playerCollision2 = GetComponent<CircleCollider2D>();

		maincamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PixelPerfect>();
	}

	void Update ()
	{
		if(health > maxHealth)
			health = maxHealth;
		
		if(health <= 0)
		{
			health = 0;
			playerCollision1.isTrigger = true;
			playerCollision2.isTrigger = true;
			image.enabled = false;
			maincamera.enabled = false;
		}

		Debug.DrawLine (lineStart1.position, lineEnd1.position, Color.green);

		if(!invincible)
		{
			if(Physics2D.Linecast(lineStart1.position, lineEnd1.position) && player.facingRight)
			{
				hit1 = Physics2D.Linecast(lineStart1.position, lineEnd1.position);
				if(hit1.collider.gameObject.tag == "Enemy")
				{
					invincible = true;
					health = health - 2;
					GetComponent<Rigidbody2D>().velocity = new Vector2 (-1*knockbackSpeed,knockupSpeed);
					player.enabled = false;
					Invoke ("enable",0.5f);
					Invoke ("disable",3f);
				}
			}
			
			if(Physics2D.Linecast(lineStart1.position, lineEnd1.position) && !player.facingRight)
			{
				hit1 = Physics2D.Linecast(lineStart1.position, lineEnd1.position);
				if(hit1.collider.gameObject.tag == "Enemy")
				{
					invincible = true;
					health = health - 2;
					GetComponent<Rigidbody2D>().velocity = new Vector2 (knockbackSpeed,knockupSpeed);
					player.enabled = false;
					Invoke ("enable",0.5f);
					Invoke ("disable",3f);
				}
			}
			
			Debug.DrawLine (lineStart2.position, lineEnd2.position, Color.green);
			
			if(Physics2D.Linecast(lineStart2.position, lineEnd2.position) && player.facingRight)
			{
				hit2 = Physics2D.Linecast(lineStart2.position, lineEnd2.position);
				if(hit2.collider.gameObject.tag == "Enemy")
				{
					invincible = true;
					health = health - 2;
					GetComponent<Rigidbody2D>().velocity = new Vector2 (knockbackSpeed,knockupSpeed);
					player.enabled = false;
					Invoke ("enable",0.5f);
					Invoke ("disable",3f);
				}
			}
			
			if(Physics2D.Linecast(lineStart2.position, lineEnd2.position) && !player.facingRight)
			{
				hit2 = Physics2D.Linecast(lineStart2.position, lineEnd2.position);
				if(hit2.collider.gameObject.tag == "Enemy")
				{
					invincible = true;
					health = health - 2;
					GetComponent<Rigidbody2D>().velocity = new Vector2 (-1*knockbackSpeed,knockupSpeed);
					player.enabled = false;
					Invoke ("enable",0.5f);
					Invoke ("disable",3f);
				}
			}
		}
	}
	void OnTriggerEnter2D (Collider2D damage)
	{
		if(!invincible)
		{
			if(damage.gameObject.tag == "EnemyProjectile")
			{
				invincible = true;
				health = health - 1;
				Invoke ("disable",invincibilityTime);
			}
		}
	}


	void enable()
	{
		player.enabled = true;
	}

	void disable()
	{
		invincible = false;
	}
}