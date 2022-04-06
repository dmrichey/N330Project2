using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragger : MonoBehaviour{
	public GameObject clickerOne;
	public GameObject clickerTwo;
	public GameObject clickerThree;
	public GameObject clickerFour;
	bool active = false;
	private Vector3 _dragOffset;
	private Camera cam;
	Rigidbody2D m_rb;
	GameManager gm;
	
	void Start (){
        gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
    }
	void Awake(){
		gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
		 cam = Camera.main;
	}
	void OnMouseDown(){
		if (active == true){
		gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
		_dragOffset = transform.position - GetMousePos();
		m_rb = GetComponent<Rigidbody2D>();
		m_rb.velocity = new Vector2(0.0f, 0.0f);
		}
	}
	void OnMouseDrag(){
		if (active == true){
		transform.position=GetMousePos()+_dragOffset;
		}
	}
	
	Vector3 GetMousePos(){
		var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z=0;
		return mousePos;	
	}
	
	
	 public void OnTriggerEnter2D(Collider2D collision){
		// if it is a box collider set to active 
		if(collision.GetType() == typeof(BoxCollider2D)) {
			active = true;
        // Do something for box collider
     }
	 if(collision.GetType() == typeof(CircleCollider2D)){
		 Destroy(gameObject);
		 Destroy(collision.gameObject);
		 gm.Score();
		 gm.Score();
		 gm.setPrevious("Note");
		// if it is a circle collider, then it is another note, delte both notes and do score()twice!		
	}
	
	
	}
	
}
	
 
 
 
 
 

