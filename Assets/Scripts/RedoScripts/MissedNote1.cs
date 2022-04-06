using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedNote1 : MonoBehaviour
{
    GameManager gm;

    void Start()
    {
        gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            gm.Miss();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other);
    }
}
