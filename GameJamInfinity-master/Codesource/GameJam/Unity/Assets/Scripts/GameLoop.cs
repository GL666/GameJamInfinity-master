using UnityEngine;
using System.Collections;

public class GameLoop : MonoBehaviour {
	
	enum Turn
	{
		PlayerTurn,
		VoidTurn
	};
	
	private bool		bHasPlayerWon;
	private bool		bHasTheVoidWon;
	
	private bool		bReadyToPlayNextTurn;
	
	private bool		bIsFirstUpdate=true;
	
	private int			currentTurn;
	
	private GameObject	Player;
	private GameObject	TheVoid;
	
	private	PlayerMovement	PlayerScript;
	private	VoidAI			TheVoidScript;
	
	private Turn		lastTurn;
	
	// Use this for initialization
	void Awake () {
		
		bReadyToPlayNextTurn=false;
		
		/*Player	= GameObject.FindGameObjectWithTag("Player") as GameObject;
		TheVoid = GameObject.FindGameObjectWithTag("TheVoid") as GameObject;
		
		PlayerScript	=	Player.GetComponent<PlayerMovement>();
		TheVoidScript	=	TheVoid.GetComponent<VoidAI>();*/
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(bIsFirstUpdate)
		{
			Player	= GameObject.FindGameObjectWithTag("Player") as GameObject;
			TheVoid = GameObject.FindGameObjectWithTag("TheVoid") as GameObject;
			
			PlayerScript	=	Player.GetComponent<PlayerMovement>();
			TheVoidScript	=	TheVoid.GetComponent<VoidAI>();
			
		}
		
		//print ("GameLoop UPDATE");
		
		print ("Is Player Turn? : "+PlayerScript.GetIsPlayerTurn());
		print ("Is Void's Turn? : "+TheVoidScript.GetIsVoidsTurn());
		
		if(!PlayerScript.GetIsPlayerTurn() && !TheVoidScript.GetIsVoidsTurn())
		{
			//print ("+++++++++++++++++++++++VOID TURN++++++++++++++++++++++");
			if(bIsFirstUpdate)
			{
				TheVoidScript.SetIsVoidsTurn(true);
				bIsFirstUpdate=false;
				lastTurn=Turn.VoidTurn;
			}
			else
				if(lastTurn==Turn.VoidTurn)
				{
				print ("Player Turn");
				//PASSE LE TOUR AU JOUEUR
					TheVoidScript.SetIsVoidsTurn(false);
					PlayerScript.SetIsPlayerTurn(true);
					lastTurn=Turn.PlayerTurn;
				}
			else
				if(lastTurn==Turn.PlayerTurn)
				{
				print ("Void Turn");
				//PASSE LE TOUR A L'ENNEMI
					TheVoidScript.SetIsVoidsTurn(true);
					PlayerScript.SetIsPlayerTurn(false);
					lastTurn=Turn.VoidTurn;
				}
		}
		
		
		
		
		bHasPlayerWon=PlayerScript.GetHasWon();
		bHasTheVoidWon=TheVoidScript.GetHasWon();
		
		if(bHasPlayerWon || bHasTheVoidWon)
		{
			print ("============------------+++++++++GAME OVER+++++++++------------================");
			Application.LoadLevel("gameOver");
		}
	}
	
	void GameOver()
	{
		Application.LoadLevel("gameOver");
	}
}
