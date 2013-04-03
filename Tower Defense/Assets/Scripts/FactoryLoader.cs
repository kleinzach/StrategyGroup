using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FactoryLoader : MonoBehaviour {
	
	public GameMaster gm;
	public GameObject tower;
	public GameObject fireEnemy;
	public GameObject waterEnemy;
	public GameObject earthEnemy;
	public GameObject windEnemy;
	
	// Use this for initialization
	void Start () {
		gm.factory.newFactory("Tower",tower);
		gm.factory.newFactory("fireEnemy", fireEnemy);
		
	}
}
