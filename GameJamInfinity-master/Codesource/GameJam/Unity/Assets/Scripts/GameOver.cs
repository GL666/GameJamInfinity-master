using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		if(GUI.Button( new Rect(Screen.width/2 - Screen.width/4,Screen.height/2 + Screen.height/4,100, 50), "Yes"))
		{
			print ("holy dicks!");
			Application.LoadLevel("menu");
		}
		if(GUI.Button ( new Rect(Screen.width/2 + Screen.width/5,Screen.height/2 + Screen.height/4,100, 50), "No"))
		{
			print ("Jesus with tits");
			Application.Quit();
		}
	}
}
