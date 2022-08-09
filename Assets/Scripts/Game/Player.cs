using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using QFramework;
namespace PlatformShoot
{


  public class Player : MonoBehaviour,IController
  {
    private Rigidbody2D mRig;
    private float mGroundMoveSpeed = 5f;
    private float mJumpForce = 12f;

    private bool mJumpInput = false;
    private int mFaceDir = 1;
 

    //private MainPanel mainPanel;
    //private GameObject mGamePass;
   
    private void Start()
    {
      mRig = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.J))
      {
        var obj = Resources.Load<GameObject>("Item/Bullet");
        obj = GameObject.Instantiate(obj, transform.position, Quaternion.identity);
        // 按下J的时候，实例化一个子弹对象，并且初始值为当前玩家坐标
        Bullet bullet = obj.GetComponent<Bullet>();
        bullet.InitDir(mFaceDir);
      }
      if (Input.GetKeyDown(KeyCode.K))
      {
        mJumpInput = true;
      }
    }
    private void FixedUpdate()
    {
      if (mJumpInput)
      {
        mJumpInput = false;
        mRig.velocity = new Vector2(mRig.velocity.x, mJumpForce);
      }
      float h = Input.GetAxisRaw("Horizontal");
      if (h != 0 && h != mFaceDir)
      {
        mFaceDir = -mFaceDir;
        transform.Rotate(0, 180, 0);
      }
      // 跳的时候可以控制水平方向
      mRig.velocity = new Vector2(h * mGroundMoveSpeed, mRig.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.CompareTag("Reward"))
      {
        GameObject.Destroy(collision.gameObject);
        // 加分
        this.GetModel<IGameModel>().Score.Value++;
        //mainPanel.UpdateScoreTex(1);

      }
      // 通关
      if (collision.gameObject.CompareTag("Door"))
      {
        this.SendCommand(new NextLevelCommand("GamePassScene"));
      }
    }
    IArchitecture IBelongToArchitecture.GetArchitecture()
    {
      return PlatformShootGame.Interface;
    }
  }

}
