using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CutsceneSegment : ScriptableObject {
  public abstract IEnumerator Execute();
}