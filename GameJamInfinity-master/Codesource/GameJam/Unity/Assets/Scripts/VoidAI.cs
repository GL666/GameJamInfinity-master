using UnityEngine;
using System.Collections;

public class VoidAI : MonoBehaviour {
	
	public	GameObject	Player;
	public	GameObject	TheVoid;
	public	GameObject	VoidTile;
	GameObject			minTile;
	private ArrayList	VoidTiles;
	private ArrayList	TmpVoidTiles;
	private ArrayList	ValidMoves;
	private int			AllowedMoves=2;
	private int			MoveCounter=0;
	private Vector3		DistanceToPlayer;
	private Vector3		VoidOrigin;
	private	Vector3		NewPosition;
	private	Vector3		ChosenTilePosition;
	private Vector3		GridTopLeft, GridTopRight, GridBottomLeft, GridBottomRight;
	private Vector3		MidTopLeft, MidTopRight, MidBottomLeft, MidBottomRight;
	private Vector3		GridCenter;
	private Vector3		PlayerPos;
	private	Vector3		RightMostPos;
	private	Vector3		LeftMostPos;
	private	Vector3		TopMostPos;
	private	Vector3		BotMostPos;
	private float		LeftBoundary, RightBoundary, TopBoundary, BottomBoundary;
	private float		anus, penis, vagina, scrotum; //relevant variables
	private int			TurnsLeft=2;
	private bool		bHasCenter=false;
	private bool		bVarsInitialised=false;
	private bool		bGridEndReached=false;
	private bool		bHasWon=false;
	private bool		bIsVoidsTurn=false;
	private bool		bIsFirstUpdate=true;
	
	private GameObject	Antoine;	//Day 31, I have entered the matrix and infiltrated the enemy base.
	
	
	void Awake () {
		VoidTiles = 	new ArrayList();
		TmpVoidTiles = 	new ArrayList();
		ValidMoves = 	new ArrayList();
		VoidTiles.Add (TheVoid);
		PlayerPos=		new Vector3();
		RightMostPos=	new Vector3();
		LeftMostPos=	new Vector3();
		TopMostPos=		new Vector3();
		BotMostPos=		new Vector3();
		VoidOrigin= 	new Vector3(7.5f, -7.5f, 6.0f);
		GridBottomLeft=	new Vector3(7.5f, -7.5f, 0.0f);
		GridBottomRight=new Vector3(-7.5f, -7.5f, 0.0f);
		GridTopLeft=	new Vector3(7.5f, 7.5f, 0.0f);
		GridTopRight=	new Vector3(-7.5f, 7.5f, 0.0f);
		GridCenter=		new Vector3(0.0f, 0.0f, 0.0f);
		MidBottomLeft=	new Vector3(0.5f, -0.5f, 0.0f);
		MidBottomRight=	new Vector3(-0.5f, -0.5f, 0.0f);
		MidTopLeft=		new Vector3(0.5f, 0.5f, 0.0f);
		MidTopRight=	new Vector3(-0.5f, 0.5f, 0.0f);
		Player = 		GameObject.FindGameObjectWithTag("Player");
		TheVoid = 		GameObject.FindGameObjectWithTag("TheVoid");
		
		SpawnOnAwake();
		
		LeftBoundary = GridTopLeft.x;
		RightBoundary = GridTopRight.x;
		TopBoundary = GridTopLeft.y;
		BottomBoundary = GridBottomLeft.y;
	}
	
	
	void Update () {
		//print ("VoidAI UPDATE");
		if(bIsFirstUpdate)
		{
			SpawnOnAwake();
			bIsFirstUpdate=false;
		}
		
		
		if(bIsVoidsTurn && !bHasWon)
		{
			if(!bHasCenter)
				AttemptToGainCenter();
			else 
				if(!bGridEndReached)
					AttemptToSurroundPlayer();
			else
				if(GetVoidTileCount() <= 50)
					RandomMove();
			else
				SpreadTowardsPlayer();
			
			CheckIfVoidHasWon();
			
			if(TurnsLeft<=0)
			{
				print ("===================>NOT VOID TURN");
				bIsVoidsTurn=false;
				TurnsLeft=2;
			}
			
			if(bIsVoidsTurn)
				TurnsLeft--;
			
		}
		

	}
	
	public bool GetHasWon()
	{
		return bHasWon;
	}
	
