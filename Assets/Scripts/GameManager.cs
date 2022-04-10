using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] noteTypes;
    public Text scoreText;
    public Text streakText;
    public Text missedText;
    public GameObject loseScreen;
	
	// constrain 60 to 120
    public float bpm = 90.0f;
    
    float tempo;
    float m_spawnDelay = 1.0f;
    float m_spawnTimer = 0.0f;

    int curNoteType;
    int curNoteLength;
    float[] noteLengthOptions = { .5f, 1.0f, 1.5f, 2.0f };
    float noteDuration;
    int randPoint;
    int notesUntilTap = 0;

    int noteStreak = 0;
    int missedNotes = 0;
    int multiplier = 1;
    int score = 0;
    int noteValue = 50;
	string previous = "Note";

    float endTimer = 0.0f;
    bool endGame = false;

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

            //Spawn Note
            Instantiate(noteTypes[curNoteType], spawnPoints[randPoint]);
            // Reset Timer
            curNoteLength = Random.Range(0, noteLengthOptions.Length);
            noteDuration = noteLengthOptions[curNoteLength] * tempo;
            m_spawnDelay = noteDuration;
            m_spawnTimer = 0.0f;
        }

        if (endGame)
        {
            endTimer += Time.deltaTime;
        }

        if (endTimer >= 1.5f)
        {
            SceneManager.LoadScene(0);
        }

    }

    public void Score()
    {
        noteStreak++;
        if (noteStreak <= 8)
        {
            multiplier = 1;
        } else if (noteStreak <= 16)
        {
            multiplier = 2;
        } else if (noteStreak <= 24)
        {
            multiplier = 3;
        } else
        {
            multiplier = 4;
        }

        score += noteValue * multiplier;
		
		
		
        scoreText.text = score.ToString();
        streakText.text = noteStreak.ToString();

    }

    public void Miss()
    {
        Debug.Log("Miss");

        noteStreak = 0;
        missedNotes++;

        streakText.text = noteStreak.ToString();
        missedText.text = "Missed: " + missedNotes.ToString() + "/10";

        if (missedNotes >= 10)
        {
            GameEnd();
        }
    }

    public void GameEnd()
    {
        loseScreen.SetActive(true);

        endGame = true;
    }

	public void setPrevious(string setter){
		previous = setter;
	}
	
	public string getPrevious(){
		return previous;
	}
}
