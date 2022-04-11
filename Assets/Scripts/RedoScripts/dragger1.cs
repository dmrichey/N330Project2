using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragger1 : MonoBehaviour{
	public GameObject clickerOne;
	public GameObject clickerTwo;
	public GameObject clickerThree;
	public GameObject clickerFour;
	bool active = false;
	//bool mouseDown = false;
	private Vector3 _dragOffset;
	private Camera cam;
	Rigidbody2D m_rb;
	GameManager gm;

	private Shake shake;

	public GameObject BlackExplosion;
	
	void Start (){
		shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
		m_rb = GetComponent<Rigidbody2D>();
        m_rb.velocity = new Vector2(0.0f, -3.0f);
    }
	void Awake(){
		//gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
		cam = Camera.main;
	}
	
	void OnMouseOver(){
		//gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
		if(Input.GetMouseButton(0) && active == true){
			Instantiate(BlackExplosion, transform.position, transform.rotation);
			shake.CamShake();
			Destroy(gameObject);
            gm.Score();
		}
	}

	Vector3 GetMousePos(){
		var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		return mousePos;	
	}
	
	
	public void OnTriggerEnter2D(Collider2D collision){
		// if it is a box collider set to active 
		if(collision.GetType() == typeof(BoxCollider2D)) {
			active = true;
        // Do something for box collider
		}
	 
	}
	
}
	
 
 
 
 
 

