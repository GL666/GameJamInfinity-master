using UnityEngine;
using System.Collections;

public class PlayerSkill : MonoBehaviour {
	
	int range = 1;
	int xp = 0;
	int playerLvl = 1;
	int xpNeeded = 8;
	
	bool possibleAttack = true;
	
	private Vector3 vectorToSend;
	
	private On3dText textIn3D;
	
	public Transform xpUpPrefab;
	private Transform clonexpUp;
	
	Vector3 tilePos;
	//private Vector3		GridTopLeft, GridTopRight, GridBottomLeft, GridBottomRight;
	
	private GameObject	Player;
	public GameObject 	Tiles;
	
	void Awake() {
		Tiles=GameObject.FindGameObjectWithTag("VoidTile");
		Player=GameObject.FindGameObjectWithTag("Player");
		/*GridBottomLeft=new Vector3(7.5f, -7.5f, 10.0f);
		GridBottomRight=new Vector3(-7.5f, -7.5f, 10.0f);
		GridTopLeft=new Vector3(7.5f, 7.5f, 10.0f);
		GridTopRight=new Vector3(-7.5f, 7.5f, 10.0f);*/		
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown("space") && possibleAttack == true)
		{
			
			skillActivate();
		}
		
		if(xp >= xpNeeded)
		{
			Debug.Log("level up you twat");
			
			playerLvl++;
			xpNeeded = xpNeeded * 2;
		}
	}
	ArrayList tempGos = new ArrayList();
	void skillActivate() {
        ArrayList gos;

		gos = GameObject.FindGameObjectWithTag("TheVoid").GetComponent<VoidAI>().GetVoidTiles();
        //gos = GameObject.FindGameObjectsWithTag("VoidTile");
        Vector3 playerPos = Player.transform.position;
		range = playerLvl;
		
		
		
		tempGos=(ArrayList)gos.Clone();
				
        foreach (GameObject go in gos) {
			
				if (go.transform.position.x <= playerPos.x + range && 
					go.transform.position.x >= playerPos.x - range || 
					go.transform.position.x == playerPos.x)
				{
					if(go.transform.position.y <= playerPos.y + range && 
					   go.transform.position.y >= playerPos.y - range ||
					   go.transform.position.y == playerPos.y)
					{
						tempGos.Remove(go);
	            		Destroy(go);
						xp++;
					
						//createXp(go.transform.position.x,go.transform.position.y,go.transform.position.z + 5.0f);
						clonexpUp = Instantiate(xpUpPrefab, new Vector3(go.transform.position.x,go.transform.position.y,go.transform.position.z + 5),Quaternion.identity) as Transform;
						clonexpUp.transform.Rotate(new Vector3(0,1,0),180);
						clonexpUp.transform.localScale = new Vector3(0.2f,0.2f,0.0f);
						//textIn3D = new On3dText(go.transform.position.x,go.transform.position.y,go.transform.position.z + 5.0f);

					}
				}
        }
		
		gos.Clear();
		
		foreach (GameObject tmp in tempGos)
		{
			gos.Add (tmp);
		}
		
    }
	
}
