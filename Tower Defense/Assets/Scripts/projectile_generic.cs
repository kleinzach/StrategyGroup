using UnityEngine;
using System.Collections;

public class projectile_generic : MonoBehaviour {
	
	public float velocity;
	public float range;
	private float distance;

	// Use this for initialization
	void Start () {
	}
	
	void Update () {		
		transform.Translate(Vector3.forward * velocity * Time.deltaTime);
		distance += Time.deltaTime * velocity;
		if (distance >= range)
			Destroy(gameObject);
	}
}
