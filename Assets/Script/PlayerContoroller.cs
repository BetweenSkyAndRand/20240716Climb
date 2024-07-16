using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoroller : MonoBehaviour
{
    //�d��
    Rigidbody2D rigidbody2D;
    //�W�����v����Ƃ��̗�
    float jumpForce = 680.0f;
    //�������̗�
    float walkForce = 30.0f;
    float MaxWaklSpead=2.0f;
    //�A�j���[�V����
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //�t���[���J�E���g
        Application.targetFrameRate = 60;
        //Rigidbody���R���|�[�l���g
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�W�����v����
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.rigidbody2D.AddForce(transform.up * this.jumpForce);
        }
        int key = 0;
        //���E�Ɉړ�
        if(Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }
        //�v���C���[���x
        float speedx = Mathf.Abs(this.rigidbody2D.velocity.x);
        //�X�s�[�h����
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
