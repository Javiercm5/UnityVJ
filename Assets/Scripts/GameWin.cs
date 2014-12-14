using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameWin : MonoBehaviour {
	public GameObject gameManagement;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider hit)
	{

		if(hit.gameObject.tag == "Player"){
			gameManagement.GetComponent<GameManagement>().WinGame();
			audio.Play ();
		}
	}
}
