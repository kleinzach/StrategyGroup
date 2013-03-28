using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	
<<<<<<< HEAD
	public int horizVelocity;							// The horizontal velocity of the enemy
	public float x_high;								// The upper limit of the enemy's movement
	public float x_low;									// The lower limit of the enemy's movement
	public bool movingRight = true;						// Is the enemy moving right?
	public int vertVelocity;							// the vertical velocity of the enemy
	public float y_high;								// the upper limit of the enemy's movement	
	public float y_low;									// the lower limit of the enemy's movement
	public bool movingUp = true;						// is the enemy moving up?
	public int hitsTilDead;
	
	// Update is called once per frame
	void Update () {
	
	// Horizontal Movement		
		// If the platform is below the right limit and is moving right, it moves right
		if (transform.position.x < x_high && movingRight)
			transform.Translate(horizVelocity * Time.deltaTime, 0, 0);
		
		// If the platform is above the lower limit and is not moving right, it moves left
		if (transform.position.x > x_low && !movingRight)
			transform.Translate(-horizVelocity * Time.deltaTime, 0, 0);			
		
		// At the limits, movingRight is switched
		if (transform.position.x >= x_high || transform.position.x <= x_low)
			movingRight = !movingRight;
		
	//Vertical movement
		// If the platform is below the lower limit and is moving up, it moves up
		if (transform.position.y < y_high && movingUp)
			transform.Translate(0, vertVelocity * Time.deltaTime, 0);
		
		// If the platform is above the bottom limit and is not moving up, it moves down
		if (transform.position.y > y_low && !movingUp)
			transform.Translate(0, -vertVelocity * Time.deltaTime, 0);
		
		// At the limits movingUp is switched
		if (transform.position.y >= y_high || transform.position.y <= y_low)
			movingUp = !movingUp;
		
	// Enemy has been destroyed	
		if (hitsTilDead <= 0)
			Destroy (gameObject);	
=======
	
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
>>>>>>> 027ca5780b294a91c4b83b7ee5a9d6dc631ad548
	}
	
	void FixedUpdate() {
		
		var velocity = currentDirection * speed;
		var currentPosition = rigidbody.position;
    	Vector3 newPosition = currentPosition + (velocity * Time.fixedDeltaTime);
    	rigidbody.MovePosition(newPosition);
		
		
		if(currentDirection.y > 0) {
			cameFrom = Directions.down;
			rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
		} else if(currentDirection.y < 0) {
			cameFrom = Directions.up;
			rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
		} else if(currentDirection.x > 0) {
			cameFrom = Directions.left;
			rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
		} else if(currentDirection.x < 0) {
			cameFrom = Directions.right;
			rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
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
	
	void GotHit(int damage) {
		health = health - damage;
		if(health <= 0) {
			SendMessage("UpdateScore");
			Destroy();
		}
	}

}
