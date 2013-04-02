using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	
	
	public int MaxHealth;
	public Vector3 direction;
	public float speed;
	
	
	private Vector3 currentDirection;
	private Vector3 currentPosition;
	private int health;
	private enum Directions { up, down, right, left };
	private Directions cameFrom;
	private List<GameObject> Waypoints;
	private GameObject FirstWaypoint;
	private Vector3 waypointPosition;
	private GameObject gameMaster;
	
	void Start() {
		health = MaxHealth;
		currentDirection = direction;
		FirstWaypoint = GameObject.FindGameObjectWithTag("FirstWaypoint");
		waypointPosition = FirstWaypoint.transform.position;
		Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		currentPosition = rigidbody.position;
		gameMaster = GameObject.FindGameObjectWithTag("GameMaster");
		
		//Check which direction the enemy should move 
		if(waypointPosition.z > currentPosition.z) {
			currentDirection = new Vector3(0, 0, 1);
		} else if(waypointPosition.z < currentPosition.z) {
			currentDirection = new Vector3(0, 0, -1);
		} else if(waypointPosition.x > currentPosition.x) {
			currentDirection = new Vector3(1, 0, 0);
		} else if(waypointPosition.x < currentPosition.x) {
			currentDirection = new Vector3(-1, 0, 0);
		} else if(waypointPosition.y > currentPosition.y) {
			currentDirection = new Vector3(0, 1, 0);
		} else if(waypointPosition.y < currentPosition.y) {
			currentDirection = new Vector3(0, -1, 0);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		/*var position = this.transform.position;
		if(velocity.y != 0) {
		
			position.y += -velocity.y;
			this.transform.position = position;
		}*/		
	}
	
	void FixedUpdate() {
		var currentPosition = rigidbody.position;
		
		
		
		if(currentDirection.z > 0) {
			cameFrom = Directions.down;
			rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
			if(currentPosition.z >= waypointPosition.z) {
				FindNextWaypointPosition(cameFrom);
			}
		} else if(currentDirection.z < 0) {
			cameFrom = Directions.up;
			rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
			if(currentPosition.z <= waypointPosition.z) {
				FindNextWaypointPosition(cameFrom);
			}
		} else if(currentDirection.x > 0) {
			cameFrom = Directions.left;
			rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
			if(currentPosition.x >= waypointPosition.x) {
				FindNextWaypointPosition(cameFrom);
			}
		} else if(currentDirection.x < 0) {
			cameFrom = Directions.right;
			rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
			if(currentPosition.x <= waypointPosition.x) {
				FindNextWaypointPosition(cameFrom);
			}
		}
		
		//Move the enemy
		var velocity = currentDirection * speed;
    	Vector3 newPosition = currentPosition + (velocity * Time.fixedDeltaTime);
    	rigidbody.MovePosition(newPosition);
		
	}
	
	//Finds the next waypoint by finding waypoints that are in line with the enemy
	//in the direction they should be going and then finds the closest one.
	void FindNextWaypointPosition(Directions cameFrom) {
		var position = waypointPosition;
		float distance = Mathf.Infinity;
		float curDistance = Mathf.Infinity; 
		GameObject nextWaypoint = null;
		
		
		if(cameFrom == Directions.up || cameFrom == Directions.down) {
			foreach (GameObject waypoint in Waypoints) {
				if(waypoint.transform.position.x == position.x) {
					distance = Mathf.Abs(waypoint.transform.position.x - this.transform.position.x);
					if(distance < curDistance) {
						curDistance = distance;
						nextWaypoint = waypoint;
					}
					
				}		
			}	
		} else if(cameFrom == Directions.left || cameFrom == Directions.right) {
			foreach (GameObject waypoint in Waypoints) {
				if(waypoint.transform.position.z == position.z) {
					distance = Mathf.Abs(waypoint.transform.position.z - this.transform.position.z);
					if(distance < curDistance) {
						curDistance = distance;
						nextWaypoint = waypoint;
					}
				}		
			}
		}
		
		waypointPosition = nextWaypoint.transform.position;
		
		//Check which direction the enemy should move 
		if(waypointPosition.z > currentPosition.z) {
			currentDirection = new Vector3(0, 0, 1);
		} else if(waypointPosition.z < currentPosition.z) {
			currentDirection = new Vector3(0, 0, -1);
		} else if(waypointPosition.x > currentPosition.x) {
			currentDirection = new Vector3(1, 0, 0);
		} else if(waypointPosition.x < currentPosition.x) {
			currentDirection = new Vector3(-1, 0, 0);
		} else if(waypointPosition.y > currentPosition.y) {
			currentDirection = new Vector3(0, 1, 0);
		} else if(waypointPosition.y < currentPosition.y) {
			currentDirection = new Vector3(0, -1, 0);
		}
		
	}
	
	/*void OnCollisionEnter(Collision collision) {
		
		print ("before change: " + cameFrom);
		if(cameFrom == Directions.up) {
			if(checkDirection(Directions.right)) {
				currentDirection = new Vector3(1, 0, 0);
				cameFrom = Directions.left;
				print("After change: " + cameFrom);
			} else
			if(checkDirection(Directions.left)) {
				currentDirection = new Vector3(-1, 0, 0);
				cameFrom = Directions.right;
				print("After change: " + cameFrom);
			}
		} else 
		if(cameFrom == Directions.down) {
			if(checkDirection(Directions.right)) {
				currentDirection = new Vector3(1, 0, 0);
				cameFrom = Directions.left;
				print("After change: " + cameFrom);
			} else
			if(checkDirection(Directions.left)) {
				currentDirection = new Vector3(-1, 0, 0);
				cameFrom = Directions.right;
				print("After change: " + cameFrom);
			}	
		} else 
		if(cameFrom == Directions.left) {
			if(checkDirection(Directions.up)) {
				currentDirection = new Vector3(0, 1, 0);
				cameFrom = Directions.down;
				print("After change: " + cameFrom);
			} else
			if(checkDirection(Directions.down)) {
				currentDirection = new Vector3(0, -1, 0);
				cameFrom = Directions.up;
				print("After change: " + cameFrom);
			}
		} else 
		if(cameFrom == Directions.right) {
			if(checkDirection(Directions.up)) {
				currentDirection = new Vector3(0, 1, 0);
				cameFrom = Directions.down;
				print("After change: " + cameFrom);
			} else
			if(checkDirection(Directions.down)) {
				currentDirection = new Vector3(0, -1, 0);
				cameFrom = Directions.up;
				print("After change: " + cameFrom);
			}
		}	
	}
	
	bool checkDirection(Directions check_this) {
		GameObject closestWall = getClosestWall();
		bool open = false;
		if(check_this == Directions.up) {
			if(closestWall.transform.position.y > transform.position.y) {
				open = false;
			} else { open = true; }
			
		} else if(check_this == Directions.down) {
			if(closestWall.transform.position.y < transform.position.y) {
				open = false;
			} else { open = true; }
			
		} else if(check_this == Directions.right) {
			if(closestWall.transform.position.x > transform.position.x) {
				open = false;
			} else { open = true; }
			
		} else if(check_this == Directions.left) {
			if(closestWall.transform.position.x < transform.position.x) {
				open = false;
			} else { open = true; }
			
		}
		
		return open;
	}
	
	GameObject getClosestWall() {
		GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject wall in Walls) {
            Vector3 diff = wall.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = wall;
                distance = curDistance;
            }
        }
        return closest;	
	}*/
	
	//Decreases health of the enemy and checks to see if it's dead.
	void GotHit(int damage) {
		health = health - damage;
		if(health <= 0) {
			gameMaster.SendMessage("UpdateScore");
			Destroy(this.gameObject);
		}
	}

}