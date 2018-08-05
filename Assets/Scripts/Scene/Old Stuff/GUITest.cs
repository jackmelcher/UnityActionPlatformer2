using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
	
	void OnGUI ()
	{

			GUI.Box (new Rect (10,10,100,270), "GUI Test");
			
			if(GUI.Button (new Rect(20,40,80,20),"Test 1"))
			{
				Application.LoadLevel("Test1");
			}
			
			if(GUI.Button (new Rect(20,70,80,20),"Test 2"))
			{
				Application.LoadLevel("Test2");
				
			}

			if(GUI.Button (new Rect(20,100,80,20),"Test 3"))
			{
				Application.LoadLevel("Test3");
				
			}
			
			if(GUI.Button (new Rect(20,130,80,20),"Quit"))
			{
				Application.Quit();
				
			}	

	}
}
