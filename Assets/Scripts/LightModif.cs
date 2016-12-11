using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightModif : MonoBehaviour {
	Light lllll;

	List<Color> colors;
	Color lastColor = new Color(209 / 255.0F, 0 / 255.0F, 255 / 255.0F, 255 / 255.0F);

	// Use this for initialization
	void Start () {
		lllll = GetComponent<Light>();
		colors = new List<Color>();
		colors.Add(new Color(30 / 255.0F, 0 / 255.0F, 255 / 255.0F, 255 / 255.0F));
		colors.Add(new Color(0 / 255.0F, 202 / 255.0F, 255 / 255.0F, 255 / 255.0F));
		colors.Add(new Color(0 / 255.0F, 255 / 255.0F, 2 / 255.0F, 255 / 255.0F));
		colors.Add(new Color(255 / 255.0F, 185 / 255.0F, 0 / 255.0F, 255 / 255.0F));
	}

	// Update is called once per frame
	void Update () {

	}

	public void changeColor()
	{
		Color currentColor = colors[Random.Range(0, colors.Count)];
		colors.Add(lastColor);
		lllll.color = currentColor;
		colors.Remove(currentColor);
		lastColor = currentColor;
	}
}

