using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour{
    bool active = false;
    GameObject note;
	GameObject holdNote;
    string previous= "Note";
    GameManager gm;
        
    void Start (){
        gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
    }     
        // *if it is a normaL blue note and the previous one is a normal note then it can just be clicked
        // *if the previous was a hold note, then the hold note has to be in the hitbox at the same time the note is for it to count, will be 2 points so do score() twice.
        // *if it is a holdnote and the previous one is normal, then it needs to be grabbed, dont do score just make it draggable.
        // *if the previous was a hold note, then they both go away score() twice.
        
    void OnMouseDown(){
		gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
        if(active && note.tag=="Note"){
			Debug.Log("clicked Note");
			Debug.Log(string.Format("previous = {0}", previous));
			// Note->Note if the previous note was a normal note, then it just can be clicked and scored by itself
            if (previous == "Note"){
			Destroy(note);
            gm.Score();
            gm.setPrevious("Note"); 
			}// end  inner if 
			/* the other cases will be handeled in the dragger script, because all other combos require
			a collision from another note */
	}}
        
        /* when a new note enters any of the 4 hitboxes,
        it updates with the previous note clicked from the gm */
		
    public void OnTriggerEnter2D(Collider2D collision){
		// it will get previous from gm everytime something collides with any of the 4 hitboxes.
		previous = gm.getPrevious();
        if(collision.gameObject.tag == "Note"){
            note = collision.gameObject;
            active = true;
			
        }if(collision.gameObject.tag == "HoldNote"){
            active = true;
        }
    }
        
    public void OnTriggerExit2D(Collider2D collision){
        active = false;
    }
}