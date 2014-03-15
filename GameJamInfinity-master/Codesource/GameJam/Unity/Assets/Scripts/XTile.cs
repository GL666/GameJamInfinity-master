using UnityEngine;
using System.Collections;

public class XTile : MonoBehaviour {

	private GameObject theTile;
	private bool active = false;
	
	void Awake() {
		theTile=GameObject.FindGameObjectWithTag("XTile");
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
		int cpt = 1;
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("VoidTile");
		int nbTiles = gos.Length;
        Vector3 tilePos = theTile.transform.position;
		
		while(cpt < nbTiles)
		{
	        foreach (GameObject go in gos) 
			{
				
					if (go.transform.position.y == tilePos.y+cpt &&
					    go.transform.position.x == tilePos.x+cpt)
					{
		            		Destroy(go);
					}
					else if (go.transform.position.y == tilePos.y-cpt &&
					    go.transform.position.x == tilePos.x-cpt)
					{
		            		Destroy(go);
					}
					else if (go.transform.position.y == tilePos.y-cpt &&
					    go.transform.position.x == tilePos.x+cpt)
					{
		            		Destroy(go);
					}
					else if (go.transform.position.y == tilePos.y+cpt &&
					    go.transform.position.x == tilePos.x-cpt)
					{
		            		Destroy(go);
					}
					else 
					{
						cpt++;
					}
				
			}
        }
		
		Destroy(theTile);
    }
}
