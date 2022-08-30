using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgorundScroll : MonoBehaviour
{
    [SerializeField] Vector2 scrollSpeed;
    Vector2 offset;
    Material material;


    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    
    void Update()
    {
        offset = scrollSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