	public void SetHasWon()
	{
		bHasWon=true;
	}
	
	public bool GetIsVoidsTurn()
	{
		return bIsVoidsTurn;
	}
	
	public void SetIsVoidsTurn(bool bIsTurn)
	{
		bIsVoidsTurn=bIsTurn;
	}
	
	public ArrayList GetVoidTiles()
	{
		return VoidTiles;
	}
	
	public int GetVoidTileCount()
	{
		int count;
		
		count=VoidTiles.Count;
		
		return count;
	}
	
	void CheckIfVoidHasWon()
	{
		Vector3 tmpTilePos=new Vector3();
		Vector3 tmpPlayerPos=new Vector3();
		
		tmpTilePos=PickClosestTileToPlayer().transform.position;
		tmpPlayerPos=Player.transform.position;
		
		if(tmpTilePos.x==tmpPlayerPos.x && tmpTilePos.y==tmpPlayerPos.y)
		{
			print ("The Void has won");
			bHasWon=true;
		}
		else
		{
			bHasWon=false;
		}
	}
	
	void SpawnOnAwake()
	{
		Vector3 tmpPos=new Vector3();
		tmpPos = GridBottomLeft+new Vector3(0.0f, 1.0f, 6.0f);
		Instantiate(VoidTile, tmpPos, Quaternion.identity);
		tmpPos = GridBottomLeft+new Vector3(0.0f, 2.0f, 6.0f);
		Instantiate(VoidTile, tmpPos, Quaternion.identity);
		tmpPos = GridBottomLeft+new Vector3(-1.0f, 0.0f, 6.0f);
		Instantiate(VoidTile, tmpPos, Quaternion.identity);
		tmpPos = GridBottomLeft+new Vector3(-2.0f, 0.0f, 6.0f);
		Instantiate(VoidTile, tmpPos, Quaternion.identity);
		tmpPos = GridBottomLeft+new Vector3(-1.0f, 1.0f, 6.0f);
		Instantiate(VoidTile, tmpPos, Quaternion.identity);
	}
	
	Vector3 tmpVect=new Vector3();
	string tmpString;
	
	void RandomMove()
	{
		bool bHasValidTile=false;
		
		while(!bHasValidTile)
		{
			foreach (GameObject tile in VoidTiles)
			{
				GetValidRandomMoves(tile.transform.position);
				//print (ValidMoves.Count);
				if(ValidMoves.Count != 0)
				{
					bHasValidTile=true;
					tmpVect=tile.transform.position;
					tmpString=(string)ValidMoves[0];
					break;
				}
			}
			ClearValidMoves();
		}
		
		if(bHasValidTile)
			SpawnRandomTile(tmpString, tmpVect);
		
	}
	
	void AttemptToSurroundPlayer()
	{
		string	quadrant;
		
		PlayerPos=Player.transform.position;
		
		ChosenTilePosition=PickClosestTileToCenter().transform.position;
		
		//if has the center
		quadrant=DetermineQuadrant(PlayerPos-new Vector3(0.5f, -0.5f, 0.0f));
		
		if(!bVarsInitialised)
		{
			InitPositions(quadrant);
			bVarsInitialised=true;
		}
		
		SurroundPlayer(quadrant);
	}
	
	void AttemptToGainCenter()
	{
		Vector3 D2C;
		string desiredMove;
		
		
		ChosenTilePosition=PickClosestTileToCenter().transform.position;
		minTile=null;
		
		//print ("Chosen tile position: "+ChosenTilePosition);
		//If the closest tile is already in the middle, do not execute
		//since the number of tiles is even (16), it draws 8 tiles and the top right corner
		//of the last tile is at the grid center (0,0,0), therefore we must check if the tile itself
		//is located closest to the center given the length of the tile (1 unit in x and y)
		if(ChosenTilePosition.x != GridCenter.x+0.5f && ChosenTilePosition.y != GridCenter.y-0.5f)
		{
			GetValidMoves(ChosenTilePosition);
			
			D2C=GetDistanceToCenter(ChosenTilePosition);
			
			desiredMove=DetermineQuadrant(D2C);
			
			if(ValidateMove(desiredMove, ChosenTilePosition))
			{
				if(desiredMove=="SHAFT")
					print ("doubleyou tee eff m8");
				else
					if(desiredMove=="Right" || desiredMove=="Left" || desiredMove=="Up" || desiredMove=="Down")
					{
						MoveAlongAxis(desiredMove);
					}
				else
					MoveDiagonally(desiredMove);
			}
		
			ClearValidMoves();
		}
		else
		{
			//print ("Already in the center!");
			bHasCenter=true;
		}
	}
	
