using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 30;
    [SerializeField] ParticleSystem hitEffect;
    CameraShake cameraShake;
    [SerializeField] bool applyCameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    [SerializeField] bool isPlayer;
    [SerializeField] float increaseScore = 100f;
    LevelManager levelManager;

    void Awake() 
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            damageDealer.Hit();
            PlayHitEffect();
            ShakeCamera();
            audioPlayer.playDamageClip();
            TakeDamage(damageDealer.GetDamage());

        }    
    }

    void TakeDamage(int damage)
    { 
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
            if(isPlayer)
            {
                levelManager.LoadGameOver();
            }
            else
            {
                scoreKeeper.IncreaseScore(increaseScore);
            }
            
        }
    }

    void PlayHitEffect()
    {
        if(hitEffect!= null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration+instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    public float GetCurrentHealth()
    {
        return health;
    }

}
