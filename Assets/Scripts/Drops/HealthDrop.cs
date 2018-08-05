using UnityEngine;
using System.Collections;

public class HealthDrop : MonoBehaviour {

	public int heartValue = 1;
	public int valueHolder = 2;

	private PlayerHealthManager addHeatlh;

	void Start () {
		addHeatlh = GameObject.Find("Player Character").GetComponent<PlayerHealthManager>();
	}

	void OnTriggerEnter2D(Collider2D giveHeart)
	{
		if(giveHeart.gameObject.tag == "Player")
		{
			addHeatlh.health = addHeatlh.health + heartValue;
			Destroy(gameObject);
		}
	}

}
