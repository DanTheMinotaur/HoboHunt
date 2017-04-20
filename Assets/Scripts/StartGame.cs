using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void OnMouseUp()
    {
        Application.LoadLevel("scene");
    }
}