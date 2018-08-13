using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{

	public Material material;
	public float speed;

	public Vector2 materialOffset;

	private GameObject player;
	private Vector3 playerPos;
	
	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		MeshRenderer mr = GetComponent<MeshRenderer>();
		material = mr.material;
		
		playerPos = player.transform.position;

		materialOffset = material.mainTextureOffset;
		materialOffset.x += speed * Time.deltaTime;

		playerPos.x -= (speed * 30f) * Time.deltaTime;

		player.transform.position = playerPos;
		material.mainTextureOffset = materialOffset;
	}
}
