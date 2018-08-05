using UnityEngine;
using System.Collections;

public class PlayerFXScript : MonoBehaviour {

	FireBullet script;

	Animator anim;

	void Awake () {
		anim = GetComponent<Animator>();
	}

	void Start(){
		script = GameObject.Find("Weapon Spawn").GetComponent<FireBullet>();
	}

	void Update () {
		if(script.Charged)
			anim.SetBool("Charged",true);
		else
			anim.SetBool("Charged",false);
	}
}
