using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] noteTypes;

    // constant .5 seconds for now, adjust per note
    float m_spawnDelay = 0.5f;
    float m_spawnTimer = 0.0f;

    int randNote;
    int randPoint;

    void Update()
    {
        m_spawnTimer += Time.deltaTime;

        if (m_spawnTimer >= m_spawnDelay)
        {
            randNote = Random.Range(0, noteTypes.Length);
            randPoint = Random.Range(0, spawnPoints.Length);

            // Spawn Note
            Instantiate(noteTypes[randNote], spawnPoints[randPoint]);
            // Reset Timer
            m_spawnTimer = 0.0f;
        }
    }
}
