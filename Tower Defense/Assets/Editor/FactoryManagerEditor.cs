using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(FactoryManager))]
public class FactoryManagerEditor : Editor {
	
	FactoryManager m;
	
	void OnEnable(){
		m = (FactoryManager)target;	
	}
	
	public override void OnInspectorGUI(){
		m.recycleDelay = EditorGUILayout.FloatField("Recycle Delay",m.recycleDelay);
		m.initialSize = EditorGUILayout.IntField("# Of Factories",m.initialSize);
		
		if (m.initialSize != m.initalFactories.Length){
			GameObject[] newArray = new GameObject[m.initialSize];
			for(int i = 0; i < newArray.Length && i < m.initalFactories.Length; i++){
				newArray[i]	= m.initalFactories[i];
			}
			m.initalFactories = newArray;
		}
		
		for(int i = 0; i < m.initalFactories.Length; i++){
			m.initalFactories[i] = (GameObject)EditorGUILayout.ObjectField("Factory "+i,m.initalFactories[i],typeof(GameObject),true);
		}
	}
}
