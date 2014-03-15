using UnityEngine;
using System.Collections;

public class SpawnVoid : MonoBehaviour {
	
	private Vector3		VoidOrigin;
	public GameObject	TheVoid;
	// Use this for initialization
	void Start () {
		VoidOrigin = new Vector3(7.5f, -7.5f, 6.0f);
		
		Instantiate(TheVoid, VoidOrigin, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
