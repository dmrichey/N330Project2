using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragger : MonoBehaviour{
	public GameObject clickerOne;
	public GameObject clickerTwo;
	public GameObject clickerThree;
	public GameObject clickerFour;
	private Vector3 _dragOffset;
	private Camera cam;
	Rigidbody2D m_rb;
	
	void Awake(){
		 cam = Camera.main;
	}
	void OnMouseDown(){
		_dragOffset = transform.position - GetMousePos();
		m_rb = GetComponent<Rigidbody2D>();
		m_rb.velocity = new Vector2(0.0f, 0.0f);
	}
	void OnMouseDrag(){
		transform.position=GetMousePos()+_dragOffset;
	}
	
	Vector3 GetMousePos(){
		var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z=0;
		return mousePos;	
	}
 
 
 
 
 
}
