using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private Material outline;
    GameObject sprite;
    public void Interact(Vector2 pos, bool not)
    {
        if (!not)
        {
            Debug.Log("pos x: " + pos.x + " pos y: " + pos.y);
            Vector3Int tilePos = map.WorldToCell(pos);
            Debug.Log("Tilepos x: " + tilePos.x + " Tilepos y: " + tilePos.y);

            if (map.GetTile(tilePos) != null)
            {
                Interactable tile = (Interactable) map.GetTile(tilePos);

                sprite = new GameObject();
                sprite.tag = "temp";
                
                Sprite spr = tile.sprite;
                SpriteRenderer sr = sprite.AddComponent<SpriteRenderer>();
                sr.material = outline;
                sr.sprite = spr;
                sr.sortingOrder = 2;

                Vector3 vec = map.CellToWorld(tilePos);
                vec.x += 0.16f;
                vec.y += 0.16f;
                sprite.transform.position = vec;                

                Debug.Log(tile.GetTileID(tilePos));
            }
            else
            {
                Debug.Log("No tile");
            }         
        }
        else
        {
            sprite = GameObject.FindGameObjectWithTag("temp");
            Destroy(sprite);
        }
        
    }
}
