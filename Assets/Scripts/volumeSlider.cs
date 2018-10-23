using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeSlider : MonoBehaviour {

    public Slider musicVolume;

	// Update is called once per frame
	public void OnValueChanged ()
    {
        PlayerPrefs.SetFloat("CurVol", AudioManager.Instance.MusicSource.volume);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetFloat("CurVol"));

    }
}
