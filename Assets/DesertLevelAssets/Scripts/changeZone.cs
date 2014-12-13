using UnityEngine;
using System.Collections;

public class changeZone : MonoBehaviour
{
	public GameObject player;
	public GameObject camera;
	CameraController cController;

	public GameObject zone0;
	public GameObject zone1;
	public GameObject zone2;
	public GameObject zone3;
	public GameObject zone4;

	void Start()
	{
		cController = camera.GetComponent<CameraController>();
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.Alpha0))
		{
			player.transform.position = zone0.transform.position;
			player.transform.rotation = zone0.transform.rotation;
			cController.init();

		}
		else if(Input.GetKey(KeyCode.Alpha1))
		{
			player.transform.position = zone1.transform.position;
			player.transform.rotation = zone1.transform.rotation;
			cController.init();
		}
		else if(Input.GetKey(KeyCode.Alpha2))
		{
			player.transform.position = zone2.transform.position;
			player.transform.rotation = zone2.transform.rotation;
			cController.init();
		}
		else if(Input.GetKey(KeyCode.Alpha3))
		{
			player.transform.position = zone3.transform.position;
			player.transform.rotation = zone3.transform.rotation;
			cController.init();
		}
		else if(Input.GetKey(KeyCode.Alpha4))
		{
			player.transform.position = zone4.transform.position;
			player.transform.rotation = zone4.transform.rotation;
			cController.init();
		}
	}
}
