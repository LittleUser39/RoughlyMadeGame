using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
  public Camera maincamera;
  public Camera battlecamera;

private void Start() {
    maincamera.enabled = true;
    battlecamera.enabled = false;
}
  public void OnBattle()
  {
   maincamera.enabled = false;
   battlecamera.enabled = true;
  }

  public void EndBattle()
  {
    maincamera.enabled = true;
    battlecamera.enabled = false;
  }
}
