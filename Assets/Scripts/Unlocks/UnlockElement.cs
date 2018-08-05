using UnityEngine;
using System.Collections;

public class UnlockElement : MonoBehaviour {

	private ElementSystem element;

	public bool fire = false;
	public bool ice = false;
	public bool lightning = false;
	public bool wind = false;

	// Use this for initialization
	void Start () {
		element = GameObject.Find("Player Character").GetComponentInChildren<ElementSystem>();
	}
	
	void OnTriggerEnter2D (Collider2D unlock)
	{
		if(unlock.gameObject.tag == "Player")
		{
			if(fire)
				element.fireunlock = true;
			if(ice)
				element.iceunlock = true;
			if(lightning)
				element.lightningunlock = true;
			if(wind)
				element.windunlock = true;
			Destroy (gameObject);
		}
	}
}
