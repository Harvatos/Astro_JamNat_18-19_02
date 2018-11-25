using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public bool playCalled;
	public CanvasGroup whiteScreen;

	public Button playButton;
	public Button quitButton;

	private void Awake()
	{
		whiteScreen.alpha = 1f;
		playButton.Select();
	}

	void Update ()
	{
		if (playCalled)
		{
			whiteScreen.alpha += Time.deltaTime;
			if (whiteScreen.alpha >= 1f)
			{
				SceneManager.LoadScene("MainScene");
			}
		}
		else
		{
			whiteScreen.alpha -= Time.deltaTime;
		}
	}

	public void StartGame()
	{
		playCalled = true;
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
