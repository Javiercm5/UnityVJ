using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {

	public float life = 5;
	// Use this for initialization
	void Start () {
		life = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(life <= 0.0f){
			Destroy(gameObject);
		}
	}
}
