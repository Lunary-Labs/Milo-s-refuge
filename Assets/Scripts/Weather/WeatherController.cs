using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine;

public class WeatherController : MonoBehaviour {
  public int DayCounter = 0;
  public float Percentage = 0f;
  public string CurrentWeather = "Neutral";

  private float _timeElapsed = 0f;
  private float _dayDuration = 48f; // Will be 1440 (1sec RT = 1 min IGT)

  private float _weatherDurationMin = 10; // Will be 120f
  private float _weatherDurationMax = 20; // Will be 300f
  public float _timeElapsedWeather = 0f;
  public float _nextWeatherDelay;
  private List<WeatherState> _weatherStates;

  private GameObject _weatherParticles;
  private ParticleSystem _particleSystem;

  private GameObject _fogGameObject;
  private VisualEffect _fogVFX;

  void Start() {
    _weatherParticles = GameObject.Find("Main Camera").transform.Find("WeatherParticles").gameObject;
    _particleSystem = _weatherParticles.GetComponent<ParticleSystem>();
    _fogGameObject = GameObject.Find("Main Camera").transform.Find("Fog").gameObject;
    _fogVFX = _fogGameObject.GetComponent<VisualEffect>();
    _weatherStates = new List<WeatherState>() {
      new WeatherState("Neutral", 0.6f),
      new WeatherState("Rain", 0.1f),
      new WeatherState("Clouds", 0.1f),
      new WeatherState("Fog", 0.1f),
      new WeatherState("Storm", 0.1f)
    };
    CurrentWeather = "Neutral";
  }

  void Update() {
    _timeElapsed += Time.deltaTime;
    _timeElapsedWeather += Time.deltaTime;
    if(_timeElapsed >= _dayDuration) {
      DayCounter++;
      _timeElapsed = 0;
    }
    Percentage = _timeElapsed / _dayDuration;

    if(_timeElapsedWeather >= _nextWeatherDelay) {
      float randomVal = Random.Range(0f, 1f);
      float totalWeight = 0f;
      foreach(WeatherState state in _weatherStates) {
        totalWeight += state.Weight;
        if(randomVal < totalWeight) {
          CurrentWeather = state.Name;
          switch (CurrentWeather) {
            // TODO Make transitions on particle system instead of just active/inactive
            case "Rain":
              _weatherParticles.SetActive(true);
              _fogVFX.SetBool("SpawnActive", true);
              // TODO start rain ambient sound
              // TODO color change
              break;
            case "Storm":
              _weatherParticles.SetActive(true);
              _fogVFX.SetBool("SpawnActive", true);
              // TODO start storm ambient sounds
              // TODO color change
              break;
            case "Clouds":
              _weatherParticles.SetActive(false);
              _fogVFX.SetBool("SpawnActive", false);
              // TODO: maybe a `could` particle/vfx grap
              // TODO color change
              break;
            case "Fog":
              _weatherParticles.SetActive(false);
              _fogVFX.SetBool("SpawnActive", true);
              // TODO color change
              break;
            default:
              _weatherParticles.SetActive(false);
              _fogVFX.SetBool("SpawnActive", false);
              break;
          }
          break;
        }
      }
      _timeElapsedWeather = 0f;
      _nextWeatherDelay = Random.Range(_weatherDurationMin, _weatherDurationMax);
    }
  }

  private class WeatherState {
    public string Name;
    public float Weight;
    public WeatherState(string name, float weight) {
      Name = name;
      Weight = weight;
    }
  }
}
