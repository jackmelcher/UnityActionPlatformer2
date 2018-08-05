using UnityEngine;
using System.Collections;

public class WaveSpawn : MonoBehaviour {

	public Rigidbody2D wave;
	public float waveSpeed = 10f;

	void OnTriggerEnter2D (Collider2D destroyBullet)
	{
		if(destroyBullet.gameObject.tag == "Floor" || destroyBullet.gameObject.tag == "Slant")
		{
			Rigidbody2D bulletInstance1 = Instantiate(wave, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			bulletInstance1.velocity = new Vector2(waveSpeed, 0);

			Rigidbody2D bulletInstance2 = Instantiate(wave, transform.position, Quaternion.Euler(new Vector3(0,180,0))) as Rigidbody2D;
			bulletInstance2.velocity = new Vector2(-1*waveSpeed, 0);

			Destroy (gameObject);
		}
	}
}
