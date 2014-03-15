using UnityEngine;
using System.Collections;

public class backLerp : MonoBehaviour {
	public float rotationSpeed = 6;
	public float rotationSpeed2 = 3;
	public float rotationSpeedInverse = -4;
	public float currentTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		currentTime += Time.deltaTime;
		if (currentTime < 6.0f)
		{
			rotation ();
			sideRotation ();
		}
		if (currentTime > 6.0f && currentTime < 12.0f)
		{
			rotationInverse ();
			sideRotation();
		}
		if (currentTime > 12.0f)
		{
			currentTime = 0;
		}
	}
	void rotation()
	{
		transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
	}
	
	void rotationInverse()
	{
		transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
	}
	
	void sideRotation()
	{
		transform.Rotate (Vector3.down * rotationSpeed2 * Time.deltaTime);
	}
	
	void sideRotationInverse()
	{
		transform.Rotate (Vector3.up * rotationSpeed2 * Time.deltaTime);
	}
}
