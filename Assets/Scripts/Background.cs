using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Backgroundscroll : MonoBehaviour
{
    public Renderer meshRenderer;
    public float speed = 0.1f;
    void Start()
    {

    }
    void Update()
    {
        
        meshRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
