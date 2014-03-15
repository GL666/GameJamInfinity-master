using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	
	public static string materialColour;
	public Color blue = new Color (150.0f, 179.0f, 248.0f);
	public Color green = new Color (185.0f, 230.0f, 173.0f);
	public Color yellow = new Color (251.0f, 247.0f, 157.0f);
	public Color pink = new Color (235.0f, 184.0f, 209.0f);
	public Color brown = new Color (184.0f, 160.0f, 150.0f);
	private Color currentColor;
	public float valeurRandom;
	
	// Use this for initialization
	void Start () {
		//Random.seed;
		valeurRandom = Random.value;
		
		if (valeurRandom < 0.2)
		{
			currentColor = blue;
		}
		if (valeurRandom > 0.2 && valeurRandom < 0.4)
		{
			currentColor = green;
		}
		if (valeurRandom > 0.4 && valeurRandom < 0.6)
		{
			currentColor = yellow;
		}
		if (valeurRandom > 0.6 && valeurRandom < 0.8)
		{
			currentColor = pink;
		}
		if (valeurRandom > 0.8 && valeurRandom <= 1.0)
		{
			currentColor = brown;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	if (currentColor == blue)
		{
			renderer.material.color = Color.Lerp (currentColor, green, 0.1f);
			currentColor = green;
		}
		if (currentColor == green)
		{
			renderer.material.color = Color.Lerp (currentColor, yellow, 0.1f);
			currentColor = yellow;
		}
		if (currentColor == yellow)
		{
			renderer.material.color = Color.Lerp (currentColor, pink, 0.1f);
			currentColor = pink;
		}
		if (currentColor == pink)
		{
			renderer.material.color = Color.Lerp (currentColor, brown, 0.1f);
			currentColor = brown;
		}
		if (currentColor == brown)
		{
			renderer.material.color = Color.Lerp (currentColor, blue, 0.1f);
			currentColor = blue;
		}
	
	}
}
