using UnityEngine;
using System.Collections;

public class rockGenerator : MonoBehaviour
{
	public GameObject rock;

	float count = 0.0f;
	public float finCount = 0.6f;

	public float minForce = 10.5f;
	public float maxForce = 13.5f;

	void Start()
	{}

	void Update()
	{
		count += Time.deltaTime;
		if(count >= finCount)
		{
			count = 0.0f;

			GameObject rockI = (GameObject)Instantiate(rock, transform.position, Random.rotation);
			rockI.GetComponent<Rigidbody>().AddForce((new Vector3(Random.Range(-1.0f, 1.0f), 1.0f, Random.Range(-1.0f, 1.0f)))*Random.Range(minForce, maxForce), ForceMode.Impulse);
		}
	}
}
