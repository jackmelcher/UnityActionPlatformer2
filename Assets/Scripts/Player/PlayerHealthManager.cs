using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {
	
	public float health = 5f;
	public float maxHealth = 5f;
	
	public bool invincible = false;
	public bool hit = false;
	public float invincibilityTime = 2f;
	
	private CharacterController2D playerControl;
	private SpriteRenderer playerImage;
	
	private PixelPerfect mainCamera;

	void Awake()
	{
		playerControl = transform.root.GetComponent<CharacterController2D>();
		playerImage = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
	{
		if(health > maxHealth)
			health = maxHealth;
		
		if(health <= 0)
		{
			health = 0;
			playerImage.enabled = false;
			playerControl.enabled = false;
		}
		

		if(hit)
		{					
			playerControl.enabled = false;
			Invoke ("enable",0.5f);
			invincible = true;
		}
	}
	
	void enable ()
	{
		playerControl.enabled = true;
		hit = false;
		playerImage.color = new Color (1f, 1f, 1f, 0.5f);
		Invoke ("InvincibiltyEnd",invincibilityTime);
	}
	
	void InvincibiltyEnd ()
	{
		playerImage.color = new Color (1f, 1f, 1f, 1f);
		invincible = false;
	}
}