	void SpreadTowardsPlayer()
	{
		Vector3 D2P;
		string desiredMove;
		
		ChosenTilePosition=PickClosestTileToPlayer().transform.position;
		minTile=null;
		
		GetValidMoves(ChosenTilePosition);
		
		D2P=GetDistanceToPlayer(ChosenTilePosition);
		
		desiredMove=DetermineQuadrant(D2P);
		
		if(ValidateMove(desiredMove, ChosenTilePosition))
		{
			if(desiredMove=="SHAFT")
				print ("doubleyou tee eff m8");
			else
				if(desiredMove=="Right" || desiredMove=="Left" || desiredMove=="Up" || desiredMove=="Down")
				{
					MoveAlongAxis(desiredMove);
				}
			else
				MoveDiagonally(desiredMove);
		}
		
		ClearValidMoves();
	}
	
	void EndTurn()
	{
		
	}
	
	GameObject PickClosestTileToPlayer()
	{
		GameObject	currentTile;
		float		currentMinDist=100.0f;
		float		currentDist=0.0f;
		
		foreach (GameObject tile in VoidTiles)
		{
			currentTile=tile;
			currentDist=(Player.transform.position-currentTile.transform.position).magnitude;
			
			if(currentDist < currentMinDist)
			{
				currentMinDist=currentDist;
				minTile=tile; //assigned here
			}
		}
		
		return minTile;
		//ChosenTilePosition=minTile.transform.position; //used here
		
		//wtf u no understand compiler
		//L2 compile
	}
	
	GameObject PickClosestTileToCenter()
	{
		GameObject	currentTile;
		float		currentMinDist=100.0f;
		float		currentDist=0.0f;
		Vector3		tmp;
		
		foreach (GameObject tile in VoidTiles)
		{
			currentTile=tile;
			tmp=currentTile.transform.position;
			tmp.z=0.0f;
			
			currentDist=(GridCenter-tmp).magnitude;
			
			if(currentDist < currentMinDist)
			{
				currentMinDist=currentDist;
				minTile=tile; //assigned here
			}
		}
		
		return minTile;
		//ChosenTilePosition=minTile.transform.position; //used here
		
		//wtf u no understand compiler
		//L2 compile
	}
	
	Vector3 GetDistanceToPlayer(Vector3 TilePos)
	{
		Vector3 tmpVect;
		tmpVect=Player.transform.position-TilePos;
		return tmpVect;
	}
	
	Vector3 GetDistanceToCenter(Vector3 TilePos)
	{
		Vector3 tmpVect;
		tmpVect=GridCenter-TilePos;
		return tmpVect;
	}
	
	void GetValidMoves(Vector3 Position)
	{
		string move;
		Vector3 NewPosition;
		Vector3 TopRight, TopLeft, BottomRight, BottomLeft, Left, Right, Up, Down;
		
		TopRight = 		new Vector3(-1.0f, 1.0f, 0.0f);
		TopLeft = 		new Vector3(1.0f, 1.0f, 0.0f);
		BottomRight = 	new Vector3(-1.0f, -1.0f, 0.0f);
		BottomLeft = 	new Vector3(1.0f, -1.0f, 0.0f);
		Right = 		new Vector3(-1.0f, 0.0f, 0.0f);
		Left = 			new Vector3(1.0f, 0.0f, 0.0f);
		Up = 			new Vector3(0.0f, 1.0f, 0.0f);
		Down = 			new Vector3(0.0f, -1.0f, 0.0f);
		
		//and that's how it's done. like a bawss.
		
		NewPosition = Position+TopRight;
		move="TopRight";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
			ValidMoves.Add (move);	
		
			
		NewPosition = Position+TopLeft;
		move="TopLeft";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
			ValidMoves.Add (move);	
		
			
		NewPosition = Position+BottomRight;
		move="BottomRight";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
			ValidMoves.Add (move);	
		
			
		NewPosition = Position+BottomLeft;
		move="BottomLeft";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
			ValidMoves.Add (move);	
		
			
		NewPosition = Position+Right;
		move="Right";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
			ValidMoves.Add (move);	
		

		NewPosition = Position+Left;
		move="Left";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
			ValidMoves.Add (move);	
		
			
		NewPosition = Position+Up;
		move="Up";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
			ValidMoves.Add (move);	
		
			
		NewPosition = Position+Down;
		move="Down";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
			ValidMoves.Add (move);	
		
		//IT WERKS LAWELLAWELALWELAWELALWELAELAWEL
	
	}
	
