using UnityEngine;
using System.Collections;

public class GameManagement : MonoBehaviour
{
	public GameObject player;
	public GameObject pauseMenu;
	public GameObject looseMenu;
	public GameObject winMenu;
	//public GameObject enemiesKilled;
	public GameObject camera;


	private bool paused;

	void Awake()
	{
		unPauseGame();
		camera.GetComponent<AudioListener>().enabled = true;

	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if(paused) unPauseGame();
			else pauseGame();
		}
	}

	public void pauseGame()
	{
		paused = true;
		Time.timeScale = 0;
		pauseMenu.SetActive(true);
		player.GetComponent<PlayerController>().enabled = false;
		camera.GetComponent<CameraController>().enabled = false;
		Screen.showCursor = true;
		Screen.lockCursor = false;
		camera.GetComponent<AudioListener>().enabled = false;
	}

	public void unPauseGame()
	{
		paused = false;
		Time.timeScale = 1;
		pauseMenu.SetActive(false);
		player.GetComponent<PlayerController>().enabled = true;
		camera.GetComponent<CameraController>().enabled = true;
		Screen.showCursor = false;
		Screen.lockCursor = true;
		camera.GetComponent<AudioListener>().enabled = true;


	}

	public void LooseGame()
	{
		paused = true;
		Time.timeScale = 0;
		looseMenu.SetActive(true);
		player.GetComponent<PlayerController>().enabled = false;
		camera.GetComponent<CameraController>().enabled = false;
		Screen.showCursor = true;
		Screen.lockCursor = false;
		camera.GetComponent<AudioListener>().enabled = false;
	}

	public void WinGame()
	{
		
	}

	public void exitMenu()
	{
		Application.LoadLevel(0);
	}

	public void exitGame()
	{
		Application.Quit();

	}

}
