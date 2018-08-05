using UnityEngine;
using System.Collections;

public class EnemyFireBullet : MonoBehaviour {

	public Rigidbody2D enemyBullet;
	public float bulletSpeed = 30f;
	public float bulletHeight = 0f;
	public float fireRate = 2f;
	public float count = 0f;
	public float gravityScale = 0f;
	public bool enable = false;
	public bool fireEnable = false;

	private EnemyController enemy;

	void Awake()
	{
		enemy = transform.root.GetComponent<EnemyController>();
	}

	void Update () 
	{
		if(enable && fireEnable){
			count += Time.deltaTime;
			if (count >= fireRate) {
				Invoke ("Fire", 0f);
				count = 0;
			}
		}
		else{count = 0;}
	}

	void Fire ()
	{
		if(enemy.facingRight)
		{
			Rigidbody2D bulletInstance = Instantiate(enemyBullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(bulletSpeed, bulletHeight);
			bulletInstance.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
		}
		else
		{
			Rigidbody2D bulletInstance = Instantiate(enemyBullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(-1*bulletSpeed, bulletHeight);
			bulletInstance.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
		}
	}
	void OnTriggerEnter2D (Collider2D fire){
		if(fire.gameObject.tag == "Player"){
			enable = true;
		}
	}
	void OnTriggerStay2D (Collider2D fire){
		if(fire.gameObject.tag == "Player"){
			enable = true;
		}
	}
	void OnTriggerExit2D (Collider2D fire){
		if(fire.gameObject.tag == "Player"){
			enable = false;
		}
	}
}
