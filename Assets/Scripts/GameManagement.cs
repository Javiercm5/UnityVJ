using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
	public GameObject player;
	public GameObject pauseMenu;
	public GameObject looseMenu;
	public GameObject winMenu;
	public GameObject camera;
	public Button NextLevelButton;
	public Text menuText;
	public Text enemiesText;
	public GameObject playerAttack;


	private bool paused;
	private bool gameFinished = false;


	void Awake()
	{
		UnPauseGame();
		EnableSound(); //camera.GetComponent<AudioListener>().enabled = true;

	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && !gameFinished) {
			if(paused) UnPauseGame();
			else PauseGame();
		}
	}

	public void PauseGame()
	{
		paused = true;
		Time.timeScale = 0;
		pauseMenu.SetActive(true);
		player.GetComponent<PlayerController>().enabled = false;
		camera.GetComponent<CameraController>().enabled = false;
		Screen.showCursor = true;
		Screen.lockCursor = false;
		DisableSound(); //camera.GetComponent<AudioListener>().enabled = false;
	}

	public void UnPauseGame()
	{
		paused = false;
		Time.timeScale = 1;
		pauseMenu.SetActive(false);
		player.GetComponent<PlayerController>().enabled = true;
		camera.GetComponent<CameraController>().enabled = true;
		Screen.showCursor = false;
		Screen.lockCursor = true;
		EnableSound(); //camera.GetComponent<AudioListener>().enabled = true;


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
		DisableSound(); //camera.GetComponent<AudioListener>().enabled = false;
		gameFinished = true;
	}

	public void WinGame()
	{
		paused = true;
		Time.timeScale = 0;
		if(Application.loadedLevel == Application.levelCount - 1){ 
			NextLevelButton.interactable = false;
			menuText.text = "Game finished";
		}
		enemiesText.text = playerAttack.GetComponent<PlayerAttack>().GetEnemiesKilled().ToString();
		winMenu.SetActive(true);
		player.GetComponent<PlayerController>().enabled = false;
		camera.GetComponent<CameraController>().enabled = false;
		Screen.showCursor = true;
		Screen.lockCursor = false;
		DisableSound(); //camera.GetComponent<AudioListener>().enabled = false;
		gameFinished = true;
	}

	public void ExitMenu()
	{
		Application.LoadLevel(0);
	}

	public void PlayAgain()
	{
		Application.LoadLevel(Application.loadedLevel);
		/*paused = false;
		Time.timeScale = 1;
		looseMenu.SetActive(false);
		player.GetComponent<PlayerController>().enabled = true;
		camera.GetComponent<CameraController>().enabled = true;
		Screen.showCursor = false;
		Screen.lockCursor = true;
		camera.GetComponent<AudioListener>().enabled = true;*/
	}

	public void ExitGame()
	{
		Application.Quit();

	}

	public void NextLevel()
	{
		if(Application.loadedLevel == (Application.levelCount -1)) Application.LoadLevel(0);
		else Application.LoadLevel (Application.loadedLevel + 1);
	}

	void DisableSound()
	{
		AudioListener.volume = 0.0f;
	}

	void EnableSound()
	{
		AudioListener.volume = 1.0f;
	}

}
