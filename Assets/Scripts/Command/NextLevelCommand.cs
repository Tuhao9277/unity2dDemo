using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

public class NextLevelCommand : AbstractCommand
{
  private readonly string mSceneName;

  public NextLevelCommand(string mSceneName)
  {
    this.mSceneName = mSceneName;
  }

  protected override void OnExecute()
  {
    SceneManager.LoadScene(mSceneName);
  }
}
