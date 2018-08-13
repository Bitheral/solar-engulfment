using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	void Start()
	{
		Time.timeScale = 1;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene("Game");
		} else if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
} 
