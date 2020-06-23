using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageOpacityHandler : MonoBehaviour {

	[Tooltip("Between 0 to 1")]public float Opacity;
	private Color ImageColor;
	
	// Update is called once per frame
	void Update () {

		ImageColor = gameObject.GetComponent<Image> ().color;
		gameObject.GetComponent<Image> ().color = new Color (ImageColor.r, ImageColor.g, ImageColor.b, Opacity);


	}
}
