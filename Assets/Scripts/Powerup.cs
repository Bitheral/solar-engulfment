using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

	private PlayerController player;
	private QuickSpawner spawner;
	private Vector3 powerupPos;
	private ScrollingTexture quad;
	
	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		spawner = GameObject.Find("Powerups").GetComponent<QuickSpawner>();
		quad = GameObject.Find("Quad").GetComponent<ScrollingTexture>();
	}
	
	void Update () {
		
		powerupPos = this.transform.position;
		
		powerupPos.x -= (Mathf.Sqrt(quad.materialOffset.x) * 2f) * Time.deltaTime;

		this.transform.position = powerupPos;

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		int randomSecs = Random.Range(0, 10);
		
		Destroy(this.gameObject);
		spawner.secondsBetweenSpawnWaves = randomSecs;

		if (this.tag.Equals("Health"))
		{
			player.health += 50;

		}
	}
}
