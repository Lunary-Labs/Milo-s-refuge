using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cutscene", menuName = "Cutscenes/Cutscene")]
public class Cutscene : ScriptableObject {
  public List<CutsceneSegment> Segments = new List<CutsceneSegment>();
}
