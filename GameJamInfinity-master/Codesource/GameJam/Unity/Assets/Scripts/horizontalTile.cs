using UnityEngine;
using System.Collections;

public class horizontalTile : MonoBehaviour {

	//Vector3[] usedTiles ;
	private GameObject theTile;
	private bool active = false;
	
	void Awake() {
		theTile=GameObject.FindGameObjectWithTag("HorizontalTile");
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
			
				if (go.transform.position.y == tilePos.y)
				{
					if(go.transform.position.x <= 7.5 && 
					   go.transform.position.x >= -7.5)
					{
	            		Destroy(go);
					}
				}
        }
		
		Destroy(theTile);
    }
}
