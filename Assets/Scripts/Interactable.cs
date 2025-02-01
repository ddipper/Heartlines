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
        
        uiText.text = "";
        uiText.gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _spriteRenderer.material = outlineMat;

            uiText.text = interactionText;
            uiText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _spriteRenderer.material = defaultMat;
            uiText.text = "";
            uiText.gameObject.SetActive(false);
        }
    }
}
