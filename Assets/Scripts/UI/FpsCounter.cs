using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    [SerializeField] private Text label;
    private int fps;
    void Start()
    {
        
    }
    
    void Update()
    {
        fps = (int) (1f / Time.unscaledDeltaTime);
        label.text = $"FPS: {Mathf.Clamp(fps, 0, 90).ToString()}";
    }
}
