using UnityEngine;
using System.Collections;

public class GameManagement : MonoBehaviour
{
	public GameObject player;
	public GameObject pauseMenu;
	public GameObject camera;

	private bool paused;

	void Awake()
	{
		paused = false;
		pauseMenu.SetActive(false);
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

	}



	public void exitGame()
	{
		Application.Quit();

	}
}
