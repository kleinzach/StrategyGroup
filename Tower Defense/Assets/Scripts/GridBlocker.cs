using UnityEngine;
using System.Collections;

//hwe2
/// <summary>
/// Grid blockers mark where Towers cant be placed within the grid, for clearing enemy movement paths.
/// </summary>
public class GridBlocker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 startPosition = this.transform.position;
		this.transform.position = new Vector3(Mathf.Round(startPosition.x),0,Mathf.Round(startPosition.z));
	}

}
