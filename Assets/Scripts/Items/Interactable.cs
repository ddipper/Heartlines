using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Material outlineMat;
    private Material _defaultMat;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private string jsonKey;
    [SerializeField] private Text uiText;
    private Dictionary<string, string> _jsonData = new Dictionary<string, string>();

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultMat = _spriteRenderer.material;

        if (uiText != null)
        {
            uiText.gameObject.SetActive(true);
        }

        JsonParse();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && uiText)
        {
            _spriteRenderer.material = outlineMat;
            uiText.gameObject.SetActive(true);

            _jsonData.TryGetValue(jsonKey, out string value);

            uiText.text = value ?? "JSON TEXT NOT FOUND";

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && uiText)
        {
            _spriteRenderer.material = _defaultMat;
            uiText.gameObject.SetActive(false);
        }
    }

    private void JsonParse()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "interaction.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            //Debug.Log("JSON Content: " + json);

            _jsonData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
        else
        {
            Debug.LogError($"Файл {path} не найден!");
        }
    }
}