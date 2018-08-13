using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{

	private Vector3 planetPos;
	private ScrollingTexture quad;
	private PlayerController player;
	private QuickSpawner spawner;

	void Start()
	{
		quad = GameObject.Find("Quad").GetComponent<ScrollingTexture>();
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		spawner = GameObject.Find("Planets").GetComponent<QuickSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
		
		planetPos = this.transform.position;
		
		planetPos.x -= (Mathf.Sqrt(quad.materialOffset.x) * 2f) * Time.deltaTime;

		this.transform.position = planetPos;

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		int randomSecs = Random.Range(0, 10);
		
		player.planets += 1;
		Destroy(this.gameObject);
		spawner.secondsBetweenSpawnWaves = randomSecs;

	}
}
