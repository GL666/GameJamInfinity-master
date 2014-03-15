using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class dialogObj : MonoBehaviour {
	
	private bool userHasTab;
	private bool hasEntertext;
	private bool hasNotEnterText;
	private bool hasPressedLeftControl;
	private bool hasPassedInRandom;
	
	
	private GameObject	Player;
	
	private string textUser = "";
	private string textintextField = "";
	private string textuserInput;
	private string test = "";
	private string textFinal = "";
	private string textVoid = "";
	private int index;
	
	//private string[] tabQuotes = new string[13]{};
	private List<string> tabQuotes = new List<string>();
	
	
	private Rect talkrect = new Rect(Screen.width/2 - Screen.width/2, Screen.height/2 - Screen.height/2, 100,20);
	//private GUI.Label newGUI;
	
	
	private float timer;
	
	void Awake()
	{
		userHasTab = false;
		hasEntertext = false;
		hasNotEnterText = true;
		hasPressedLeftControl = false;
		hasPassedInRandom = false;
		timer = 0.0f;
		index = 0;
		initRandomQuote();
		
	}
	
	// Use this for initialization
	void Start () {
	
		Player=GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		
		if(hasPressedLeftControl)
		{
			
			print(textFinal);
			hasPressedLeftControl = false;
			
			if(textFinal != null)
			{
				textVoid = choixDialog(textFinal);
			
			}
		}
				
	
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width/2 - Screen.width/2, Screen.height/2 - Screen.height/3, 200,300), "Void says : " + textVoid);
		guiFunc(true);


	}
	
	void guiFunc(bool check)
	{
		switch(check)
		{
		case true:enterText();
			break;
		case false:talkVoid();
			break;
		default:
			break;
			
		}
		
	}
		
	void talkVoid()
	{
	
		//GUI.Label(new Rect(Screen.width/2- 500, Screen.height/2 - 200, 100,20), "Void say : " + textUser);	
		
		
	}
	
	void enterText()
	{

			GUI.Label(talkrect, "Talk to the void : ");
			
			textUser = GUI.TextField(new Rect(talkrect.width +5.0f, Screen.height/2 - Screen.height/2, 200,20), textUser);
	
		if(!Event.current.Equals(Event.KeyboardEvent("None")))
		{
			
			if(Event.current.keyCode == KeyCode.Delete)
			{
				textUser = "";
				test = textUser;
			}
			if(Event.current.keyCode == KeyCode.LeftControl)
			{
				textFinal = test;
				test = "";
				//print (textFinal);
				hasPressedLeftControl = true;

			}
			if(!test.Equals(textUser))
			{
				test = textUser;
				//print (test);
			}
			

		}
		

		
	 //return textUser;
		
	}
	
	private string choixDialog(string textDialog)
	{
		textDialog.ToLower();
		
		if(textDialog.Contains("shaft"))
		{
			return "Oh, you think the Shaft is your ally? but you merely adopted the Shaft. I was born in it, molded by it.";
		}
		if(textDialog.Contains("liberty"))
		{
			return "What does liberty mean, if not complete void, when it is not relative to others?";
		}
		if(textDialog.Contains("go") || textDialog.Contains("ability") 
			||textDialog.Contains("abilities") || textDialog.Contains("abilitie") 
			|| textDialog.Contains("reaching") )
		{
			return "There is no difference between the abilities needed to reach the void than those needed to reach a whole.";
		}
		if(textDialog.Contains("end") || textDialog.Contains("nature") || textDialog.Contains("distance")||
			textDialog.Contains("man") || textDialog.Contains("compare"))
		{
			return "In the end, what is a man in nature? A void when compared to infinity, a whole when compared to the void, halfway between everything and nothing.";
		}
		if(textDialog.Contains("be") || textDialog.Contains("problem") || textDialog.Contains("problems"))
		{
			return "Being or the void, there's the problem.";
		}
		if(textDialog.Contains("win") || textDialog.Contains("triumph"))
		{
			return "You have to look the void straight in the eyes to be able to triumph over it.";
		}
		if(textDialog.Contains("death") || textDialog.Contains("dead") || textDialog.Contains("life"))
		{
			return "Void after death? Isn't that the state wich we were used to before life?";
		}
		if(textDialog.Contains("religion") || textDialog.Contains("religions") || textDialog.Contains("immortality"))
		{
			return "Religion speaks of immortality but this is a notion that implies voidness.";
		}
		if(textDialog.Contains("human") || textDialog.Contains("life") || textDialog.Contains("absolute") || textDialog.Contains("avoid"))
		{
			return "The drama of a human life is less in the absolute of it's void then in it's stubborn trials to avoid it.";
		}
		if(textDialog.Contains("limit") || textDialog.Contains("limits") || textDialog.Contains("center"))
		{
			return "Voidness doesn't have a center, and it's limits are voidness.";
		}
		if(textDialog.Contains("middle") || textDialog.Contains("god") || textDialog.Contains("what are you") || textDialog.Contains("who are you"))
		{
			return "I am like a middle between God and voidness.";
		}
		if(textDialog.Contains("plate") || textDialog.Contains("emppty") || textDialog.Contains("being"))
		{
			return "A full plate hides an empty one, like the act of being hides voidness.";
		}
		if(textDialog.Contains("what is") && textDialog.Contains("void"))
		{
			return "Void is a hole with nothing around it.";
		}
		if(textDialog.Contains("nig") || textDialog.Contains("pussy") || textDialog.Contains("sex") || textDialog.Contains("nigga")
			|| textDialog.Contains("niggaz") || textDialog.Contains("bitch") || textDialog.Contains("ass") || textDialog.Contains("asshole")
			|| textDialog.Contains("fuck") || textDialog.Contains("fucked") || textDialog.Contains("tits") || textDialog.Contains("vagina") 
			||textDialog.Contains("vag") || textDialog.Contains("titties") || textDialog.Contains("penis") || textDialog.Contains("dick") )
		{
			return "You have a filthy mouth, you should shut the fuck up!";
		}
		else
		{
			return "";
		}
		
	}
	
	string randomQuote()
	{
		
			int random = Random.Range(0,12);
		print (random);
			return tabQuotes[random];
	}
	
	void initRandomQuote()
	{
		tabQuotes.Add("Oh, you think the Shaft is your ally? but you merely adopted the Shaft. I was born in it, molded by it.");
		tabQuotes.Add("What does liberty mean, if not complete void, when it is not relative to others?");
		tabQuotes.Add("There is no difference between the abilities needed to reach the void than those needed to reach a whole.");
		tabQuotes.Add("In the end, what is a man in nature? A void when compared to infinity, a whole when compared to the void, halfway between everything and nothing.");
		tabQuotes.Add("Being or the void, there's the problem.");
		tabQuotes.Add("You have to look the void straight in the eyes to be able to triumph over it.");
		tabQuotes.Add("Void after death? Isn't that the state wich we were used to before life?");
		tabQuotes.Add("Religion speaks of immortality but this is a notion that implies voidness.");
		tabQuotes.Add("The drama of a human life is less in the absolute of it's void then in it's stubborn trials to avoid it.");
		tabQuotes.Add("Voidness doesn't have a center, and it's limits are voidness.");
		tabQuotes.Add("I am like a middle between God and voidness.");
		tabQuotes.Add("A full plate hides an empty one, like the act of being hides voidness.");
		tabQuotes.Add("Void is a hole with nothing around it.");
	}

}
