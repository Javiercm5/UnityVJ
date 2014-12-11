using UnityEngine;
using System.Collections;

public class UnlockKey : MonoBehaviour {
	public GameObject door;

	private int nActivations = 0;
	private bool opened = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(nActivations >=2 && !opened){
			opened = true;
			door.animation.Play("DoorAnimation");
		}
	}

	public void activate()
	{
		++nActivations;
		Debug.Log(nActivations);
	}
}
