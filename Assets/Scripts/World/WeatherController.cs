using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour {
  [SerializeField] public int DayCounter = 0;
  [SerializeField] public string CurrentTime; // TODO: remove this in future
  public float Percentage = 0f;
  private float _duration = 24f;
  private float _startTime;

  private void Start() {
    _startTime = Time.time;
  }

  void Update() {
    float timeElapsed = Time.time - _startTime;
    if (timeElapsed >= _duration) {
      _startTime = Time.time;
      DayCounter++;
      Percentage = 0;
      timeElapsed = 0;
    }
    // Calculate percentage as ratio of timeElapsed to _duration
    Percentage = timeElapsed / _duration;
    UpdateCurrentTime(Percentage);
  }

  // TODO: remove this method in future
  private void UpdateCurrentTime(float percentage) {
    float totalMinutesInDay = 24 * 60;
    float currentMinutes = percentage * totalMinutesInDay;
    int hours = Mathf.FloorToInt(currentMinutes / 60);
    int minutes = Mathf.FloorToInt(currentMinutes % 60);
    CurrentTime = string.Format("{00:D2}:{01:D2}", hours, minutes);
  }
}
