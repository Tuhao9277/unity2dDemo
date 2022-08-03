using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PlatformShoot
{
  public class GamePassPanel : MonoBehaviour
  {
    // Start is called before the first frame update
    void Start()
    {
      transform.Find("ResetGameBtn").GetComponent<Button>().onClick.AddListener(() =>
      {
        SceneManager.LoadScene("SampleScene");
      });
    }

    // Update is called once per frame
    void Update()
    {

    }
  }
}