using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Support : MonoBehaviour {

	void Start()
	{
		Time.timeScale = 1;
	}
 
	public void onPatreonButtonClicked()
	{
		Application.OpenURL("https://patreon.com/Bitheral");
	}
	 
	public void onPayPalButtonClicked()
	{
		Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=6K4FRSWX8W6R4");
	}

	public void onBackButtonClicked()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}
	
	
}
