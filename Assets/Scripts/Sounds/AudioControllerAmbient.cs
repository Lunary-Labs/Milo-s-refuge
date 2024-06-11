using System.Collections;
using UnityEngine;

public class AudioControllerAmbient : MonoBehaviour {
  public AudioClip[] DayAmbientSounds;
  public AudioClip[] NightAmbientSounds;

  private DayNightCycle _dayNightCycle;
  private AudioSource _audioSource;
  private bool _isDayPlaying = false;
  private float _fadeDuration = 2f;

  void Start() {
    _dayNightCycle = GameObject.Find("WeatherController").GetComponent<DayNightCycle>();
    _audioSource = GetComponent<AudioSource>();
  }

  void Update() {
    if (!_audioSource.isPlaying) {
      if (_dayNightCycle.IsDay) {
        StartCoroutine(ChangeAmbientSound(DayAmbientSounds));
        _isDayPlaying = true;
      } else {
        StartCoroutine(ChangeAmbientSound(NightAmbientSounds));
        _isDayPlaying = false;
      }
    } else {
      if (_dayNightCycle.IsDay && !_isDayPlaying) {
        StartCoroutine(ChangeAmbientSound(DayAmbientSounds));
        _isDayPlaying = true;
      } else if (!_dayNightCycle.IsDay && _isDayPlaying) {
        StartCoroutine(ChangeAmbientSound(NightAmbientSounds));
        _isDayPlaying = false;
      }
    }
  }

  private IEnumerator ChangeAmbientSound(AudioClip[] soundArray) {
    if (_audioSource.isPlaying) {
      yield return StartCoroutine(FadeOut(_fadeDuration));
    }
    int index = Random.Range(0, soundArray.Length);
    _audioSource.clip = soundArray[index];
    _audioSource.Play();
    yield return StartCoroutine(FadeIn(_fadeDuration));
  }

  IEnumerator FadeOut(float fadeDuration) {
    float startVolume = _audioSource.volume;
    while (_audioSource.volume > 0) {
      _audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
      yield return null;
    }
    _audioSource.Stop();
    _audioSource.volume = startVolume;
  }

  IEnumerator FadeIn(float fadeDuration) {
    float startVolume = _audioSource.volume;
    _audioSource.volume = 0;
    while (_audioSource.volume < startVolume) {
      _audioSource.volume += startVolume * Time.deltaTime / fadeDuration;
      yield return null;
    }
    _audioSource.volume = startVolume;
  }
}
