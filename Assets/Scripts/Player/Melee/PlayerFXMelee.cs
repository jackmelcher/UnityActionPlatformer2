using UnityEngine;
using System.Collections;

public class PlayerFXMelee : MonoBehaviour {
	
	PlayerChargeMelee script;
	
	Animator anim;
	
	void Awake () {
		anim = GetComponent<Animator>();
	}
	
	void Start(){
		script = GameObject.Find("Charge Melee Hitbox").GetComponent<PlayerChargeMelee>();
	}
	
	void Update () {
		if(script.Charged)
			anim.SetBool("Charged",true);
		else
			anim.SetBool("Charged",false);
	}
}
