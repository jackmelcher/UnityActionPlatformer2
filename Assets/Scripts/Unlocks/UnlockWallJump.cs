using UnityEngine;
using System.Collections;

public class UnlockWallJump : MonoBehaviour {

	private PlayerKnockback2D walljump;
	
	// Use this for initialization
	void Start()
	{
		walljump = GameObject.Find("CollisionBoxRight").GetComponentInChildren<PlayerKnockback2D>();
	}
	
	void OnTriggerEnter2D (Collider2D unlock)
	{
		if(unlock.gameObject.tag == "Player")
		{	
			walljump.walljumpunlocked = true;
			Destroy (gameObject);
		}
	}
}
