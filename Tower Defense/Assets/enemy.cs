using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	
	public int hitsTilDead;
	public int MaxHealth;
	public Vector3 direction;
	public float speed;
	public GameObject[] Walls;
	
	private Vector3 currentDirection;
	private int health;
	private enum Directions { up, down, right, left };
	private Directions cameFrom;
	
	void Start() {
		health = MaxHealth;
		currentDirection = direction;
		Walls = GameObject.FindGameObjectsWithTag("Wall");
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
		
		var velocity = currentDirection * speed;
		var currentPosition = rigidbody.position;
    	Vector3 newPosition = currentPosition + (velocity * Time.fixedDeltaTime);
    	rigidbody.MovePosition(newPosition);
		
		
		if(currentDirection.y > 0) {
			cameFrom = Directions.down;
		} else if(currentDirection.y < 0) {
			cameFrom = Directions.up;
		} else if(currentDirection.x > 0) {
			cameFrom = Directions.left;
		} else if(currentDirection.x < 0) {
			cameFrom = Directions.right;
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		
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
	}
	void GotHit (int damage) {
		health = health - damage;
		hitsTilDead--;
	}

}