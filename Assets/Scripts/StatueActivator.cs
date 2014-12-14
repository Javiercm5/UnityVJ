using UnityEngine;
using System.Collections;

public class StatueActivator : MonoBehaviour {

	// Use this for initialization
	public GameObject toUnlock;
	public GameObject laserActive;
	private bool activated = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "StatueActivator" && !activated){
			activated = true;
			hit.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			toUnlock.GetComponent<UnlockKey>().activate();
			laserActive.SetActive(true);
		}
	}
}
