using UnityEngine;
using System.Collections;

public class SpawnTiles : MonoBehaviour {
	
	public GameObject BasicTile;
	public GameObject CrossTile;
	//public GameObject crossTile;
	public GameObject xTile;
	public GameObject HorizontalTile;
	public GameObject VerticalTile;
	private GameObject tile;
	
	private ArrayList TileList;
	
	// Use this for initialization
	void Start () {
		TileList = new ArrayList();
		CreateTiles();
	}
	
	// Update is called once per frame
	/*void Update () {
		
			CreateCrossTile();
		
			CreateVerticalTile();
		
			CreateHorizontalTile();
		
			CreateXTile();
	}*/
	
	
	void CreateTiles()
	{
		Vector3 pos = new Vector3();
		//position en bas a gauche
		pos.x = 7.5f;
		pos.y = -7.5f;
		pos.z = 5.0f;
		
		print("Instantiating tiles");
		//on déplace de bas en haut et ensuite de droite a gauche.
		for(int i = 0; i < 16; i++)
		{
			for(int j = 0; j < 16; j++)
			{
				GameObject tile = (GameObject)Instantiate(BasicTile, pos, Quaternion.identity);
				//tile.AddComponent("ColorLerp");
				if(tile != null)
					TileList.Add(tile);
				
				pos.y++;
			}
			pos.x--;
			pos.y = -7.5f; //reset y position
		}
	}
	
	void CreateXTile()
	{
		XTile XTileScript = xTile.GetComponent<XTile>();
		if(XTileScript.active == false)
		{
			Vector3 pos = new Vector3();
			
			int modifier = Random.Range(-7, 7);
			
			pos.x = 0.5f + modifier;
			pos.y = 0.5f + modifier;
			pos.z = 5.5f;
					
			
	
			GameObject tile = (GameObject)Instantiate(xTile, pos, Quaternion.identity);
			
			XTileScript.active = true;
		}
	}
	
	void CreateCrossTile()
	{
		crossTile crossTileScript = CrossTile.GetComponent<crossTile>();
		if(crossTileScript.active == false)
		{
			Vector3 pos = new Vector3();
			
			int modifier = Random.Range(-7, 7);
			
			pos.x = 0.5f + modifier;
			pos.y = 0.5f + modifier;
			pos.z = 5.5f;
					
			print("Instantiating Special tile");
	
			GameObject tile = (GameObject)Instantiate(CrossTile, pos, Quaternion.identity);
			
			crossTileScript.active = true;
		}
	}
	
	void CreateHorizontalTile()
	{
		horizontalTile horizontalTileScript = HorizontalTile.GetComponent<horizontalTile>();
		if(horizontalTileScript.active == false)
		{
			Vector3 pos = new Vector3();
			
			int modifier = Random.Range(-7, 7);
			
			pos.x = 0.5f + modifier;
			pos.y = 0.5f + modifier;
			pos.z = 5.5f;
					
			print("Instantiating Special tile");
	
			GameObject tile = (GameObject)Instantiate(HorizontalTile, pos, Quaternion.identity);
			
			horizontalTileScript.active = true;
		}
	}
	
	void CreateVerticalTile()
	{
		verticalTile verticalTileScript = VerticalTile.GetComponent<verticalTile>();
		if(verticalTileScript.active == false)
		{
			Vector3 pos = new Vector3();
			
			int modifier = Random.Range(-7, 7);
			
			pos.x = 0.5f + modifier;
			pos.y = 0.5f + modifier;
			pos.z = 5.5f;
					
			print("Instantiating Special tile");
			
			//XTile = GameObject.FindGameObjectWithTag("Xtile");
			tile = Instantiate(VerticalTile, pos, Quaternion.identity) as GameObject;
			
			verticalTileScript.active = true;
		}
	}
}
