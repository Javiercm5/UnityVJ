using UnityEngine;
using System.Collections;

public class GameManagement : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	

	// Update is called once per frame
	void Update () {
		if (player.transform.position.y <= -2.0f) {
			Application.LoadLevel(Application.loadedLevel);		
		}
	}
	
}
