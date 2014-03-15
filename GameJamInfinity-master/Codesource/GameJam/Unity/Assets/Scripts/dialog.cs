using UnityEngine;
using System.Collections;

public class dialog : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public string choixDialog(int textdialog)
	{	
		
		
		switch(textdialog)
		{
			case 1: return "Le premier dialogue";
				break;
				
			case 2: return "Le deuxieme dialogue";
				break;
			
			default: return "dialogue vide";
			
			
		}
		
	}
		
}