	void GetValidRandomMoves(Vector3 Position)
	{
		string move;
		Vector3 NewPosition;
		Vector3 TopRight, TopLeft, BottomRight, BottomLeft, Left, Right, Up, Down;
		bool	bNotValid=false;
		
		TopRight = 		new Vector3(-1.0f, 1.0f, 0.0f);
		TopLeft = 		new Vector3(1.0f, 1.0f, 0.0f);
		BottomRight = 	new Vector3(-1.0f, -1.0f, 0.0f);
		BottomLeft = 	new Vector3(1.0f, -1.0f, 0.0f);
		Right = 		new Vector3(-1.0f, 0.0f, 0.0f);
		Left = 			new Vector3(1.0f, 0.0f, 0.0f);
		Up = 			new Vector3(0.0f, 1.0f, 0.0f);
		Down = 			new Vector3(0.0f, -1.0f, 0.0f);
		
		//and that's how it's done. like a bawss.
		
		NewPosition = Position+TopRight;
		move="TopRight";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
		{
			foreach (GameObject tile in VoidTiles)
			{
				tmpVect=tile.transform.position;
				if(tmpVect.x == NewPosition.x && tmpVect.y == NewPosition.y)
				{
					bNotValid=true;
				}
					
			}
			
			if(!bNotValid)
			{
				ValidMoves.Add (move);
				
			}
		}
		
		bNotValid=false;
		NewPosition = Position+TopLeft;
		move="TopLeft";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
		{
			foreach (GameObject tile in VoidTiles)
			{
				tmpVect=tile.transform.position;
				if(tmpVect.x == NewPosition.x && tmpVect.y == NewPosition.y)
				{
					bNotValid=true;
				}
					
			}
			
			if(!bNotValid)
			{
				ValidMoves.Add (move);
				
			}
		}	
		
		bNotValid=false;
		NewPosition = Position+BottomRight;
		move="BottomRight";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
		{
			foreach (GameObject tile in VoidTiles)
			{
				tmpVect=tile.transform.position;
				if(tmpVect.x == NewPosition.x && tmpVect.y == NewPosition.y)
				{
					bNotValid=true;
				}
					
			}
			
			if(!bNotValid)
			{
				ValidMoves.Add (move);
				
			}
		}
		
		bNotValid=false;	
		NewPosition = Position+BottomLeft;
		move="BottomLeft";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
		{
			foreach (GameObject tile in VoidTiles)
			{
				tmpVect=tile.transform.position;
				if(tmpVect.x == NewPosition.x && tmpVect.y == NewPosition.y)
				{
					bNotValid=true;
				}
					
			}
			
			if(!bNotValid)
			{
				ValidMoves.Add (move);
				
			}
		}
		
		bNotValid=false;
		NewPosition = Position+Right;
		move="Right";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
		{
			foreach (GameObject tile in VoidTiles)
			{
				tmpVect=tile.transform.position;
				if(tmpVect.x == NewPosition.x && tmpVect.y == NewPosition.y)
				{
					bNotValid=true;
				}
					
			}
			
			if(!bNotValid)
			{
				ValidMoves.Add (move);
				
			}
		}	
		
		bNotValid=false;
		NewPosition = Position+Left;
		move="Left";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
		{
			foreach (GameObject tile in VoidTiles)
			{
				tmpVect=tile.transform.position;
				if(tmpVect.x == NewPosition.x && tmpVect.y == NewPosition.y)
				{
					bNotValid=true;
				}
					
			}
			
			if(!bNotValid)
			{
				ValidMoves.Add (move);
				
			}
		}
		
		bNotValid=false;	
		NewPosition = Position+Up;
		move="Up";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
		{
			foreach (GameObject tile in VoidTiles)
			{
				tmpVect=tile.transform.position;
				if(tmpVect.x == NewPosition.x && tmpVect.y == NewPosition.y)
				{
					bNotValid=true;
				}
					
			}
			
			if(!bNotValid)
			{
				ValidMoves.Add (move);
				
			}
		}
		
		bNotValid=false;	
		NewPosition = Position+Down;
		move="Down";
		
		if(!(NewPosition.x > LeftBoundary) && !(NewPosition.x < RightBoundary)
			&& !(NewPosition.y > TopBoundary) && !(NewPosition.y < BottomBoundary))
		{
			foreach (GameObject tile in VoidTiles)
			{
				tmpVect=tile.transform.position;
				if(tmpVect.x == NewPosition.x && tmpVect.y == NewPosition.y)
				{
					bNotValid=true;
				}
					
			}
			
			if(!bNotValid)
			{
				ValidMoves.Add (move);
			}
		}
		
		//IT WERKS LAWELLAWELALWELAWELALWELAELAWEL
	
	}
	
