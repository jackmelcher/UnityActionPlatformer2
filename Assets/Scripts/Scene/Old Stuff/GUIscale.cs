using UnityEngine;
using System.Collections;

public class GUIAspectRatioScale : MonoBehaviour 
{
	public Vector2 scaleOnRatio1 = new Vector2(0f, 0f);
	private Transform guiTransform;
	private float widthHeightRatio;
	
	void Start () 
	{
		guiTransform = GetComponent<Transform>();
		SetScale();
	}
	//call on an event that tells if the aspect ratio changed
	void SetScale()
	{
		//find the aspect ratio
		widthHeightRatio = (float)Screen.width/Screen.height;
		
		//Apply the scale. We only calculate y since our aspect ratio is x (width) authoritative: width/height (x/y)
		guiTransform.localScale = new Vector3 (scaleOnRatio1.x, widthHeightRatio * scaleOnRatio1.y, 1);
	}
}