using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformShoot
{
  public class Bullet : MonoBehaviour
  {
    private void Start()
    {
      GameObject.Destroy(this.gameObject, 3f);
    }
    private void Update()
    {
      transform.Translate(12 * Time.deltaTime, 0, 0);
    }
  }
}