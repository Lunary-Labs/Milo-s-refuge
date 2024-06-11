using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _light;
    [SerializeField] private Gradient gradient;
    [SerializeField] private GameObject globalLightObject;
    [SerializeField] private WeatherController weatherController;


    // Start is called before the first frame update
    void Start() {
        globalLightObject = GameObject.Find("Global Light 2D");
        _light = globalLightObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        weatherController = GetComponent<WeatherController>();
    }

    // Update is called once per frame
    void Update() {
        float percentage = weatherController.GetPercentage();
        _light.color = gradient.Evaluate(percentage);
    }
}
