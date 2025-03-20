using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicthing2 : MonoBehaviour
{
    public Musicthing musicthing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopMusicClick()
    {
        musicthing.StopMusic();
    }

    public void StartMusicClick()
    {
        musicthing.StartMusic();
    }
}
