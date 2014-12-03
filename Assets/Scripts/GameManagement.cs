using UnityEngine;
using System.Collections;

public class GameManagement : MonoBehaviour
{
	public GameObject player;

	// Use this for initialization
	void Start()
	{}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Escape)) Application.Quit(); // En l'editor no funciona
	}
}
