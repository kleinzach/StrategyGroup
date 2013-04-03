using UnityEngine;
using System.Collections;

public class Waypoint_script : MonoBehaviour {
	
	private enum Directions { up, down, right, left };
	private Directions cameFrom;
	private GameObject[] Waypoints;
	
	// Use this for initialization
	void Start () {
		Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	Vector3 getWaypointPosition() {
		return this.transform.position;
	}
	
	Vector3 FindNextWaypointPosition(Directions cameFrom) {
		var position = this.transform.position;
		GameObject nextWaypoint = null;
		
		
		if(cameFrom == Directions.up || cameFrom == Directions.down) {
			foreach (GameObject waypoint in Waypoints) {
				if(waypoint.transform.position.y == position.y) {
					nextWaypoint = waypoint;
				}		
			}	
		} else if(cameFrom == Directions.left || cameFrom == Directions.right) {
			foreach (GameObject waypoint in Waypoints) {
				if(waypoint.transform.position.x == position.x) {
					nextWaypoint = waypoint;
				}		
			}
		}
		return nextWaypoint.transform.position;
	}
}
