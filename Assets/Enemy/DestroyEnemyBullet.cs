using UnityEngine;
using System.Collections;

public class DestroyEnemyBullet : MonoBehaviour {

	public float bulletLifetime = 1f;

	void Start()
	{
		Invoke ("destroy", bulletLifetime);
	}

	void OnTriggerEnter2D (Collider2D destroyBullet)
	{
		if(destroyBullet.gameObject.tag == "Floor" || destroyBullet.gameObject.tag == "Slant" || destroyBullet.gameObject.tag == "Wall")
			Invoke ("destroy", 0.001f);
		
		if(destroyBullet.gameObject.tag == "Player")
			Invoke ("destroy", 0.001f);
	}

	void destroy ()
	{
		Destroy (gameObject);
	}
}
