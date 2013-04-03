using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FactoryLoader : MonoBehaviour {
	
	public GameMaster gm;
	public GameObject enemy;
	
	// Use this for initialization
	void Start () {
		gm.factory.newFactory("enemy", enemy);
	}
}
