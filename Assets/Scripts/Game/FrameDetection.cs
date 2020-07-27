using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameDetection : MonoBehaviour
{
    public GameObject Frame1;
    public GameObject Frame2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (Frame1.activeInHierarchy)
        {
            case true:
                Frame1.SetActive(false);
                Frame2.SetActive(true);
                break;
            case false:
                Frame2.SetActive(false);
                Frame1.SetActive(true);
                break;
        }
    }
}
