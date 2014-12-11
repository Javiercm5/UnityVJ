using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public GameObject door;
	public bool needKey = false;

	private bool opened = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider hit)
	{
		Debug.Log ("entered");

		if(hit.gameObject.tag == "Player" && !opened){

			if(needKey){
				if(hit.gameObject.GetComponent<PlayerController>().hasKey()){
					opened = true;
					door.animation.Play("DoorAnimation");
				}
			}

			else{
				opened = true;
				door.animation.Play("DoorAnimation");
			}
		}
	}
}
