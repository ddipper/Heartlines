using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CustomGrid : MonoBehaviour
{
    [SerializeField] private Tilemap map;

    [SerializeField] private GameObject[] obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectsWithTag("interactable");        

        foreach(GameObject o in obj)
        {
            Vector2 pos = o.transform.position;

            Vector3Int cellPos = map.WorldToCell(pos);

            o.transform.position = new Vector2(map.CellToWorld(cellPos).x + 0.16f, map.CellToWorld(cellPos).y + 0.16f);
        }
    }
}
