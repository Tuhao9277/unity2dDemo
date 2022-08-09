using UnityEngine;
using QFramework;
namespace PlatformShoot
{
  public class Bullet : MonoBehaviour,IController
  {
    private LayerMask mlayerMask;

    private int bulletDir;
    public void InitDir(int dir)
    {
      bulletDir = dir;
    }
    private void Start()
    {
      GameObject.Destroy(this.gameObject, 3f);
      mlayerMask = LayerMask.GetMask("Ground", "Trigger");
    }
    private void Update()
    {
      transform.Translate(bulletDir * 12 * Time.deltaTime, 0, 0);
    }
    private void FixedUpdate()
    {
      // 返回一个collider，不为空时，子弹碰到了一个对象
      var coll = Physics2D.OverlapBox(transform.position, transform.localScale, 0, mlayerMask);
      if (coll)
      {
        // 移除
        if (coll.CompareTag("Trigger"))
        {
          GameObject.Destroy(coll.gameObject);
          //mGamePass.SetActive(true);
          this.SendCommand<ShowPassDoorCommand>();
        }
        GameObject.Destroy(gameObject);
      }
    }

    IArchitecture IBelongToArchitecture.GetArchitecture()
    {
      return PlatformShootGame.Interface;
    }
  }
}