using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {
  public bool IsDay;
  [SerializeField] private UnityEngine.Rendering.Universal.Light2D _light;
  [SerializeField] private Gradient _gradient;
  [SerializeField] private GameObject _globalLightObject;
  [SerializeField] private WeatherController _weatherController;

  void Start() {
    _globalLightObject = GameObject.Find("Global Light 2D");
    _light = _globalLightObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    _weatherController = GetComponent<WeatherController>();
  }

  void Update() {
    // TODO: Verify values once gradient is set
    IsDay = _weatherController.Percentage > 0.16f && _weatherController.Percentage < 0.75;
    _light.color = _gradient.Evaluate(_weatherController.Percentage);
  }
}
