using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public enum SoundEnum
{
    EFFECT,
    BGM,
    END
}

public enum EAUDIO_MIXER
{
    MASTER,
    BGM,
    SFX
}

public class SoundManager : MonoSingleton<SoundManager>
{
    #region Inspector Settings

    [SerializeField] private float _defaultVolume = 1f;
    [SerializeField] private float _defaultBGMVolume = 0.7f;
    
    [Header("Base Audio Clip")]
    [SerializeField] private AudioClipSO _audioClipSO;
    [SerializeField] private AudioClipSO _bgmClipSO;
    
    #endregion
    
    private AudioSource _audioSource;
    
    
    #region AudioMixer
    [SerializeField] private AudioMixer _masterMixer;
    [SerializeField] private AudioMixerGroup _bgmGroup;
    [SerializeField] private AudioMixerGroup _sfxGroup;
    public AudioMixerGroup SfxGroup => _sfxGroup;
    #endregion

    [SerializeField] private AudioListener _audioListener;

    public float soundFadeOnTime;

    private AudioSource[] _audioSources = new AudioSource[(int)SoundEnum.END];
    private Coroutine _keyFrameCoroutine;
    
    public override void InitManager()
    {
        _audioListener ??= Define.sAudioListener;
        string[] soundNames = System.Enum.GetNames(typeof(SoundEnum));
        for (int i = 0; i < soundNames.Length - 1; i++)
        {
            GameObject go = new GameObject { name = soundNames[i] };
            _audioSources[i] = go.AddComponent<AudioSource>();
            _audioSources[i].playOnAwake = false;
            _audioSources[i].outputAudioMixerGroup = (soundNames[i] == "BGM" ? _bgmGroup : _sfxGroup);
            _audioSources[i].loop = false;
            go.transform.SetParent(transform);
        }

        _audioSources[(int)SoundEnum.BGM].volume = _defaultBGMVolume;
        _audioSources[(int)SoundEnum.BGM].loop = true;
        
        PlaySoundBGM();
    }
    
    public void PlaySoundBGM()
    {
        string bgmDefaultKey = "default";
        AudioClip clip = _bgmClipSO.GetAudioClip(bgmDefaultKey);
        Debug.Log($"Clip: {clip.name}");
        Play(clip,SoundEnum.BGM,true,true);
    }

    public void PlayTalkSFX()
    {
        string talkKey = "Talk";
        AudioClip clip = _audioClipSO.GetAudioClip(talkKey);
        Play(clip,SoundEnum.EFFECT,true,true);
    }
    
    public void PlaySFX(string clipName,bool loop = false)
    {
        AudioClip clip = _audioClipSO.GetAudioClip(clipName);
        Play(clip, SoundEnum.EFFECT,loop);
    }

    public void Play(AudioClip audioClip, SoundEnum type = SoundEnum.EFFECT, bool loop = false,bool startRandomTime = false)
    {
        if (audioClip == null)
        {
            Debug.LogError("cannot find audioclips");
            return;
        }

        if (type == SoundEnum.BGM)
        {
            StopAllCoroutines();
            AudioSource audioSource = _audioSources[(int)SoundEnum.BGM];

            if (audioSource.isPlaying)
                audioSource.Stop();
            
            audioSource.volume = 0;
            audioSource.clip = audioClip;
            audioSource.loop = loop;
            audioSource.time = startRandomTime ? Random.Range(0, audioSource.clip.length) : 0;
            audioSource.Play();

            StartCoroutine(SoundFade(true, _audioSources[(int)SoundEnum.BGM], soundFadeOnTime, 1, SoundEnum.BGM));
            StartCoroutine(SoundFade(false, _audioSources[(int)SoundEnum.BGM], soundFadeOnTime, 0, SoundEnum.BGM));
        }
        else if (type == SoundEnum.EFFECT)
        {
            AudioSource audioSource = _audioSources[(int)SoundEnum.EFFECT];
            // audioSource.clip = audioClip; 
            // float time = startRandomTime ? Random.Range(0, audioSource.clip.length) : 0;;
            // audioSource.time = time;
            // audioSource.loop = loop;
            // audioSource.Play(); 
            audioSource.PlayOneShot(audioClip);
            return;
        }
    }

    public void StopBGM()
    {
        _audioSources[(int)SoundEnum.BGM].Stop();
    }

    public void StopSFX()
    {
        _audioSources[(int)SoundEnum.EFFECT].Stop();
    }
        public void Stop()
        {
            foreach (var audioSource in _audioSources)
            {
                audioSource.clip = null;
                StopAllCoroutines();
                StartCoroutine(SoundFade(true, audioSource, 0.5f, 0f, SoundEnum.BGM));
            }
        }
        
        public void Mute(SoundEnum type, bool mute)
        {
            _masterMixer.SetFloat(type.ToString().ToLower(), mute ? -80 : 0);
        }
        
        
        IEnumerator SoundFade(bool fadeIn, AudioSource source, float duration, float endVolume, SoundEnum type)
        {
            if (!fadeIn)
            {
                yield return new WaitForSeconds((float)(source.clip.length - duration));
            }

            float time = 0f;
            float startVolume = source.volume;

            while (time < duration)
            {
                time += Time.deltaTime;
                source.volume = Mathf.Lerp(startVolume, endVolume, time / duration);
                yield return null;
            }

            if (!fadeIn)
                Play(source.clip, type);
        }
    }
