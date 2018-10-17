using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAdjustScript : MonoBehaviour
{
    public AudioClip TestMusic;
    public AudioClip TestFX;
    // Use this for initialization

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "Health up"))
        {
            GameController.control.playerHealth += 10;
        }
        if (GUI.Button(new Rect(10, 130, 100, 30), "Health down"))
        {
            GameController.control.playerHealth -= 10;
        }
        if (GUI.Button(new Rect(10, 160, 100, 30), "Sanity up"))
        {
            GameController.control.playerSanity += 10;
        }
        if (GUI.Button(new Rect(10, 190, 100, 30), "Sanity down"))
        {
            GameController.control.playerSanity -= 10;
        }
        if (GUI.Button(new Rect(10, 220, 100, 30), "Save"))
        {
            GameController.control.Save();
        }
        if (GUI.Button(new Rect(10, 250, 100, 30), "Load"))
        {
            GameController.control.Load();
        }
        if (GUI.Button(new Rect(10, 280, 100, 30), "Music"))
        {
            AudioManager.Instance.PlayMusic(TestMusic);
        }
        if (GUI.Button(new Rect(120, 280, 100, 30), "Stop"))
        {
            AudioManager.Instance.StopMusic(TestMusic);
        }
        if (GUI.Button(new Rect(10, 310, 100, 30), "SFX"))
        {
            AudioManager.Instance.Play(TestFX);
        }
    }
}