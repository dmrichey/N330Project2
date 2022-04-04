using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] noteTypes;
    // constrain 60 to 180
    public float bpm = 120.0f;
    
    float tempo;
    float m_spawnDelay = 1.0f;
    float m_spawnTimer = 0.0f;

    int curNoteType;
    int curNoteLength;
    float[] noteLengthOptions = { .5f, 1.0f, 1.5f, 2.0f };
    float noteDuration;
    int randPoint;
    int notesUntilTap = 0;


    void Start()
    {
        tempo = 60.0f / bpm;
    }

    void Update()
    {
        m_spawnTimer += Time.deltaTime;

        if (m_spawnTimer >= m_spawnDelay)
        {
            if (notesUntilTap <= 0)
            {
                curNoteType = 0;
                notesUntilTap = Random.Range(0, 16);
            } else
            {
                curNoteType = 1;
                notesUntilTap -= 1;
            }
            randPoint = Random.Range(0, spawnPoints.Length);

            // Spawn Note
            Instantiate(noteTypes[curNoteType], spawnPoints[randPoint]);
            // Reset Timer
            curNoteLength = Random.Range(0, noteLengthOptions.Length);
            noteDuration = noteLengthOptions[curNoteLength] * tempo;
            m_spawnDelay = noteDuration;
            m_spawnTimer = 0.0f;
        }
    }
}
