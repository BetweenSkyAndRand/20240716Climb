using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoroller : MonoBehaviour
{
    //重力
    Rigidbody2D rigidbody2D;
    //ジャンプするときの力
    float jumpForce = 680.0f;
    //歩く時の力
    float walkForce = 30.0f;
    float MaxWaklSpead=2.0f;
    //アニメーション
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //フレームカウント
        Application.targetFrameRate = 60;
        //Rigidbodyをコンポーネント
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプする
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);
        }
        int key = 0;
        //左右に移動
        if(Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }
        //プレイヤー速度
        float speedx = Mathf.Abs(this.rigidbody2D.velocity.x);
        //スピード制限
        if(speedx<this.MaxWaklSpead)
        {
            this.rigidbody2D.AddForce(transform.right * key * this.walkForce);
        }
        if(key!=0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        this.animator.speed = speedx / 0.75f;
    }
}
