using UnityEngine;
using System.Collections.Generic;

public class enemy : MonoBehaviour {
	
	
	public int MaxHealth;
	public float speed;
	public int numberOfWaypoints;
	
	
	private int health;
	private GameObject[] Waypoints;
	private GameObject currentWaypoint;
	private GameObject gameMaster;
	private int waypointNumber;
	
	void Start() {
		health = MaxHealth;
		Waypoints = new GameObject[numberOfWaypoints];
		for(int i = 0; i < numberOfWaypoints; i++) {
			Waypoints[i] = GameObject.Find ("Waypoint " + i);
		}
		currentWaypoint = Waypoints[0];
		waypointNumber = 0;
		gameMaster = GameObject.FindGameObjectWithTag("GameMaster");
		
	}
	
	
	void FixedUpdate() {
		MoveToWaypoint(currentWaypoint);
	}
	
	//Moves the enemy to the waypoint.
	void MoveToWaypoint(GameObject waypoint) {
		rigidbody.position = Vector3.MoveTowards(rigidbody.position, waypoint.transform.position, speed*Time.deltaTime);
		print("Waypoint " + waypointNumber + ": " + currentWaypoint.transform.position);
		if(waypointReached(currentWaypoint)) {
			if(waypointNumber == (numberOfWaypoints - 1)) {
				Destroy(this.gameObject);
				gameMaster.SendMessage("EnemyReachedGoal");
			} else FindNextWaypoint();	
		}
			
	}	
	
	
	//Checks to see if the enemy is at the waypoint.
	bool waypointReached(GameObject waypoint) {
		if (Mathf.Abs (this.transform.position.x - waypoint.transform.position.x) <=.1 && Mathf.Abs (this.transform.position.z - waypoint.transform.position.z) <=.1 && Mathf.Abs (this.transform.position.y - waypoint.transform.position.y) <=.1) {
			this.transform.position.Set(waypoint.transform.position.x, waypoint.transform.position.y, waypoint.transform.position.z);
			return true;
		}
		else { 
			return false;
		}
	}
	
	
	//Finds the next waypoint.
	void FindNextWaypoint() {	
		waypointNumber = waypointNumber + 1;
		GameObject nextWaypoint = Waypoints[waypointNumber];
		currentWaypoint = nextWaypoint;
	}
	
	
	//Decreases health of the enemy and checks to see if it's dead.
	void GotHit(int damage) {
		health = health - damage;
		if(health <= 0) {
			gameMaster.SendMessage("UpdateScore");
			Destroy(this.gameObject);
		}
	}
}