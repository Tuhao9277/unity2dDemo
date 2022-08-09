using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;

namespace PlatformShoot
{

  public class NextLevel : MonoBehaviour, IController
  {
    IArchitecture IBelongToArchitecture.GetArchitecture()
    {
      return PlatformShootGame.Interface;
    }
    private void Start()
    {
      gameObject.SetActive(false);
      this.RegisterEvent<ShowPassDoorEvent>(onCanGamePass)
        .UnRegisterWhenGameObjectDestroyed(gameObject);
    }

    private void onCanGamePass(ShowPassDoorEvent obj)
    {
      gameObject.SetActive(true);
    }
  }
}