	bool ValidateMove(string move, Vector3 Position)
	{
		bool bIsAValidMove=false;
		bool bIsNotOnAnotherTile=true;
		Vector3 NewPosition=new Vector3();
		
		NewPosition=GetNewPosition(move, Position);
		//if the desired position is on an existing tile
		foreach (GameObject tile in VoidTiles)
		{
			if(tile.transform.position == NewPosition)
				bIsNotOnAnotherTile=false;
		}
		
		for(int i = 0; i < ValidMoves.Count; i++)
		{
			if(ValidMoves[i]==move)
			{
				bIsAValidMove=true;
			}
		}
		
		if(bIsAValidMove && bIsNotOnAnotherTile)
			return true;
		else
			return false;
	}
	
	void ClearValidMoves()
	{
		ValidMoves.Clear();	
	}
	
	void MoveAlongAxis(string move)
	{
		switch(move)
		{
		case "Left": 		NewPosition=ChosenTilePosition+new Vector3(1.0f, 0.0f, 0.0f);
							GameObject tile=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject;
							VoidTiles.Add(tile);
							break;
		case "Right": 		NewPosition=ChosenTilePosition+new Vector3(-1.0f, 0.0f, 0.0f);
							GameObject tile2=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject;
							VoidTiles.Add(tile2);
							break;
		case "Up": 			NewPosition=ChosenTilePosition+new Vector3(0.0f, 1.0f, 0.0f);
							GameObject tile3=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject; 
							VoidTiles.Add(tile3);
							break;
		case "Down": 		NewPosition=ChosenTilePosition+new Vector3(0.0f, -1.0f, 0.0f);
						    GameObject tile4=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject;
						    VoidTiles.Add(tile4);
						    break;
		}
		
	}
	
	void InitPositions(string move)
	{
		switch(move)
		{
		case "TopLeft":		LeftMostPos=ChosenTilePosition;
							TopMostPos=ChosenTilePosition;
							//print ("Positions Initialised");
							break;
		case "TopRight":	RightMostPos=ChosenTilePosition;
							TopMostPos=ChosenTilePosition;
							//print ("Positions Initialised");
							break;
		case "BottomLeft":	LeftMostPos=ChosenTilePosition;
							BotMostPos=ChosenTilePosition;
							//print ("Positions Initialised");
							break;
		case "BottomRight":	RightMostPos=ChosenTilePosition;
							BotMostPos=ChosenTilePosition;
							//print ("Positions Initialised");
							break;
		}
	}
	
