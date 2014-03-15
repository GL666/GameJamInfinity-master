using UnityEngine;
using System.Collections;

public class On3dText : MonoBehaviour {
	private float textSpeed = 2.0f;
	private float timer = 0.0f;
	private Vector3 moveUp;
	private Transform TransObj;
	private Vector3 vectorTrans;
	private float t;
	private int duration;
	private Color fadeAway = new Color (0.0f,0.0f,0.0f,0.0f);
	
	private bool created = false;
	
	
	// Use this for initialization
	void Start () {
		created = true;
		t = 0;
		duration = 2;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if(created)
		{	print("penis dans on3dtext");
			transform.Translate(Time.deltaTime*0.5f, Time.deltaTime*0.5f, Time.deltaTime*2f);
		}
		//transform.Translate(moveUp);
		//transform.renderer.material.color = Color.Lerp(Color.red,Color.clear, 2.0f);
		if ( timer > 1.5f)
		{
			renderer.material.color = Color.Lerp (Color.white,Color.clear, t);
			if (t < 1.0f)
			{  
				t += Time.deltaTime/duration;
			}	
		}
		
	}
	
}
