using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    [SerializeField] private int dayCounter = 0; 
    [SerializeField] private float _duration = 5f; 
    [SerializeField] private string currentTime;
    private float _startTime;
    float percentage = 0f;
    

    // Start is called before the first frame update
    void Start() {
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update() {
        float timeElapsed = Time.time - _startTime;
        if (timeElapsed >= _duration) {
            ResetTimeOfDay();
            timeElapsed = 0;
        }
        // Calculate percentage as ratio of timeElapsed to _duration
        percentage = timeElapsed / _duration;
        Debug.Log(percentage);
        UpdateCurrentTime(percentage);
    }

    private void UpdateCurrentTime(float percentage) {
        float totalMinutesInDay = 24 * 60; 
        float currentMinutes = percentage * totalMinutesInDay;
        int hours = Mathf.FloorToInt(currentMinutes / 60);
        int minutes = Mathf.FloorToInt(currentMinutes % 60);
        currentTime = string.Format("{00:D2}:{01:D2}", hours, minutes);
    }

    public float GetPercentage() {
        return percentage;
    }

    private void ResetTimeOfDay() {
        _startTime = Time.time;
        dayCounter++;
        percentage = 0;
    }
}
