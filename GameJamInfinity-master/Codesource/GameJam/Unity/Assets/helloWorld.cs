using UnityEngine;
using System.Collections;

public class helloWorld : MonoBehaviour {
	public GUIStyle jeremie;
	public float currentTime;
	private GameObject dialogObj;
	
	// Use this for initialization
	void Start () {
		dialogObj = GameObject.FindGameObjectWithTag("DialogueText");
		dialogObj.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
	}
	
	void OnGUI()
	{
		if( (currentTime > 0 && currentTime < 34) || (currentTime > 118 && currentTime < 158) || (currentTime > 240 && currentTime < 281))
		{
			dialogObj.gameObject.SetActive(false);
		}
		if ( (currentTime > 34.5 && currentTime < 118) || (currentTime > 153 && currentTime < 240) || currentTime > 281)
		{
			dialogObj.gameObject.SetActive(true);
		}
		
		if( currentTime > 0 && currentTime < 34)
		{
			GUI.Label( new Rect(Screen.width/2+300, Screen.height/2+250, 100, 20), "Press F1 to skip...", jeremie);
			if ( currentTime > 0 && currentTime < 34 && Input.GetKeyDown(KeyCode.F1) || currentTime > 118 && currentTime < 158 && Input.GetKeyDown(KeyCode.F1))
			{
				currentTime = 34.5f;
				if (currentTime > 34.5f && currentTime < 35)
				{
					transform.Translate(new Vector3(0, 0, 0.1f));
				}
			}
		}
		if( currentTime > 118 && currentTime < 153)
		{
			GUI.Label( new Rect(Screen.width/2+300, Screen.height/2+250, 100, 20), "Press F1 to skip...", jeremie);
			if (currentTime > 118 && currentTime < 158 && Input.GetKeyDown(KeyCode.F1))
			{
				currentTime = 158;
				if (currentTime > 118 && currentTime < 153)
				{
					transform.Translate(new Vector3(0, 0, 0.1f));
				}
			}
		}
		if( currentTime > 240 && currentTime < 281)
		{
			GUI.Label( new Rect(Screen.width/2+300, Screen.height/2+250, 100, 20), "Press F1 to skip...", jeremie);
			if (currentTime > 240 && currentTime < 281 && Input.GetKeyDown(KeyCode.F1))
			{
				currentTime = 281;
				if (currentTime > 240 && currentTime < 281)
				{
					transform.Translate(new Vector3(0, 0, 0.1f));
				}
			}
		}
		if ( currentTime > 0 && currentTime < 5)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Infinity: What is this feeling? I feel... incomplete.", jeremie);
			GUI.Label(new Rect(Screen.width/2- Screen.width/3 - Screen.width/15, Screen.height/2 -Screen.height/8, 100,20), "At the same time, it's like I've never felt so complete...", jeremie);
		}
		if(currentTime >= 5 && currentTime < 10)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Void: Your usage of the pronoun 'I' is quite surprising.", jeremie);
		}	
		if (currentTime > 10 && currentTime < 15)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Infinity: Who is this?", jeremie);
		}
		if (currentTime > 15 && currentTime < 20)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Void: Existence is not real, it is but a trick of the mind.", jeremie);
			GUI.Label(new Rect(Screen.width/2- 410, Screen.height/2 -55, 100,20), "Do you remember being aware of your existence before?", jeremie);
		}
		if (currentTime > 20 && currentTime < 25)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Infinity: ...I...I don't know.", jeremie);
		}
		if (currentTime > 25 && currentTime < 30)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Void: It is impossible to know, because there is ", jeremie);
			GUI.Label(new Rect(Screen.width/2- Screen.width/3 - Screen.width/15, Screen.height/2 -Screen.height/8, 100,20), "nothing to know. There only *IS*", jeremie);
		}
		if (currentTime > 30 && currentTime < 34.5f)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Infinity: Leave me alone!", jeremie);
		}
		if (currentTime > 34.5f && currentTime < 35)
		{
			transform.Translate(new Vector3(0, 0, 0.1f));
		}
		//_---------------------------------------
		
		if (currentTime >117 && currentTime < 117.5)
		{
			transform.Translate(new Vector3(0, 0, -0.1f));
		}
		if (currentTime > 118 && currentTime < 123)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Void: What are you trying to accomplish?", jeremie);
		}
		if (currentTime > 123 && currentTime < 128)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Infinity: I'm defending myself!", jeremie);
		}
		if (currentTime > 128 && currentTime < 133)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Void: Pointless. I am less and more than everything or nothing.", jeremie);
			GUI.Label(new Rect(Screen.width/2- Screen.width/3 - Screen.width/15, Screen.height/2 -Screen.height/8, 100,20), "Destroying you is a simple and narrow-minded concept.", jeremie);
		}
		if (currentTime > 133 && currentTime < 138)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Infinity: ... I... I don't care. I will try and I will never", jeremie);
			GUI.Label(new Rect(Screen.width/2- Screen.width/3 - Screen.width/15, Screen.height/2 -Screen.height/8, 100,20), "stop doing so. I... I will battle you until the end of time!", jeremie);
		}
		if (currentTime > 138 && currentTime < 143)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Void: I told you, I am infinitely more than time itself.", jeremie);
			GUI.Label(new Rect(Screen.width/2- Screen.width/3 - Screen.width/15, Screen.height/2 -Screen.height/8, 100,20), "And so are you! Arguing is futile, we are above this.", jeremie);
		}
		if (currentTime > 143 && currentTime < 148)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Infinity: Do YOU remember being aware of your existence before?", jeremie);
			GUI.Label(new Rect(Screen.width/2- Screen.width/3 - Screen.width/15, Screen.height/2 -Screen.height/8, 100,20), "Because you surely are now.", jeremie);
		}
		if (currentTime > 148 && currentTime < 153)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Void: I... No! This means nothing!", jeremie);
		}
		if (currentTime >153 && currentTime < 153.5f)
		{
			transform.Translate(new Vector3(0, 0, 0.1f));
		}
		//---------------------------------------------
		
		if (currentTime > 240 && currentTime < 240.5)
		{
			transform.Translate(new Vector3(0, 0, -0.1f));
		}
		if (currentTime > 241 && currentTime < 246)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Infinity: I am tired of fighting.", jeremie);
		}
		if (currentTime > 246 && currentTime < 251)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Void: No! This will never be over!", jeremie);
		}
		if (currentTime > 251 && currentTime < 256)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Infinity: Why should we keep going? This brings us nothing.", jeremie);
		}
		if (currentTime > 256 && currentTime < 261)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Void: We have no reason to exist if we stop.", jeremie);
		}
		if (currentTime > 261 && currentTime < 266)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Infinity: You are right, what do you suggest?", jeremie);
		}
		if (currentTime > 266 && currentTime < 271)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Void: Let me assimilate you! I'll be whole again!", jeremie);
		}
		if (currentTime > 271 && currentTime < 276)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Infinity: How would assimilating me make you whole?", jeremie);
		}
		if (currentTime > 276 && currentTime < 281)
		{
			GUI.Label(new Rect(Screen.width/2- Screen.width/2, Screen.height/2 - Screen.height/6, 100,20), "Void: Silence! Do not oppose me!", jeremie);
		}
		if (currentTime > 281 && currentTime < 281.5f)
		{
			transform.Translate(new Vector3(0, 0, 0.1f));
		}
	}
}
