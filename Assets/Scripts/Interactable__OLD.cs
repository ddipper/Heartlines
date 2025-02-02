using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tiles/Interactable")]

public class Interactable : Tile
{
    [SerializeField] private int ID;

    public int GetTileID(Vector3Int position)
    {
        ID = 1000 * position.x + position.y;
        return ID;
    }
}