	void SurroundPlayer(string move)
	{
		switch(move)
		{
		case "TopLeft"		: 	//print("Surrounding TopLeft");
								//print ("BEFORE LEFT: "+LeftMostPos);
								GetValidMoves(LeftMostPos);
								if(ValidateMove("Left", LeftMostPos))
								{
									LeftMostPos+=new Vector3(1.0f, 0.0f, 0.0f);
									GameObject tile=Instantiate(VoidTile, LeftMostPos, Quaternion.identity) as GameObject;
									VoidTiles.Add (tile);
									
								}
								
								//print ("AFTER LEFT: "+LeftMostPos);
								ClearValidMoves();
								
								//print ("BEFORE TOP: "+TopMostPos);
								GetValidMoves(TopMostPos);
								if(ValidateMove("Up", TopMostPos))
								{
									TopMostPos+=new Vector3(0.0f, 1.0f, 0.0f);
									GameObject tile2=Instantiate(VoidTile, TopMostPos, Quaternion.identity) as GameObject;
									VoidTiles.Add (tile2);
									
								}
								else
								{
									bGridEndReached=true;
								}
								//print ("AFTER TOP: "+TopMostPos);
								ClearValidMoves();
								break;
			
		case "TopRight"		: 	//print("Surrounding TopRight");
								//print ("BEFORE RIGHT: "+RightMostPos);
								GetValidMoves(RightMostPos);
								if(ValidateMove("Right", RightMostPos))
								{
									RightMostPos+=new Vector3(-1.0f, 0.0f, 0.0f);
									GameObject tile=Instantiate(VoidTile, RightMostPos, Quaternion.identity) as GameObject;
									VoidTiles.Add (tile);
									
								}
								
								//print ("AFTER RIGHT: "+RightMostPos);
								ClearValidMoves();
								
								//print ("BEFORE TOP: "+TopMostPos);
								GetValidMoves(TopMostPos);
								if(ValidateMove("Up", TopMostPos))
								{
									TopMostPos+=new Vector3(0.0f, 1.0f, 0.0f);
									GameObject tile2=Instantiate(VoidTile, TopMostPos, Quaternion.identity) as GameObject;
									VoidTiles.Add (tile2);
									
								}
								else
								{
									bGridEndReached=true;
								}
								//print ("AFTER TOP: "+TopMostPos);
								ClearValidMoves();
								break;
			
		case "BottomLeft"	: 	//print("Surrounding BottomLeft");
								//print ("BEFORE LEFT: "+LeftMostPos);
								GetValidMoves(LeftMostPos);
								if(ValidateMove("Left", LeftMostPos))
								{
									LeftMostPos+=new Vector3(1.0f, 0.0f, 0.0f);
									GameObject tile=Instantiate(VoidTile, LeftMostPos, Quaternion.identity) as GameObject;
									VoidTiles.Add (tile);

								}
								
								//print ("AFTER LEFT: "+LeftMostPos);
								ClearValidMoves();
								
								//print ("BEFORE BOTTOM: "+BotMostPos);
								GetValidMoves(BotMostPos);
								if(ValidateMove("Down", BotMostPos))
								{
									BotMostPos+=new Vector3(0.0f, -1.0f, 0.0f);
									GameObject tile2=Instantiate(VoidTile, BotMostPos, Quaternion.identity) as GameObject;
									VoidTiles.Add (tile2);
									
								}
								else
								{
									bGridEndReached=true;
								}
								//print ("AFTER BOTTOM: "+BotMostPos);
								ClearValidMoves();
								break;
			
		case "BottomRight"	: 	//print("Surrounding BottomRight");
								//print ("BEFORE RIGHT: "+RightMostPos);
								GetValidMoves(RightMostPos);
								if(ValidateMove("Right", RightMostPos))
								{
									RightMostPos+=new Vector3(-1.0f, 0.0f, 0.0f);
									GameObject tile=Instantiate(VoidTile, RightMostPos, Quaternion.identity) as GameObject;
									VoidTiles.Add (tile);
									
								}
								
								//print ("AFTER RIGHT: "+RightMostPos);
								ClearValidMoves();
								
								//print ("BEFORE BOTTOM: "+BotMostPos);
								GetValidMoves(BotMostPos);
								if(ValidateMove("Down", BotMostPos))
								{
									BotMostPos+=new Vector3(0.0f, -1.0f, 0.0f);
									GameObject tile2=Instantiate(VoidTile, BotMostPos, Quaternion.identity) as GameObject;
									VoidTiles.Add (tile2);
									
								}
								else
								{
									bGridEndReached=true;
								}
								//print ("AFTER TOP: "+BotMostPos);
								ClearValidMoves();
							    break;
		}
		
	}
	
	void MoveDiagonally(string quadrant)
	{
		switch(quadrant)
		{
		
		case "TopLeft": 	NewPosition=ChosenTilePosition+new Vector3(1.0f, 1.0f, 0.0f);
							GameObject tile=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject;
							VoidTiles.Add(tile);
							break;
		case "TopRight": 	NewPosition=ChosenTilePosition+new Vector3(-1.0f, 1.0f, 0.0f);
							GameObject tile2=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject;
							VoidTiles.Add(tile2);
							break;
		case "BottomLeft": 	NewPosition=ChosenTilePosition+new Vector3(1.0f, -1.0f, 0.0f);
							GameObject tile3=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject; 
							VoidTiles.Add(tile3);
							break;
		case "BottomRight": NewPosition=ChosenTilePosition+new Vector3(-1.0f, -1.0f, 0.0f);
						    GameObject tile4=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject;
						    VoidTiles.Add(tile4);
						    break;
		}
	}
	
