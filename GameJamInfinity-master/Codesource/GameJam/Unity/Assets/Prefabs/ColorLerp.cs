using UnityEngine;
using System.Collections;

public class ColorLerp : MonoBehaviour {
	
	public static string materialColour;
	public Color blue = new Color (149/255.0f,178/255.0f,247/255.0f);
	public Color green = new Color (184/255.0f,229/255.0f,172/255.0f);
	public Color yellow = new Color (250/255.0f,246/255.0f,156/255.0f);
	public Color pink = new Color (241/255.0f,174/255.0f,209/255.0f);
	public Color brown = new Color (183/255.0f,159/255.0f,149/255.0f);
	public bool readyToLerp = false;
	
	public Color lastColor;
	public Color colorAchieved;
	
	public float currentTime;
	private Color currentColor;
	public float valeurRandom;
	public float duration;
	public float t;
	public int i = 0;
	
	// Use this for initialization
	void Start () {
		valeurRandom = Random.value;
		if ( valeurRandom < 0.2 )
		{
			renderer.material.color = blue;
			currentColor = blue;
			lastColor = green;
			t= valeurRandom;
		}
		if ( valeurRandom >= 0.2 && valeurRandom < 0.4)
		{
			renderer.material.color = green;
			currentColor = green;
			lastColor = brown;
			t= valeurRandom;
		}
		if ( valeurRandom >= 0.4 && valeurRandom < 0.6)
		{
			renderer.material.color = brown;
			currentColor = brown;
			lastColor = yellow;
			t= valeurRandom;
		}
		if ( valeurRandom >= 0.6 && valeurRandom < 0.8)
		{
			renderer.material.color = yellow;
			currentColor = yellow;
			lastColor = pink;
			t= valeurRandom;
		}
		if ( valeurRandom >= 0.8)
		{
			renderer.material.color = pink;
			currentColor = pink;
			lastColor = blue;
			t= valeurRandom;
		}
		//colorAchieved = blue;
		readyToLerp = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!readyToLerp)
		{
			currentTime += Time.deltaTime;
		}
		
		if (currentTime >= 1.0f)
		{
			readyToLerp = true;
			currentTime = 0;
		}
		
		if (readyToLerp && currentTime < 1.0f)
		{
			//print ("lerping");
			renderer.material.color = Color.Lerp (startColor (), endColor (), t);
			if (t < 1.0f)
			{  
				t += Time.deltaTime/duration;
			}
		}
	
	}
	
	Color startColor()
	{
		return renderer.material.color;
	}
	
	Color endColor()
	{
		if (t >= 1.0f)
		{
			if (renderer.material.color == blue)
			{
				colorAchieved = blue;
				lastColor = green;
				t=0;
				return green;
			}
			if (renderer.material.color == green)
			{
				colorAchieved = green;
				lastColor = yellow;
				t=0;
				return yellow;
			}
			if (renderer.material.color == yellow)
			{
				colorAchieved = yellow;
				lastColor = pink;
				t=0;
				return pink;
			}
			if (renderer.material.color == pink)
			{
				colorAchieved = pink;
				lastColor = brown;
				t=0;
				return brown;
			}
			if (renderer.material.color == brown)
			{
				colorAchieved = brown;
				lastColor = blue;
				t=0;
				return blue;
			}
			else
				return blue;
		}
		else
			return lastColor;
	}
}
