using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using UnityEngine;

public class WorldLight : MonoBehaviour {
    [SerializeField]private float _duration = 5f; 
    [SerializeField]private Light2D _light;
    private float _startTime;

    [SerializeField] private Gradient gradient;


    // Start is called before the first frame update
    void Start() {
        _light = GetComponent<Light2D>();
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update() {
        float timeElapsed = Time.time - _startTime;
        float percentage = Mathf.Sin(timeElapsed / _duration * Mathf.PI * 2) * 0.5f + 0.5f;
        percentage = Mathf.Clamp(percentage, 0, 1);
        _light.color = gradient.Evaluate(percentage);
        
    }
}