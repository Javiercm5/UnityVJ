using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public float rotateSpeed = 125.0f;
	public GameObject mainObject;

	public float initialDist = 1.0f;
	float actualDist;

	Vector3 vec;

	void Start()
	{
		init();
	}

	void Update()
	{
		Screen.lockCursor = true;

		transform.RotateAround(mainObject.transform.position, Vector3.up, Input.GetAxis("Mouse X")*rotateSpeed*Time.deltaTime);

		Vector3 centerMainObject = mainObject.transform.position + Vector3.up*0.125f;
		vec = transform.position - (centerMainObject); vec = Vector3.Normalize(vec);

		RaycastHit hit;
		if(Physics.Raycast(centerMainObject, vec, out hit, initialDist, 1 << 8)) actualDist = hit.distance;

		transform.position = centerMainObject + vec*actualDist;
	}

	public void init()
	{
		Screen.showCursor = false;

		actualDist = initialDist;
		
		vec = new Vector3(0.0f, 0.45f, -1.0f);

		transform.position = mainObject.transform.position + vec*initialDist;
		transform.rotation = Quaternion.Euler(Vector3.zero);
	}
}
