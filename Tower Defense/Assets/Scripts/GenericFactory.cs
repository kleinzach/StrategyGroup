using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//A Generic Factory, to be held in the Factory Manager
public class GenericFactory : ScriptableObject{
	
	public GameObject product;
	public float delay;
	
	private List<GameObject> aliveList = new List<GameObject>();
	private List<GameObject> deadList = new List<GameObject>();
	
	public GenericFactory(GameObject toProduce, float recycleDelay){
		this.product = toProduce;
		this.delay = recycleDelay;
		//SendMessage("recycle",delay);
	}
	
	//Creates and returns the product.
	public GameObject create(){
		
		GameObject newProduct = GameObject.CreatePrimitive(PrimitiveType.Cube);

		if(deadList.Count < 1){
			newProduct = (GameObject)Instantiate(product, Vector3.zero, Quaternion.identity);
		}
		else{
			newProduct = deadList[0];
			deadList.RemoveAt(0);
		}
		aliveList.Add(newProduct);
		if(newProduct == null){
			newProduct = GameObject.CreatePrimitive(PrimitiveType.Cube);	
		}
		newProduct.SetActive(true);
		return newProduct;
	}
	
	/// <summary>
	/// Recycle now dead objects after the specified delay.
	/// </summary>
	/// <param name='delay'>
	/// The Delay between sweeps.
	/// </param>
	/// 
	/*
	IEnumerator recycle(float delay){
		while(true){
			yield return new WaitForSeconds(delay);
			for(int i = aliveList.Count; i >= 0; i--){
				if(!aliveList[i].activeSelf){
					deadList.Add(aliveList[i]);
					aliveList.RemoveAt(i);
				}
			}
		}
	}*/
}
