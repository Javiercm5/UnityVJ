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
		//gameObject.transform.RotateAround(mainObject.transform.position, -Vector3.right, Input.GetAxis("Mouse Y")*rotateSpeed*Time.deltaTime);


		/*
		//Debug.Log (Vector3.Distance (mainObject.transform.position, transform.position));

		Debug.DrawRay(mainObject.transform.position, -mainObject.transform.position + transform.position, Color.green, 1.0f);

		RaycastHit hit;
		if(Physics.Raycast(mainObject.transform.position, -mainObject.transform.position + transform.position, out hit, Vector3.Distance(mainObject.transform.position, transform.position)))
		{
			float distanceToWall = hit.distance;

			Vector3 ei = -(-mainObject.transform.position + transform.position)*distanceToWall;

			transform.position += ei;

			//Debug.DrawRay(hit.point, hit.normal, Color.green);
			//Debug.DrawRay(hit.point, transform.forward, Color.green, 1.0f);

			//transform.Translate(transform.forward*( - distanceToWall));

			//transform.position = Vector3.Lerp(mainObject.transform.position, transform.position, distanceToWall/Vector3.Distance(mainObject.transform.position, gameObject.transform.position));

			//transform.position -= dist;

			//transform.position += 0.01f*transform.forward;
			//transform.LookAt(mainObject.transform.position);

			//transform.position = Vector3.Lerp(transform.position, -transform.forward, );
			//transform.LookAt(mainObject.transform.position);

			//Debug.Log(distanceToWall);

			//Debug.Log (hit.collider.name);
		}
		*/
	}
}
