using UnityEngine;	
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	enum TurnPhase
	{
		MovementPhase,
		DamagePhase,
		EndPhase
	};
	
	public	bool 		bHasWon;
	private	bool		bIsPlayerTurn;
	private	bool		bCanMoveToNewTile;
	private bool		bUpdatePosition;
	private bool		bIsBeginningOfTurn;
	private int			CurrentTurn;
	private	int			TotalTurns;
	private	int			AllowedSteps;
	private	int			RemainingSteps;
	private int			DesiredDisplacement;
	private float		PlayerZ=8.0f;
	private string		MovementQuadrant;
	private Vector3		GridTopLeft, GridTopRight, GridBottomLeft, GridBottomRight;
	
	//Player boundaries during his turn so that only the tiles around him are valid movements.
	private Vector3		TopLeftBound, TopRightBound, BotLeftBound, BotRightBound; 
	private	Vector3 	CurrentLocation;
	private	Vector3 	NewLocation;
	private Vector3		MovementLength;

	private GameObject	Player;
	
	private TurnPhase	CurrentTurnPhase;
	
	private int i=0;
	// Use this for initialization
	void Awake() {
		bHasWon=false;
		bIsPlayerTurn=false;
		bCanMoveToNewTile=true;
		bUpdatePosition=false;
		bIsBeginningOfTurn=true;
		AllowedSteps=1;
		RemainingSteps=AllowedSteps;
		Player			=GameObject.FindGameObjectWithTag("Player");
		GridBottomLeft	=new Vector3(7.5f, -7.5f, 10.0f);
		GridBottomRight	=new Vector3(-7.5f, -7.5f, 10.0f);
		GridTopLeft		=new Vector3(7.5f, 7.5f, 10.0f);
		GridTopRight	=new Vector3(-7.5f, 7.5f, 10.0f);
		TopRightBound	=new Vector3();
		TopLeftBound	=new Vector3();
		BotRightBound	=new Vector3();
		BotLeftBound	=new Vector3();
		MovementLength	=new Vector3();
		
		CurrentTurnPhase=TurnPhase.MovementPhase;
		
	}
	
	// Update is called once per frame
	void Update () {
		//print ("PlayerMovement UPDATE");
		if(bIsPlayerTurn)
		{
		
			if(bIsBeginningOfTurn)
			{
				CurrentLocation=Player.transform.position;
				bIsBeginningOfTurn=false;
				CurrentTurnPhase=TurnPhase.MovementPhase;
			}
			/*
			RaycastHit hitInfo;
			if (Physics.Raycast(Player.transform.position, new Vector3(0.0f,0.0f,-1.0f), out hitInfo, 100.0f) && hitInfo.normal.z > 0.999f)
			{
				if(hitInfo.transform.CompareTag("CrossTile"))
				{
					GameObject.FindGameObjectWithTag("CrossTile").GetComponent<crossTile>().tileActivate();
				}
				else if(hitInfo.transform.CompareTag("XTile"))
				{
					GameObject.FindGameObjectWithTag("XTile").GetComponent<XTile>().tileActivate();
				}
				else if(hitInfo.transform.CompareTag("HorizontalTile"))
				{
					GameObject.FindGameObjectWithTag("HorizontalTile").GetComponent<horizontalTile>().tileActivate();
				}
				else if(hitInfo.transform.CompareTag("VerticalTile"))
				{
					GameObject.FindGameObjectWithTag("VerticalTile").GetComponent<verticalTile>().tileActivate();
				}
			}*/
			
			
			if(CurrentTurnPhase==TurnPhase.MovementPhase)
			{
				if(Input.GetMouseButtonDown(0))
				{
	
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			    	RaycastHit hit;
			    	if (Physics.Raycast(ray, out hit) && hit.normal.z > 0.999f){
						//On veut que le joueur se déplace ou on click
			    		NewLocation=hit.transform.gameObject.transform.position;
						//On garde le joueur sur son layer
						NewLocation.z=PlayerZ;
						
						//Si la tuile qu'on frappe est le néan, on ne peut pas s'y déplacer
						if(hit.transform.CompareTag("VoidTile")/* || hit.transform.CompareTag("TheVoid")*/)
						{
							bCanMoveToNewTile=false;
						}
						else
						{
							bCanMoveToNewTile=true;
						}
			    	}
					//On trouve le vecteur de déplacement
					MovementLength=NewLocation-CurrentLocation;
					
					//On détermine dans quel quandrant se trouve le déplacement
					//soit en haut a droite, en bas a droite
					//en haut a gauche, en bas a gauche ou le long d'un axe
					//pour une raison qui m'échape... chu fucking fatigué. Shaft.
					DetermineQuadrant(MovementLength);
					
					//Ah oui, c'est pour faire ca!!
					if(MovementQuadrant=="AlongAxis")
						DesiredDisplacement=(int)MovementLength.magnitude;
					else
					{
						if(Mathf.Abs((int)MovementLength.x) > Mathf.Abs((int)MovementLength.y))
						{
							DesiredDisplacement=Mathf.Abs((int)MovementLength.x);
						}
						else
						{
							DesiredDisplacement=Mathf.Abs((int)MovementLength.y);
						}
					}
					
					if(DesiredDisplacement <= AllowedSteps)
					{
						//On indique qu'on est pret a mettre a jour sa position
						bUpdatePosition=true;
						//RemainingSteps-=DesiredDisplacement;
					}
					else
					{
						//Fuck yo couch.
					}
				}
				
				if(bUpdatePosition && bCanMoveToNewTile)
				{
					Player.transform.position=NewLocation;
					bUpdatePosition=false;
				}
				
				if (Input.GetKeyDown(KeyCode.Return))
				{
		           print ("enter pressed");
				   //end turn
				   CurrentTurnPhase=TurnPhase.DamagePhase;
				}
			}
			else
			if(CurrentTurnPhase==TurnPhase.DamagePhase)
			{
				if (Input.GetKeyDown(KeyCode.Return))
				{
		           print ("enter pressed");
				   CurrentTurnPhase=TurnPhase.EndPhase;
				}
			}
			else
			if(CurrentTurnPhase==TurnPhase.EndPhase)
			{
				bIsPlayerTurn=false;
				bIsBeginningOfTurn=true;
				CurrentTurnPhase=TurnPhase.MovementPhase;
				CheckIfPlayerHasWon();
			}
		}
	}
	
	public bool GetIsPlayerTurn()
	{
		return bIsPlayerTurn;
	}
	
	public void SetIsPlayerTurn(bool isTurn)
	{
		bIsPlayerTurn=isTurn;
	}
	
	public bool GetHasWon()
	{
		return bHasWon;
	}
	
	public void SetHasWon(bool hasWon)
	{
		bHasWon=hasWon;
	}
	
	void CheckIfPlayerHasWon()
	{
		//int count;
		//count = GameObject.FindGameObjectWithTag("TheVoid").GetComponent<VoidAI>().GetVoidTileCount();
		GameObject tmpVoid;
		
		tmpVoid = GameObject.FindGameObjectWithTag("TheVoid");
		
		if(tmpVoid == null)
		{
			SetHasWon(true);
		}
		else
		{
			SetHasWon(false);
		}
		
		/*if(count == 0)
		{
			SetHasWon(true);
		}
		else
		{
			SetHasWon(false);
		}*/
	}
	
	void DetermineQuadrant(Vector3 MovementLength)
	{
			if(MovementLength.x > 0 && MovementLength.y > 0)
			{
				MovementQuadrant="TopLeft";
			}
			else
				if(MovementLength.x > 0 && MovementLength.y < 0)
				{
					MovementQuadrant="BottomLeft";
				}
			else
				if(MovementLength.x < 0 && MovementLength.y > 0)
				{
					MovementQuadrant="TopRight";
				}
			else
				if(MovementLength.x < 0 && MovementLength.y < 0)
				{
					MovementQuadrant="BottomRight";
				}
			else
				{
					MovementQuadrant="AlongAxis";
				}
		
	}
}
