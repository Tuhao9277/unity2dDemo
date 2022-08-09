using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace PlatformShoot
{


  public class PlatformShootGame : Architecture<PlatformShootGame>
  {
    protected override void Init()
    {
      RegisterModel<IGameModel>(new GameModel());
    }
  }
}