	string DetermineQuadrant(Vector3 MovementLength)
	{
			if(MovementLength.x > 0 && MovementLength.y > 0)
			{
				return "TopLeft";
			}
			else
				if(MovementLength.x > 0 && MovementLength.y < 0)
				{
					return "BottomLeft";
				}
			else
				if(MovementLength.x < 0 && MovementLength.y > 0)
				{
					return "TopRight";
				}
			else
				if(MovementLength.x < 0 && MovementLength.y < 0)
				{
					return "BottomRight";
				}
			else
				if(MovementLength.y == 0 && MovementLength.x < 0)
				{
					return "Right";
				}
			else
				if(MovementLength.y == 0 && MovementLength.x > 0)
				{
					return "Left";
				}
			else
				if(MovementLength.x == 0 && MovementLength.y < 0)
				{
					return "Down";
				}
			else
				if(MovementLength.x == 0 && MovementLength.y > 0)
				{
					return "Up";
				}
			else
				return "SHAFT";
	}
	
	Vector3 GetNewPosition(string move, Vector3 curPos)
	{
		Vector3 NewPosition=new Vector3();
		
		switch(move)
		{
		case "Left": 		NewPosition=curPos+new Vector3(1.0f, 0.0f, 0.0f);
							break;
		case "Right": 		NewPosition=curPos+new Vector3(-1.0f, 0.0f, 0.0f);
							break;
		case "Up": 			NewPosition=curPos+new Vector3(0.0f, 1.0f, 0.0f);
							break;
		case "Down": 		NewPosition=curPos+new Vector3(0.0f, -1.0f, 0.0f);
						    break;	
		case "TopLeft": 	NewPosition=curPos+new Vector3(1.0f, 1.0f, 0.0f);
							break;
		case "TopRight": 	NewPosition=curPos+new Vector3(-1.0f, 1.0f, 0.0f);
							break;
		case "BottomLeft": 	NewPosition=curPos+new Vector3(1.0f, -1.0f, 0.0f);
							break;
		case "BottomRight": NewPosition=curPos+new Vector3(-1.0f, -1.0f, 0.0f);
						    break;
		}
		
		return NewPosition;
	}
	
	void SpawnRandomTile(string quadrant, Vector3 pos)
	{
		switch(quadrant)
		{
		case "Left": 		NewPosition=pos+new Vector3(1.0f, 0.0f, 0.0f);
							GameObject tile=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject;
							VoidTiles.Add(tile);
							break;
		case "Right": 		NewPosition=pos+new Vector3(-1.0f, 0.0f, 0.0f);
							GameObject tile2=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject;
							VoidTiles.Add(tile2);
							break;
		case "Up": 			NewPosition=pos+new Vector3(0.0f, 1.0f, 0.0f);
							GameObject tile3=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject; 
							VoidTiles.Add(tile3);
							break;
		case "Down": 		NewPosition=pos+new Vector3(0.0f, -1.0f, 0.0f);
						    GameObject tile4=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject;
						    VoidTiles.Add(tile4);
						    break;
		case "TopLeft": 	NewPosition=pos+new Vector3(1.0f, 1.0f, 0.0f);
							GameObject tile5=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject;
							VoidTiles.Add(tile5);
							break;
		case "TopRight": 	NewPosition=pos+new Vector3(-1.0f, 1.0f, 0.0f);
							GameObject tile6=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject;
							VoidTiles.Add(tile6);
							break;
		case "BottomLeft": 	NewPosition=pos+new Vector3(1.0f, -1.0f, 0.0f);
							GameObject tile7=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject; 
							VoidTiles.Add(tile7);
							break;
		case "BottomRight": NewPosition=pos+new Vector3(-1.0f, -1.0f, 0.0f);
						    GameObject tile8=Instantiate(VoidTile, NewPosition, Quaternion.identity) as GameObject;
						    VoidTiles.Add(tile8);
						    break;
		default:print ("error");
			break;
		}
	}
}
