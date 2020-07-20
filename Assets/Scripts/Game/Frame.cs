using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    public GameObject frame1;
    public GameObject frame2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (frame1.activeInHierarchy)
        {
            case true:
                frame1.SetActive(false);
                frame2.SetActive(true);
                break;
            case false:
                frame2.SetActive(false);
                frame1.SetActive(true);
                break;
        }
    }
}
