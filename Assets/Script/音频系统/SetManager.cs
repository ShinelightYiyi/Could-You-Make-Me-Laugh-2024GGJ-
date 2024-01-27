using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetManager : MonoBehaviour
{
    [SerializeField] Image[] Audio;
    [SerializeField] Image[] Sound;
    [SerializeField] Image[] Music;

    [SerializeField] AudioMixer audioMixer;

    private static int AudioVolume;
    private static int SoundVolume;
    private static int MusicVolume;

    private void Awake()
    {
        AudioVolume = 0;
        SoundVolume = 0;
        MusicVolume = 0;
        EventCenter.Instance.AddEventListener<int>("增加音量" , (o)=>AudioUpValue(o));
        EventCenter.Instance.AddEventListener<int>("减少音量", (o) => AudioDownValue(o));
        EventCenter.Instance.AddEventListener<int>("增加音效", (o) => SoundUpValue(o));
        EventCenter.Instance.AddEventListener<int>("减少音效", (o) => SoundDownValue(o));
        EventCenter.Instance.AddEventListener<int>("增加音乐", (o) => MusicUpValue(o));
        EventCenter.Instance.AddEventListener<int>("减少音乐", (o) => MusicDownValue(o));
    }

    private void AudioUpValue(int o)
    {
        for(int i = 0;i<o;i++) 
        {
            Audio[i].DOFade(1f, 0.01f);
        }
        AudioVolume = 0 - 8 * (10 - o);
        audioMixer.SetFloat("Sound", AudioVolume);
    }

    private void AudioDownValue(int o)
    {
        for (int i = o; i < Audio.Length; i++)
        {
            Audio[i].DOFade(0f, 0.01f);
        }
        AudioVolume = 0 - 8 * (10 - o);
        audioMixer.SetFloat("Sound", AudioVolume);
    }
    private void SoundUpValue(int o)
    {
        for (int i = 0; i < o; i++)
        {
            Sound[i].DOFade(1f, 0.01f);
        }
        SoundVolume = 0 - 8 * (10 - o);
        audioMixer.SetFloat("Master", SoundVolume);
    }

    private void SoundDownValue(int o)
    {
        for (int i = o; i < Audio.Length; i++)
        {
            Sound[i].DOFade(0f, 0.01f);
        }
        SoundVolume = 0 - 8 * (10 - o);
        audioMixer.SetFloat("Master", SoundVolume);
    }

    private void MusicUpValue(int o)
    {
        for (int i = 0; i < o; i++)
        {
            Music[i].DOFade(1f, 0.01f);
        }
       MusicVolume = 0 - 8 * (10 - o);
        audioMixer.SetFloat("Music", MusicVolume);
    }

    private void MusicDownValue(int o)
    {
        for (int i = o; i < Audio.Length; i++)
        {
            Music[i].DOFade(0f, 0.01f);
        }
        MusicVolume = 0 - 8 * (10 - o);
        audioMixer.SetFloat("Music", MusicVolume);
    }



}
