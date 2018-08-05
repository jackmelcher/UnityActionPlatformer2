using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour
{
	public int health = 100;

	private EnemyDeathCount score;

	void Start()
	{
		score = GameObject.Find("Score").GetComponent<EnemyDeathCount>();
	}

	void Update ()
	{		
		if(health <= 0)
		{
			score.counter = score.counter + 9000;
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D (Collider2D Damage)
	{
		if(Damage.gameObject.tag == "PlayerProjectile")
			health = health - 1;
		
		if(Damage.gameObject.tag == "ChargedPlayerProjectile")
			health = health - 10;
		
		if(Damage.gameObject.tag == "PlayerMelee")
			health = health - 2;
	}
}

