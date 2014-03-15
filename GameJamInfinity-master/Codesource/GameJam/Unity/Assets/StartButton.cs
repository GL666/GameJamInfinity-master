using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	
	private Color randomColor = new Color(1.0f,1.0f,1.0f);
	
	public static string materialColour;
	public Color blue = new Color (150.0f, 179.0f, 248.0f);
	public Color green = new Color (185.0f, 230.0f, 173.0f);
	public Color yellow = new Color (251.0f, 247.0f, 157.0f);
	public Color pink = new Color (235.0f, 184.0f, 209.0f);
	public Color brown = new Color (184.0f, 160.0f, 150.0f);
	private Color currentColor;
	public float valeurRandom;
	
	private float rouge;
	private float bleu;
	private float vert;
	
	private bool stopMoving = false;
	
	// Use this for initialization
	void Start () {
		//renderer.material.color = Color.blue;
		
		rouge = 0.0f;
		bleu = 0.0f;
		vert = 0.0f;
		
		stopMoving = false;
		
		valeurRandom = Random.value;
		
		renderer.material.color = Color.blue;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		vert += 0.001f;
		rouge += 0.0015f;
		bleu += 0.002f;
		
		if(vert >= 1.0f)
		{
			vert = 0.0f;
		}
		if(rouge >= 1.0f)
		{
			rouge = 0.0f;
		}
		if(bleu >= 1.0f)
		{
			bleu = 0.0f;
		}
		

			transform.RotateAround(new Vector3(1.0f,1.5f,8.0f),Time.time*0.2f);

		
		renderer.material.color = new Color(rouge,bleu,vert);
		
	
	}
	
	void OnMouseOver()
	{
		particleSystem.Play();
		
		
	}
	

	void OnMouseDown()
	{
		AutoFade.LoadLevel("yepyep",3,3,Color.black);
	}
}
