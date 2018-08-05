using UnityEngine;
using System.Collections;

public class DownSpecial : MonoBehaviour {

	public Rigidbody2D bullet;
	public float bulletSpeed = 30f;
	
	public float currentTime = 0f;
	public bool timer = false;

	private SpecialSystem special;
	
	Animator anim;
	
	// Use this for initialization
	void Start () {
		special = transform.root.GetComponent<SpecialSystem>();
		
		anim = transform.root.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Down Special
		if(special.downActive)
		{	
			special.downActive = false;
			
			anim.SetBool("isAttacking",true);
			anim.SetTrigger("SpecialAttack");
			
			Invoke("downSpecial",special.specialDelay);
		}

		if(timer)
		{
			currentTime = currentTime + Time.deltaTime;
		}
		if(currentTime >= special.downSpecialDuration)
		{
			currentTime = 0f;
			timer = false;
			anim.SetBool("isAttacking", false);
			//End special move
			special.end = true;
		}
	}
	
	void downSpecial()
	{
		timer = true;

		anim.SetTrigger("DownSpecial");

		Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
		bulletInstance.velocity = new Vector2(0, -1*bulletSpeed);
	}
}
