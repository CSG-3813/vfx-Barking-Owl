/***
 * Created by: Andrew Nguyen
 * Created: 2 November 2022
 * Modified: 2 November 2022
 * Description: Manages Weather
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class WeatherSys : MonoBehaviour
{
    public GameObject rainGO;
    ParticleSystem rainPS;

    public float rainTime = 10;

    public AudioMixerSnapshot raining;
    public AudioMixerSnapshot sunny;

    float timerTime;
    bool startTime;
    AudioSource audioSrc;

    bool isRaining;
    public bool IsRaining { get { return isRaining; } }

    public Volume RainVolume;

    float lerpValue;
    float lerpDuration = 10;
    float transitionTime;

    // Start is called before the first frame update
    void Start()
    {
        rainPS = rainGO.GetComponent<ParticleSystem>();
        audioSrc = rainGO.GetComponent<AudioSource>();

    }//end Start()

    // Update is called once per frame
    void Update()
    {
        if (startTime)
        {
            if(timerTime > 0)
            {
                timerTime -= Time.deltaTime;
                TintSky();
            }
            else
            {
                EndRain();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Rain");

        if(other.tag == "Player")
        {
            if (!startTime)
            {
                timerTime = rainTime;
                startTime = true;
                isRaining = true;
                rainPS.Play();
                audioSrc.Play();
                raining.TransitionTo(2.0f);
            }//end if(!startTime)
        }//end if(other)
    }//end

    void EndRain()
    {
        startTime = false;
        isRaining = false;
        rainPS.Stop();
        audioSrc.Stop();
        sunny.TransitionTo(2.0f);
    }

    void TintSky()
    {
        if (transitionTime < lerpDuration)
        {
            lerpValue = Mathf.Lerp(0, 1, transitionTime / lerpDuration);
            transitionTime += Time.deltaTime;
            RainVolume.weight = lerpValue;
        }
    }
}
