using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject chapterMenuPanel;
	public GameObject menuPanel;

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
		chapterMenuPanel.SetActive(true);
		menuPanel.SetActive(false);

		/*foreach(Button b in menuPanel.GetComponentsInChildren<Button>()){
			b.interactable = false;
		}*/
		//chapterMenu.GetComponent<Animator>().SetBool("chapterMenuSelected", false);

	}

	public void ShowMainMenu()
	{
		chapterMenuPanel.SetActive(false);
		menuPanel.SetActive(true);
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

	}
}
