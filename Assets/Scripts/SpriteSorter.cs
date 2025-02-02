using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    [SerializeField] private bool isStatic = false;
    [SerializeField] private float offset = 0;
    private const int SortingOrderBase = 0;
    private Renderer _renderer;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    //FIXME: если мало фпс, убрать LateUpdate
    private void LateUpdate()
    {
        _renderer.sortingOrder = (int)(SortingOrderBase - transform.position.y + offset);
        
        if(isStatic) Destroy(this);
    }
}
