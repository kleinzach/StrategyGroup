using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class tower_state_FIRE : MonoBehaviour {
	
	public GameObject projectile;
	public float reloadTime;
	public float turnRate;	
	public List<Transform> targets; 
	public Transform targetEnemy;
	public Transform towerBall;
	public Transform barrelEnd;
	
	private Quaternion desiredRotation;
	private double timeToNextFire;
	private float projVel;
	
	// Called on start up
	void Start () {
		targets = new List<Transform>();		
		projVel = projectile.GetComponent<projectile_generic>().velocity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		try{
			targetEnemy = targets[0];
		}
		catch(ArgumentOutOfRangeException e){
			
		}
		if (targetEnemy) {
			CalculateAim(targetEnemy.position);
			towerBall.rotation = Quaternion.Lerp (towerBall.rotation, desiredRotation, turnRate * Time.fixedDeltaTime);
			
			if (Time.time >= timeToNextFire)
				FireProjectile();
		}
					
		else if (targets.Count == 0) {		
			targetEnemy = null;
			towerBall.rotation.SetLookRotation(new Vector3(0, 0, 0));
		}
	}
	
	// Calculates appropriate aim position for the input enemy
	void CalculateAim (Vector3 targetPOS) {		
		Vector3 aimPoint = targetPOS - transform.position;
		aimPoint += aimPoint.magnitude * targetEnemy.rigidbody.velocity / projVel;
		desiredRotation = Quaternion.LookRotation(aimPoint);
	}
	
	Vector3 CalculateIntercept (Vector3 turretPOS, float projVelocity, Vector3 targetPOS, Vector3 targetVel) {
		float t = CalculateInterceptTime (projVelocity, targetPOS - turretPOS, targetVel);
		return targetPOS + t * targetVel;
	}
	
	float CalculateInterceptTime (float projVel, Vector3 targetRelativePOS, Vector3 targetVel) {
		float velocitySq = targetVel.sqrMagnitude;
		//if (velocitySq < 0.001)
			return 0.0f;
		
	}
	
	// Fires a projectile
	void FireProjectile () {
		audio.Play();
		timeToNextFire = Time.time + reloadTime;
		Instantiate(projectile, barrelEnd.position, barrelEnd.rotation);		
	}
	
	// When an enemy enters range it is added to the target list
	void OnTriggerEnter (Collider enemy) {
		if (enemy.CompareTag("Enemy")) {
			timeToNextFire = Time.time + (reloadTime * .5);
			if (!targets.Contains(enemy.gameObject.transform))
				targets.Add(enemy.gameObject.transform);		
			targetEnemy = targets[0];
		}
	}
	
	// When an enemy exits range it is removed from the target list
	void OnTriggerExit (Collider enemy) {
		if (enemy.gameObject.transform == targetEnemy) {
			targets.RemoveAt(0);
			targetEnemy = null;
		}
	}
}
