using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note1 : MonoBehaviour{

	GameManager gm;
    Rigidbody2D m_rb;
	bool active = false;


	private Shake shake;
	public GameObject RedEplosion;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_rb.velocity = new Vector2(0.0f, -3.0f);
		shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
		Destroy(this.gameObject, 15f);
    }
	
	void Awake(){
		gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
		 }
		 
	void OnMouseDown(){
		gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
        if(active==true){
			Debug.Log("clicked Note");
			shake.CamShake();
			Instantiate(RedEplosion, transform.position, transform.rotation);
			Destroy(gameObject);
            gm.Score();
			}
	}
	
	
	
	
	 public void OnTriggerEnter2D(Collider2D collision){
		// if it is a box collider set to active 
		if(collision.GetType() == typeof(BoxCollider2D)) {
			active = true;
        // Do something for box collider
     }
	 }
    
}
