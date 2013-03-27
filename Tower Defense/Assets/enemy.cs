using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	
	public int hitsTilDead;
	
	// Update is called once per frame
	void Update () {
		if (hitsTilDead <= 0)
			Destroy (gameObject);	
	}
	
	void GotHit () {
		hitsTilDead--;
	}
}
