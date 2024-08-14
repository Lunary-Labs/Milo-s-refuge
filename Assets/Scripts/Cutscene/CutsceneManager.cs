using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour {
  public Image _topBar;
  public Image _bottomBar;

  // TODO Remove theses, trigger zone, quest, etc. will call PlayCutscene themselves
  public Cutscene CurrentCutscene;
  void Start() {
    _topBar = GameObject.Find("TopBar").GetComponent<Image>();
    _bottomBar = GameObject.Find("BottomBar").GetComponent<Image>();

    if (CurrentCutscene != null) {
      StartCoroutine(PlayCutscene(CurrentCutscene));
    }
  }

  IEnumerator PlayCutscene(Cutscene cutscene) {
    yield return StartCoroutine(FadeBarsIn());
    foreach (var segment in cutscene.Segments) {
      yield return StartCoroutine(segment.Execute());
    }
    yield return StartCoroutine(FadeBarsOut());
  }

  public IEnumerator FadeBarsIn() {
    float elapsedTime = 0;
    while (elapsedTime < 1) {
      float opacity = Mathf.Lerp(0, 1, elapsedTime / 1);
      var color = _topBar.color;
      color.a = opacity;
      _topBar.color = color;
      _bottomBar.color = color;
      elapsedTime += Time.deltaTime;
      yield return null;
    }
  }

  public IEnumerator FadeBarsOut() {
    float elapsedTime = 0;
    while (elapsedTime < 1) {
      float opacity = Mathf.Lerp(1, 0, elapsedTime / 1);
      var color = _topBar.color;
      color.a = opacity;
      _topBar.color = color;
      _bottomBar.color = color;
      elapsedTime += Time.deltaTime;
      yield return null;
    }
  }
}
