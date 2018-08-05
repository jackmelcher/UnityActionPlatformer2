using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour 
{
	public float bulletLifetime = 1f;
	public bool enemyPierce = false;
	public bool wallPierce = false;

	void Start()
	{
		Invoke ("destroy", bulletLifetime);
	}

	void OnTriggerEnter2D (Collider2D destroyBullet)
	{
		if((destroyBullet.gameObject.tag == "Floor" || destroyBullet.gameObject.tag == "Slant"|| destroyBullet.gameObject.tag == "Wall") && !wallPierce)
			Destroy (gameObject);

		if(destroyBullet.gameObject.tag == "Enemy" && !enemyPierce)
			Destroy (gameObject);
	}

	void destroy ()
	{
		Destroy (gameObject);
	}
}
