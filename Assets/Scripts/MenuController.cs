using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject chapterMenuPanel;
	public GameObject menuPanel;
	public GameObject creditsPanel;
	public GameObject controlsPanel;

	void Start () {
		chapterMenuPanel.SetActive(false);
	}
	
	void Update () {
	
	}

	public void StartGame()
	{
		Application.LoadLevel(1);
	}

	public void ExitGame()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif

	}

	public void ShowChapterMenu()
	{
		menuPanel.SetActive(false);
		chapterMenuPanel.SetActive(true);
		creditsPanel.SetActive(false);
		controlsPanel.SetActive (false);


		/*foreach(Button b in menuPanel.GetComponentsInChildren<Button>()){
			b.interactable = false;
		}*/
		//chapterMenu.GetComponent<Animator>().SetBool("chapterMenuSelected", false);

	}

	public void ShowControlsMenu()
	{
		menuPanel.SetActive(false);
		chapterMenuPanel.SetActive(false);
		creditsPanel.SetActive(false);
		controlsPanel.SetActive (true);

		
		
		/*foreach(Button b in menuPanel.GetComponentsInChildren<Button>()){
			b.interactable = false;
		}*/
		//chapterMenu.GetComponent<Animator>().SetBool("chapterMenuSelected", false);
		
	}

	public void ShowMainMenu()
	{
		menuPanel.SetActive(true);
		chapterMenuPanel.SetActive(false);
		creditsPanel.SetActive(false);
		controlsPanel.SetActive (false);


		//chapterMenuPanel.GetComponent<Animator>().SetBool("mainMenuSelected", true);

		/*foreach(Button b in menuPanel.GetComponentsInChildren<Button>()){
			b.interactable = true;
		}*/
	}


	public void SelectChapter(int lvlNumber)
	{
		Application.LoadLevel(lvlNumber);

	}

	public void ShowCredits()
	{
		menuPanel.SetActive(false);
		chapterMenuPanel.SetActive(false);
		creditsPanel.SetActive(true);
		controlsPanel.SetActive (false);


	}
}
