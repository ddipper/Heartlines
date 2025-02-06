using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class RoomRenderer : MonoBehaviour
{
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private GameObject obj;
    [SerializeField] private string tag;
    [SerializeField] private CinemachineConfiner confiner;
    [SerializeField] private float fadeTime;
    [SerializeField] private Material mat;
    float timer = 0;
    bool isDissolving;

    // Start is called before the first frame update
    void Start()
    {
        tag = "room_renderer";
        rooms = GameObject.FindGameObjectsWithTag(tag);
        mat.SetFloat("_Value", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);
        if (isDissolving)
        {           
            timer += Time.deltaTime;
            mat.SetFloat("_Value", timer * 10 / fadeTime);
           
            if(timer >= fadeTime)
            {
                mat.SetFloat("_Value", 0);
                obj.SetActive(false);
                timer = 0;
                isDissolving = false;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.tag == tag)
        {            
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            collision.gameObject.transform.GetChild(1).gameObject.SetActive(false);

            confiner.m_BoundingShape2D = collision;
        }               
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == tag)
        {
            collision.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            obj = collision.gameObject.transform.GetChild(0).gameObject;

            isDissolving = true;
        }
    }
}
