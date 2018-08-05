using UnityEngine;
using System.Collections;

public class UnlockWeapons : MonoBehaviour {
	
	private FireBullet range;
	private AttackScript melee;
	private PlayerChargeMelee cmelee;

	// Use this for initialization
	void Start()
	{
		range = GameObject.Find("Player Character").GetComponentInChildren<FireBullet>();
		melee = GameObject.Find("Player Character").GetComponentInChildren<AttackScript>();
		cmelee = GameObject.Find("Player Character").GetComponentInChildren<PlayerChargeMelee>();
	}
	
	void OnTriggerEnter2D (Collider2D unlock)
	{
		if(unlock.gameObject.tag == "Player")
		{	
			range.enabled = true;
			melee.enabled = true;
			cmelee.enabled = true;
			Destroy (gameObject);
		}
	}
}
