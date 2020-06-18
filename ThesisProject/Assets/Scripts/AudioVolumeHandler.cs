using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolumeHandler : MonoBehaviour {

	public AudioMixer MainMixer;


	public void VolumeLevelSet(float volLevel){

		if (gameObject == GameObject.Find ("MVSlider")) {
		
			MainMixer.SetFloat ("MasterVolPar", Mathf.Log10 (volLevel) * 20);

		}else if (gameObject == GameObject.Find ("BGMVSlider")) {

			MainMixer.SetFloat ("BGMVolPar", Mathf.Log10 (volLevel) * 20);

		}else if (gameObject == GameObject.Find ("SEVSlider")) {

			MainMixer.SetFloat ("SEVolPar", Mathf.Log10 (volLevel) * 20);
		
		}
	}

	public void VolumeLevelLoad(float volLevel, int type){

		if (type == 0) {

			MainMixer.SetFloat ("MasterVolPar", Mathf.Log10 (volLevel) * 20);

		}else if (type == 1) {

			MainMixer.SetFloat ("BGMVolPar", Mathf.Log10 (volLevel) * 20);

		}else if (type == 2) {

			MainMixer.SetFloat ("SEVolPar", Mathf.Log10 (volLevel) * 20);
		}
	}



}
