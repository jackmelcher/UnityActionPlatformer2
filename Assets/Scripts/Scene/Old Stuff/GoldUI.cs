using UnityEngine;
using System.Collections;

public class GoldUI : MonoBehaviour {
	
	public int goldUI = 0;
	
	void Update () {
		GetComponent<GUIText>().text = "Gold: " + goldUI;
	}
}
