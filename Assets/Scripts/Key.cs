using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "Player"){
			hit.gameObject.GetComponent<PlayerController>().setKey();
			Destroy (gameObject);
		}
	}
}
