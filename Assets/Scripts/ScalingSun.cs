using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingSun : MonoBehaviour
{

	private Transform sun;
	private Vector3 scaleIncrease;
	private Vector3 sunPosition;

	private ScrollingTexture quad;
	
	// Use this for initialization
	void Start ()
	{
		sun = this.transform;
		quad = GameObject.Find("Quad").GetComponent<ScrollingTexture>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		scaleIncrease = sun.localScale;
		sunPosition = sun.position;

		scaleIncrease.x += (quad.speed * 0.5f) * Time.deltaTime;
		scaleIncrease.y += (quad.speed * 0.5f) * Time.deltaTime;
		sunPosition.x -= quad.materialOffset.x * (Mathf.Pow(quad.speed,2) * 10f) * Time.deltaTime;
		
		sun.position = sunPosition;
		sun.localScale = scaleIncrease;
	}
}
