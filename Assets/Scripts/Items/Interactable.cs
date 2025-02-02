using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System.IO;

[System.Serializable]
public class TempJsonWrapper
{
    public string inter_tumba;
}

public class Interactable : MonoBehaviour
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
        
        string path = Path.Combine(Application.streamingAssetsPath, "interaction.json");
        string json = File.ReadAllText(path);
        Debug.Log(json);
        
        TempJsonWrapper data = JsonUtility.FromJson<TempJsonWrapper>(json);

        Debug.Log(data.inter_tumba);
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