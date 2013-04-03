using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyFactory : MonoBehaviour {
	
	// The singleton of the EnemyFactory.
	public static EnemyFactory Instance;
	
	//Each type of Enemy
	public GameObject fireEnemy;
	public GameObject waterEnemy;
	public GameObject windEnemy;
	public GameObject earthEnemy;
	
	//The alive and dead lists for each enemy type.
	private List<GameObject> liveFire = new List<GameObject>();
	private List<GameObject> deadFire = new List<GameObject>();
	
	private List<GameObject> liveWater = new List<GameObject>();
	private List<GameObject> deadWater = new List<GameObject>();
	
	private List<GameObject> liveWind = new List<GameObject>();
	private List<GameObject> deadWind = new List<GameObject>();
	
	private List<GameObject> liveEarth = new List<GameObject>();
	private List<GameObject> deadEarth = new List<GameObject>();
	
	// Use this for initialization
	void Start () {
		Instance = this;
	}

	//Makes a new Fire enemy
	public GameObject newFireEnemy(){
		GameObject newEnemy;
		if(deadFire.Count < 1){
			newEnemy = (GameObject)Instantiate(fireEnemy, Vector3.zero, Quaternion.identity);
		}
		else{
			newEnemy = deadFire[0];
			deadFire.RemoveAt(0);
		}
		liveFire.Add (newEnemy);
		return newEnemy;
	}
	//Makes a new Water enemy
	public GameObject newWaterEnemy(){
		GameObject newEnemy;
		if(deadWater.Count < 1){
			newEnemy = (GameObject)Instantiate(waterEnemy, Vector3.zero, Quaternion.identity);
		}
		else{
			newEnemy = deadWater[0];
			deadFire.RemoveAt(0);
		}
		liveWater.Add (newEnemy);
		return newEnemy;		
	}
	//Makes a new Wind enemy
	public GameObject newWindEnemy(){
		GameObject newEnemy;
		if(deadWind.Count < 1){
			newEnemy = (GameObject)Instantiate(windEnemy, Vector3.zero, Quaternion.identity);
		}
		else{
			newEnemy = deadWind[0];
			deadWind.RemoveAt(0);
		}
		liveWind.Add (newEnemy);
		return newEnemy;		
	}
	//Makes a new Earth enemy
	public GameObject newEarthEnemy(){
		GameObject newEnemy;
		if(deadEarth.Count < 1){
			newEnemy = (GameObject)Instantiate(earthEnemy, Vector3.zero, Quaternion.identity);
		}
		else{
			newEnemy = deadEarth[0];
			deadEarth.RemoveAt(0);
		}
		liveEarth.Add (newEnemy);
		return newEnemy;
	}
	
	//Recycle used enemies
	IEnumerator recycle(float delay){
		while(true){
			yield return new WaitForSeconds(delay);
			for(int i = liveFire.Count; i >= 0; i--){
				if(!liveFire[i].activeSelf){
					deadFire.Add(liveFire[i]);
					liveFire.RemoveAt(i);
				}
			}
			for(int i = liveWater.Count; i >= 0; i--){
				if(!liveWater[i].activeSelf){
					deadWater.Add(liveWater[i]);
					liveWater.RemoveAt(i);
				}
			}
			for(int i = liveWind.Count; i >= 0; i--){
				if(!liveWind[i].activeSelf){
					deadWind.Add(liveWind[i]);
					liveWind.RemoveAt(i);
				}
			}
			for(int i = liveEarth.Count; i >= 0; i--){
				if(!liveEarth[i].activeSelf){
					deadEarth.Add(liveEarth[i]);
					liveEarth.RemoveAt(i);
				}
			}
		}
	}
	
}
