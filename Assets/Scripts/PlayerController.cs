using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	private float speed;

	public int health = 100;
	public int planets;
	public float fuel = 100f;

	private ScrollingTexture quad;
	private SpriteRenderer flameLR,flameRL,flameTB,flameBT;
	public TMP_Text healthText, planetsText;
	private Vector3 pos;
	
	// Use this for initialization
	void Start()
	{
		healthText = GameObject.Find("healthText").GetComponent<TextMeshPro>();
		planetsText = GameObject.Find("planetsText").GetComponent<TextMeshPro>();
		quad = GameObject.Find("Quad").GetComponent<ScrollingTexture>();
		speed = Mathf.Sqrt(quad.speed * Time.deltaTime) * 150;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		flameLR = GameObject.Find("FlameLR").GetComponent<SpriteRenderer>();
		flameRL = GameObject.Find("FlameRL").GetComponent<SpriteRenderer>();
		flameTB = GameObject.Find("FlameTB").GetComponent<SpriteRenderer>();
		flameBT = GameObject.Find("FlameBT").GetComponent<SpriteRenderer>();

		flameLR.enabled = true;
		flameRL.enabled = false;
		flameBT.enabled = false;
		flameTB.enabled = false;

		healthText.text = health + "%";
		planetsText.text = "Planets collected:" + planets;
	}

	// Update is called once per frame
	void Update ()
	{
		Debug.Log("Speed: " + speed);
		
		healthText.text = "Health: " + health + "%";
		planetsText.text = "Colonies saved: " + planets;

		
	
		if (health > 100)
		{
			health = 100;
		}
		
		if(health < 100) {
			health += 5 * (int)Time.deltaTime;
		}
		
		controls();
		movements();
		limitPos();

	}

	void limitPos()
	{
		pos = this.transform.position;

		if (pos.x > 9.2)
		{
			pos.x = 9.2f;
		}

		if (pos.y > 4.11)
		{
			pos.y = 4.11f;
		} else if (pos.y < -4.64)
		{
			pos.y = -4.64f;
		}

		this.transform.position = pos;
	}

	void controls()
	{
		float topbtm = Input.GetAxis("Vertical") * speed;
		float lftrgt = Input.GetAxis("Horizontal") * speed;

		topbtm *= Time.deltaTime;
		lftrgt *= Time.deltaTime;
		
		//Debug.LogFormat("Horizontal: {0}, Vertical: {1}", Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			
		transform.Translate(lftrgt, topbtm, 0);
	}

	void movements()
	{
		if (Input.GetAxis("Horizontal") > 0)
		{
			flameRL.enabled = false;
			flameBT.enabled = false;
			flameTB.enabled = false;
			
		}
		else if(Input.GetAxis("Horizontal") < 0)
		{
			flameRL.enabled = true;
			flameBT.enabled = false;
			flameTB.enabled = false;
		}

		if (Input.GetAxis("Vertical") > 0)
		{
			flameRL.enabled = false;
			flameBT.enabled = true;
			flameTB.enabled = false;
		}
		else if(Input.GetAxis("Vertical") < 0)
		{
			flameRL.enabled = false;
			flameBT.enabled = false;
			flameTB.enabled = true;
		}

		if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0)
		{
			flameRL.enabled = false;
			flameBT.enabled = true;
			flameTB.enabled = false;
		}
		else if(Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0)
		{
			flameRL.enabled = true;
			flameBT.enabled = false;
			flameTB.enabled = true;
		}
	}
}
