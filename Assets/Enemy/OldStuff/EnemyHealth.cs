using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health = 10;
	public int shotDamage = 1;
	public int shotChargeDamage = 6;
	public int meleeDamage = 3;
	public int meleeChargeDamage = 10;
	
	public Rigidbody2D heart;
	public Rigidbody2D gold;
	[HideInInspector]
	public float chanceRandomHeart;
	public float chanceValueHeart = 25f;

	void Update ()
	{		
		if(health <= 0)
		{
			chanceRandomHeart = Random.Range (1f, 100f);
			//spawn hearts
			if(chanceRandomHeart <= chanceValueHeart)
			{
				Rigidbody2D heartInstance = Instantiate(heart, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				heartInstance.velocity = new Vector2(Random.Range (-2f, -1f), 3);
			}
			/*spawn gold
			Rigidbody2D goldInstance = Instantiate(gold, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			goldInstance.velocity = new Vector2(Random.Range (1f, 2f), 5);

			Destroy(gameObject);
			*/
		}
	}
	
	void OnTriggerEnter2D (Collider2D Damage)
	{
		if(Damage.gameObject.tag == "PlayerProjectile")
			health = health - shotDamage;

		if(Damage.gameObject.tag == "ChargedPlayerProjectile")
			health = health - shotChargeDamage;

		if(Damage.gameObject.tag == "PlayerMelee")
			health = health - meleeDamage;

		if(Damage.gameObject.tag == "PlayerChargeMelee")
			health = health - meleeChargeDamage;
	}
}
