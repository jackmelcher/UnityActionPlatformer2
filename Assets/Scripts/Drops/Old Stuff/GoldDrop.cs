using UnityEngine;
using System.Collections;

public class GoldDrop : MonoBehaviour {

	public int goldValue;
	public int goldValueMin = 1;
	public int goldValueMax = 5;

	private GoldUI addGold;

	void Start () {
		addGold = GameObject.Find("Gold UI").GetComponent<GoldUI>();
		goldValue = Random.Range (goldValueMin, goldValueMax);
	}

	void OnTriggerEnter2D(Collider2D giveGold)
	{
		if(giveGold.gameObject.tag == "Player")
		{
			addGold.goldUI = addGold.goldUI + goldValue;
			Destroy(gameObject);
		}
	}

}
