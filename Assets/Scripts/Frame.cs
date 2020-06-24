using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    public GameObject frame1;
    public GameObject frame2;

    private void OnTriggerEnter2D(Collider2D other) {
        if (frame1.active == true) {
            frame1.SetActive(false);
            frame2.SetActive(true);
        }
        else if (frame1.active == false) {
            frame2.SetActive(false);
            frame1.SetActive(true);
        }
    }
}
