using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    float score = 0f;

    void Awake() 
    {
        ManageSingleton();    
    }

    public float GetCurrentScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0f;
    }

    public void IncreaseScore(float value)
    {
        score += value;
    }

    void ManageSingleton()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if(instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
