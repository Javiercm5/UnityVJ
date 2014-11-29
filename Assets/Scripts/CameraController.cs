using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float rotateSpeed = 125.0f;
	public GameObject mainObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Q))
		{
			gameObject.transform.RotateAround(mainObject.transform.position, Vector3.up, -rotateSpeed*Time.deltaTime);
		}
		else if(Input.GetKey(KeyCode.E))
		{
			gameObject.transform.RotateAround(mainObject.transform.position, Vector3.up, rotateSpeed*Time.deltaTime);
		}
		
		//Debug.Log(Input.GetAxis("Mouse X"));
		
		//gameObject.transform.RotateAround(mainObject.transform.position, Vector3.up, -rotateSpeed*Time.deltaTime);
	}
}
