using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sun : MonoBehaviour
{

	private PlayerController player;
	private GameObject ui, playerUI;
	private TMP_Text colony, death, score, enter, esc;
	
	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		playerUI = player.transform.GetChild(0).gameObject;
		ui = GameObject.Find("UI");
		Transform buttons = ui.transform.GetChild(3);

		colony = ui.transform.GetChild(0).GetComponent<TMP_Text>();
		death = ui.transform.GetChild(1).GetComponent<TMP_Text>();
		score = ui.transform.GetChild(2).GetComponent<TMP_Text>();
		enter = buttons.GetChild(0).GetComponent<TMP_Text>();
		esc = buttons.GetChild(1).GetComponent<TMP_Text>();

		playerUI.SetActive(true);
		colony.enabled = false;
		death.enabled = false;
		score.enabled = false;
		enter.enabled = false;
		esc.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.health <= 0 || colony.enabled)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Time.timeScale = 1;
				SceneManager.LoadScene("MainMenu");
			} else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				Time.timeScale = 1;
				SceneManager.LoadScene("Game");
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other.gameObject.tag);

		if (other.gameObject.tag.Equals("Planet"))
		{
			Destroy(other.gameObject);
			Time.timeScale = 0.00000001f;
			score.text = "Score: " + player.planets;
			colony.enabled = true;
			endGame();
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			player.health--;
			if (player.health <= 0)
			{
				Time.timeScale = 0.00000001f;
				score.text = "Score: " + player.planets;
				death.enabled = true;
				endGame();
			}
		}
	}

	void endGame()
	{
		playerUI.SetActive(false);
		score.enabled = true;
		enter.enabled = true;
		esc.enabled = true;
	}
}
