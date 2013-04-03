using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tower_range : MonoBehaviour {
	
	public List<GameObject> targets;
	public GameObject priorityEnemy;

	// Use this for initialization
	void Start () {
		priorityEnemy = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Sets the priority target to the first element of the list of potential targets
	public GameObject TargetPriorityEnemy () {
		return priorityEnemy = targets[0];
	}
	
	// Adds an enemy to the end of the list of targets
	void AddTarget (GameObject enemy) {
		targets.Add(enemy);
	}
	
	// Removes an enemy from the list of targets
	void RemoveTarget (GameObject enemy) {
		targets.Remove(enemy);
	}
	
	// When an enemy enters range it is added to the target list
	void OnTriggerEnter (Collider enemy) {
		if (enemy.gameObject.tag == "Enemy")
			AddTarget(enemy.gameObject);						
	}
	
	// When an enemy exits range it is removed from the target list
	void OnTriggerExit (Collider enemy) {
		if (enemy.gameObject.tag == "Enemy") 
			RemoveTarget(enemy.gameObject);
	}
	
	// Sets the state of the tower to IDLE or FIRE based on whether there are enemies within range
	void SetTowerState () {
		if (targets.Count == 0) {
			this.GetComponent<tower_state_FIRE>().enabled = false;
			this.GetComponent<tower_state_IDLE>().enabled = true;
		}
		
		else {
			this.GetComponent<tower_state_FIRE>().enabled = true;
			this.GetComponent<tower_state_IDLE>().enabled = false;
		}
	}
}
