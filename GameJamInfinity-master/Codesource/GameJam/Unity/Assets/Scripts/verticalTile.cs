using UnityEngine;
using System.Collections;

public class verticalTile : MonoBehaviour {
	
	//Vector3[] usedTiles ;
	private GameObject theTile;
	private bool active = false;
	
	void Awake() {
		theTile=GameObject.FindGameObjectWithTag("VerticalTile");
		//active = false;
	}
	
	// Use this for initialization
	void Start () {
		//active = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void tileActivate() {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("VoidTile");
        Vector3 tilePos = theTile.transform.position;
		
        foreach (GameObject go in gos) {
			
				if (go.transform.position.x == tilePos.x)
				{
					if(go.transform.position.y <= 7.5 && 
					   go.transform.position.y >= -7.5)
					{
	            		Destroy(go);
					}
				}
       		 }
		
		Destroy(theTile);
    }
}
