using UnityEngine;
using System.Collections;

public class tower_state_IDLE : MonoBehaviour {
	
	void OnTriggerEnter (Collider enemy) {
		if (enemy.CompareTag("Enemy")) {
			GetComponent<tower_state_FIRE>().enabled = true;
			GetComponent<tower_state_IDLE>().enabled = false;
		}
	}
}
