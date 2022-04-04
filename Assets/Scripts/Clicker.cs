using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
	public KeyCode key;
	bool active = false;
	GameObject note;
	
    void Start()
    {
        
    }

    public void Update()
    {
		if(Input.GetKeyDown(key) && active){
			Destroy(note);
		}        
    }
	
	public void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag =="Note"){
		note = collision.gameObject;
		active = true;
		}
	}
	
	 public void OnTriggerExit2D(Collider2D collision){
		active = false;
	}
}
