using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragger : MonoBehaviour{
	public GameObject clickerOne;
	public GameObject clickerTwo;
	public GameObject clickerThree;
	public GameObject clickerFour;
	
	void OnMouseDrag(){
		transform.position=GetMousePos();
	}
	
	Vector3 GetMousePos(){
		var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z=0;
		return mousePos;	
	}
 
 
 
 
 
}
