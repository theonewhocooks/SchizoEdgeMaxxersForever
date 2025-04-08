using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicthing : MonoBehaviour
{
    public GameObject music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMusic();
        }
    }

    void ToggleMusic()
    {
        bool currentState = music.activeSelf;
        music.SetActive(!currentState);
        Debug.Log(currentState);
    }
}
