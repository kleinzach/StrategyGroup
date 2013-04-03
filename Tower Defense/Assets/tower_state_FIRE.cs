using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tower_state_FIRE : MonoBehaviour {
	
	public GameObject projectile;
	public float reloadTime;
	public float turnRate;	
	public List<Transform> targets = new List<Transform> (); 
	public Transform targetEnemy;
	public Transform towerBall;
	public Transform barrelEnd;
	
	private Quaternion desiredRotation;
	private double timeToNextFire;
	
	// Called on start up
	void Start () {
		AddTarget(GameObject.FindGameObjectWithTag("Enemy").transform);
		targetEnemy = targets[0];
	}
	
	// Update is called once per frame
	void Update () {				
		if (targetEnemy) {
			CalculateAim(targetEnemy.position);
			towerBall.rotation = Quaternion.Lerp (towerBall.rotation, desiredRotation, turnRate * Time.deltaTime);
			
			if (Time.time >= timeToNextFire)
				FireProjectile();
		}
		
		if (targets.Count == 0) {		
			this.GetComponent<tower_state_IDLE>().enabled = true;
			this.GetComponent<tower_state_FIRE>().enabled = false;		
		}
	}
	
	// Aims the tower at the targeted enemy
	void CalculateAim (Vector3 targetPOS) {
		Vector3 aimPoint = targetPOS - transform.position;
		desiredRotation = Quaternion.LookRotation(aimPoint);
	}
	
	// Fires a projectile
	void FireProjectile () {
		audio.Play();
		timeToNextFire = Time.time + reloadTime;
		Instantiate(projectile, barrelEnd.position, barrelEnd.rotation);		
	}
	
	// Adds an enemy to the end of the list of targets
	void AddTarget (Transform enemy) {
		targets.Add(enemy);
	}
	
	// Removes an enemy from the list of targets
	void RemoveTarget (Transform enemy) {
		targets.Remove(enemy);
	}
	
	// When an enemy enters range it is added to the target list
	void OnTriggerEnter (Collider enemy) {
		if (enemy.CompareTag("Enemy")) {
			//timeToNextFire = Time.time + (reloadTime * .5);
			AddTarget(enemy.gameObject.transform);
			targetEnemy = targets[0];
		}
	}
	
	// When an enemy exits range it is removed from the target list
	void OnTriggerExit (Collider enemy) {
		if (enemy.gameObject.transform == targetEnemy) {
			RemoveTarget(enemy.gameObject.transform);
			targetEnemy = targets[0];
		}
	}
}
