using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System;

namespace PlatformShoot
{
  public class MainPanel : MonoBehaviour, IController
  {
    private Text mScoreTex;
    private void Start()
    {
      mScoreTex = transform.Find("ScoreText").GetComponent<Text>();
      this.GetModel<IGameModel>()
        .Score
        .RegisterWithInitValue(onScoreChanged)
        .UnRegisterWhenGameObjectDestroyed(gameObject);
    }

    private void onScoreChanged(int score)
    {
      mScoreTex.text = score.ToString();
    }

    public void UpdateScoreTex(int score)
    {
      int temp = int.Parse(mScoreTex.text);
      mScoreTex.text = (temp + score).ToString();
    }

    IArchitecture IBelongToArchitecture.GetArchitecture()
    {
      return PlatformShootGame.Interface;
    }
  }
}