using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ActionItem : MonoBehaviour
{
    Interactable interScript;

    [SerializeField] private string mode;

    [SerializeField] private GameObject[] children;

    bool active;

    void Start()
    {
        interScript = gameObject.GetComponent<Interactable>();

        active = false;
    }

    void Update()
    {
        switch (mode)
        {
            case "light_switcher":
                if (interScript.interaction && Input.GetKeyDown(KeyCode.E))
                {
                    foreach (GameObject child in children)
                    {
                        child.GetComponent<Light2D>().intensity = (active ? 1:0);
                        active = !active;
                    }
                }
                break;
        }
    }
}
