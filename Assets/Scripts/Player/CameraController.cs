using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public float rotateSpeed = 125.0f;
	public GameObject mainObject;

	void Start()
	{
		Screen.showCursor = false;
	}

	void Update()
	{
		Screen.lockCursor = true;
		gameObject.transform.RotateAround(mainObject.transform.position, Vector3.up, Input.GetAxis("Mouse X")*rotateSpeed*Time.deltaTime);
	}
}
