using UnityEngine;
using System.Collections;

public class ElementUI : MonoBehaviour {

	private ElementSystem element;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		element = GameObject.Find("Player Character").GetComponent<ElementSystem>();
	}
	
	// Update is called once per frame
	void Update () {

		if(element.fire)
		{
			anim.SetTrigger("Fire");
		}
		if(element.ice)
		{
			anim.SetTrigger("Ice");
		}
		if(element.lightning)
		{
			anim.SetTrigger("Lightning");
		}
		if(element.wind)
		{
			anim.SetTrigger("Wind");
		}
		if(!element.fire && !element.ice && !element.lightning && !element.wind)
		{
			anim.SetTrigger("No Element");
		}
		
	}
}
