using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpecialBar : MonoBehaviour {

	Image myImage;

	private SpecialSystem special;
	
	void Awake ()
	{
		myImage = GetComponent<Image>();
		myImage.fillAmount = 0f;
	}

	void Start()
	{
		special = GameObject.Find("Player Character").GetComponent<SpecialSystem>();
	}

	void Update ()
	{
		myImage.fillAmount = special.currentTime / special.chargeTime ;
	}
}
