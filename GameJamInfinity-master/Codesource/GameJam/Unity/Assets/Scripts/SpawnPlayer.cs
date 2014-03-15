using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {
	
	private	bool		bIsSpawned=false;
	private Vector3		StartingPosition;
	private Vector3		GridTopLeft, GridTopRight, GridBottomLeft, GridBottomRight;
	private float		PlayerZ=8.0f;
	
	public GameObject	Player;
	
	// Use this for initialization
	void Awake () {
		GridBottomLeft=new Vector3(7.5f, -7.5f, 10.0f);
		GridBottomRight=new Vector3(-7.5f, -7.5f, 10.0f);
		GridTopLeft=new Vector3(7.5f, 7.5f, 10.0f);
		GridTopRight=new Vector3(-7.5f, 7.5f, 10.0f);
		StartingPosition=new Vector3(GridTopRight.x, GridTopRight.y, PlayerZ);
		
		if(!bIsSpawned)
		{
			Instantiate(Player, StartingPosition, Quaternion.identity);
			bIsSpawned=true;	
		}
	}
}
