using UnityEngine;
using System.Collections;

public class EnemyHealthver2 : MonoBehaviour {

	//Base health
	public int health = 10;

	//regenerate or revert
	public bool regenenable = false;
	public int regenerate = 10;
	public float regendelay = 0.1f;
	public float counter = 0f;

	//Damage values
	public int shotDamage = 1;
	public int shotChargeDamage = 6;

	public int meleeDamage = 3;
	public int meleeChargeDamage = 10;

	public int neutralSpecialDamage = 2;
	public int upSpecialDamage = 50;
	public int downSpecialDamage = 20;
	public int sideSpecialDamage = 60;
	
	public int FireMultiplier = 1;
	public int IceMultiplier = 1;
	public int LightningMultiplier = 1;
	public int WindMultiplier = 1;

	//Heart drop
	public Rigidbody2D heart;
	[HideInInspector]
	public float chanceRandomHeart;
	public float dropRate = 25f;

	private ElementSystem element;

	void Start()
	{
		element = GameObject.Find("Player Character").GetComponent<ElementSystem>();
	}

	void Update ()
	{		
		if(health <= 0)
		{
			chanceRandomHeart = Random.Range (1f, 100f);
			//spawn hearts
			if(chanceRandomHeart <= dropRate)
			{
				Rigidbody2D heartInstance = Instantiate(heart, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				heartInstance.velocity = new Vector2(Random.Range (-2f, 2f), 3);
			}
			Destroy(gameObject);
		}
		if(regenenable)
		{
			if(health < regenerate)
				counter += Time.deltaTime;
			if (counter >= regendelay)
			{
				health = regenerate;
				counter = 0f;
			}
		}
	}
	void OnTriggerEnter2D (Collider2D Damage)
	{
		//Range Damage
		if(Damage.gameObject.tag == "PlayerProjectile")
		{
			if(!element.fire && !element.ice && !element.lightning && !element.wind)
				health = health - shotDamage;
			if(element.fire)
				health = health - shotDamage*FireMultiplier;
			if(element.ice)
				health = health - shotDamage*IceMultiplier;
			if(element.lightning)
				health = health - shotDamage*LightningMultiplier;
			if(element.wind)
				health = health - shotDamage*WindMultiplier;
		}
		if(Damage.gameObject.tag == "ChargedPlayerProjectile")
		{
			if(!element.fire && !element.ice && !element.lightning && !element.wind)
				health = health - shotChargeDamage;
			if(element.fire)
				health = health - shotChargeDamage*FireMultiplier;
			if(element.ice)
				health = health - shotChargeDamage*IceMultiplier;
			if(element.lightning)
				health = health - shotChargeDamage*LightningMultiplier;
			if(element.wind)
				health = health - shotChargeDamage*WindMultiplier;
		}
		//Melee Damage
		if(Damage.gameObject.tag == "PlayerMelee")
		{
			if(!element.fire && !element.ice && !element.lightning && !element.wind)
				health = health - meleeDamage;
			if(element.fire)
				health = health - meleeDamage*FireMultiplier;
			if(element.ice)
				health = health - meleeDamage*IceMultiplier;
			if(element.lightning)
				health = health - meleeDamage*LightningMultiplier;
			if(element.wind)
				health = health - meleeDamage*WindMultiplier;
		}
		if(Damage.gameObject.tag == "PlayerChargeMelee")
		{
			if(!element.fire && !element.ice && !element.lightning && !element.wind)
				health = health - meleeChargeDamage;
			if(element.fire)
				health = health - meleeChargeDamage*FireMultiplier;
			if(element.ice)
				health = health - meleeChargeDamage*IceMultiplier;
			if(element.lightning)
				health = health - meleeChargeDamage*LightningMultiplier;
			if(element.wind)
				health = health - meleeChargeDamage*WindMultiplier;
		}
		//Special Damage
		if(Damage.gameObject.tag == "NeutralSpecial")
		{
			if(!element.fire && !element.ice && !element.lightning && !element.wind)
				health = health - neutralSpecialDamage;
			if(element.fire)
				health = health - neutralSpecialDamage*FireMultiplier;
			if(element.ice)
				health = health - neutralSpecialDamage*IceMultiplier;
			if(element.lightning)
				health = health - neutralSpecialDamage*LightningMultiplier;
			if(element.wind)
				health = health - neutralSpecialDamage*WindMultiplier;
		}
		if(Damage.gameObject.tag == "UpSpecial")
		{
			if(!element.fire && !element.ice && !element.lightning && !element.wind)
				health = health - upSpecialDamage;
			if(element.fire)
				health = health - upSpecialDamage*FireMultiplier;
			if(element.ice)
				health = health - upSpecialDamage*IceMultiplier;
			if(element.lightning)
				health = health - upSpecialDamage*LightningMultiplier;
			if(element.wind)
				health = health - upSpecialDamage*WindMultiplier;
		}
		if(Damage.gameObject.tag == "DownSpecial")
		{
			if(!element.fire && !element.ice && !element.lightning && !element.wind)
				health = health - downSpecialDamage;
			if(element.fire)
				health = health - downSpecialDamage*FireMultiplier;
			if(element.ice)
				health = health - downSpecialDamage*IceMultiplier;
			if(element.lightning)
				health = health - downSpecialDamage*LightningMultiplier;
			if(element.wind)
				health = health - downSpecialDamage*WindMultiplier;
		}
		if(Damage.gameObject.tag == "SideSpecial")
		{
			if(!element.fire && !element.ice && !element.lightning && !element.wind)
				health = health - sideSpecialDamage;
			if(element.fire)
				health = health - sideSpecialDamage*FireMultiplier;
			if(element.ice)
				health = health - sideSpecialDamage*IceMultiplier;
			if(element.lightning)
				health = health - sideSpecialDamage*LightningMultiplier;
			if(element.wind)
				health = health - sideSpecialDamage*WindMultiplier;
		}
	}
}
