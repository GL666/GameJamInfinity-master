using UnityEngine;
using System.Collections;

public class crossTile : MonoBehaviour {

	//Vector3[] usedTiles ;
	private GameObject theTile;
	private bool active = false;
	
	void Awake() {
		theTile=GameObject.FindGameObjectWithTag("CrossTile");
		//active = false;
	}
	
	// Use this for initialization
	void start () {
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
			
				if (go.transform.position.y == tilePos.y && 
					go.transform.position.x == tilePos.x)
				{
	            		Destroy(go);
				}
        }
		
		Destroy(theTile);
    }
}
