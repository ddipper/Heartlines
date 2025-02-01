using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Outline : MonoBehaviour
{
    [SerializeField] private Material outlineMat;
    private Material defaultMat;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMat = _spriteRenderer.material;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _spriteRenderer.material = outlineMat;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _spriteRenderer.material = defaultMat;
        }
    }
}
