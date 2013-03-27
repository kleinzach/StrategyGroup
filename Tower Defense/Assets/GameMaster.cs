using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	public int gridWidth = 20;
	public int gridHeight = 10;
	
	private bool[,] grid;
	
	// Use this for initialization
	void Start () {
		grid = new bool[gridWidth,gridHeight];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}
	
	public bool placeTower(int x, int y, GameObject towerToPlace){
		bool canPlace = true;
		canPlace &= (-gridWidth/2 <= x) && (x <= gridWidth/2);
		canPlace &= (-gridHeight/2 <= y) && (x  <= gridHeight/2);
		Debug.Log (x + " " + y);
		if(canPlace){
			canPlace &= (grid[x + gridWidth/2,y + gridHeight/2] == false);
		}
		if(canPlace){
			GameObject newTower = (GameObject) Instantiate(towerToPlace,new Vector3(x,y,0),transform.rotation);	
			grid[x + gridWidth/2,y + gridHeight/2] = true;
		}
		return canPlace;
	}
}
