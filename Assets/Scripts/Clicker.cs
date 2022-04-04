using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Clicker : MonoBehaviour
{
	bool active = false;
	GameObject note;

	GameManager gm;
	//public int points;
	//public Text pointsText;
	
	void Start ()
	{
		gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
	}	
	void OnMouseDown() {
		if(active && note.tag=="Note") {
			Destroy(note);
			//points++;
			//setPointText();
			gm.Score();
		}
	}            
	public void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag == "Note"){
			note = collision.gameObject;
			active = true;
		}
		if(collision.gameObject.tag == "HoldNote"){
			note = collision.gameObject;
			active = true;
		}
		
		
	}
	
	public void OnTriggerExit2D(Collider2D collision){
		active = false;
	}



	
	
}