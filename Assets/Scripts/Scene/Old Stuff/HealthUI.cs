using UnityEngine;
using System.Collections;

public class HealthUI : MonoBehaviour {

	private PlayerHealthManager playerHealth;

	public float healthUI = 0;
	
	void Start () {
		playerHealth = GameObject.Find("Player Character").GetComponent<PlayerHealthManager>();
	}

	void Update () {
		healthUI = playerHealth.health;
		GetComponent<GUIText>().text = "Health: " + healthUI;
	}
}
