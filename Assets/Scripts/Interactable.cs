using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class Outline : MonoBehaviour
{
    [SerializeField] private Material outlineMat;
    private Material defaultMat;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private string interactionText;
    [SerializeField] private Text uiText;
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMat = _spriteRenderer.material;

        if (uiText != null)
        {
            uiText.gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && uiText)
        {
            _spriteRenderer.material = outlineMat;
            uiText.gameObject.SetActive(true);
            uiText.text = interactionText;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && uiText)
        {
            _spriteRenderer.material = defaultMat;
            uiText.gameObject.SetActive(false);
        }
    }
}