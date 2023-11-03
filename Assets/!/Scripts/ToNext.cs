using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNext : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}
