using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	[HideInInspector]
	public bool facingRight = true;
	public float delayTime = 2.0f;
	public float speedX = 3f;
	public float speedY = 3f;
	public float rate = 2f;
	public float count = 0f;

	public bool bounce = false;
	public bool slide = false;

	private Rigidbody2D rigid;
	private Transform player;
	private EnemyFireBullet detection;

	void Start(){
		rigid = GetComponent<Rigidbody2D> ();
		player = GameObject.Find("Player Character").GetComponent<Transform>();
		detection = GetComponentInChildren<EnemyFireBullet>();
	}

	void Update ()
	{
		if (transform.position.x > player.transform.position.x && facingRight) {
			Flip ();
		}
		if (transform.position.x < player.transform.position.x && !facingRight) {
			Flip ();
		}
		if (bounce && detection.enable) {
			count += Time.deltaTime;
			if (count >= rate) {
				if (transform.position.x > player.transform.position.x) {
					rigid.velocity = new Vector2 (speedX, -1 * speedY);
				}
				if (transform.position.x < player.transform.position.x) {
					rigid.velocity = new Vector2 (speedX, speedY);
				}
				count = 0;
			}
		}
		else{count = 0;}

		
	}

	void Flip (){
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D (Collider2D flip){
		if(flip.gameObject.name == "EnemyCollisionBlock")
		{
			Flip ();
		}
	}
	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "Floor") {
			if (!slide) {
				rigid.velocity = new Vector2 (0f, 0f);
			}
		}
	}
}
