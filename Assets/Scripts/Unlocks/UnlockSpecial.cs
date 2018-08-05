using UnityEngine;
using System.Collections;

public class UnlockSpecial : MonoBehaviour {

	private SpecialSystem special;

	// Use this for initialization
	void Start () {
		special = GameObject.Find("Player Character").GetComponentInChildren<SpecialSystem>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D unlock)
	{
		if(unlock.gameObject.tag == "Player")
		{
			special.specialunlock = true;
			Destroy (gameObject);
		}
	}
}
