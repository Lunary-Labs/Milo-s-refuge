using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour {
  public string CurrentTime; // TODO: Remove this display attribute in the future
  [SerializeField] public int DayCounter = 0;
  public float Percentage = 0f;
  private float _timeElapsed = 0f;
  private float _duration = 48f; // Will be 1440 (1sec RT = 1 min IGT)

  void Update() {
    _timeElapsed += Time.deltaTime;
    if (_timeElapsed >= _duration) {
      DayCounter++;
      _timeElapsed = 0;
    }
    Percentage = _timeElapsed / _duration;
    UpdateCurrentTime(Percentage);
  }

  // TODO: Remove this temp function in the future
  private void UpdateCurrentTime(float percentage) {
    float totalMinutesInDay = 24 * 60;
    float currentMinutes = percentage * totalMinutesInDay;
    int hours = Mathf.FloorToInt(currentMinutes / 60);
    int minutes = Mathf.FloorToInt(currentMinutes % 60);
    CurrentTime = string.Format("{00:D2}:{01:D2}", hours, minutes);
  }
}
