using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class nejikocontroll : MonoBehaviour
{
    // Start is called before the first frame update

    //1.�v���C���[�̃L�[���͂��󂯎��
    //2.�L�[���͂̕����Ɉړ�����
    //3.�ړ������ɍ��킹�ăA�j���[�V�������Đ�����
    CharacterController controller;

    Vector3 moveDirection = Vector3.zero;

    public float speed = 0f;
    Animator animator;

    //�W�����v�̍��������߂�ϐ�
    public float jumpPower = 0f;

    //�d�͂̋��������߂�ϐ�

    public float gravityPower = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isGrounded)
        {
            //Jump�L�[�̓��͂������y���ɗ͂�������
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpPower;
                animator.SetTrigger("jump");
            }
        }

        if(Input.GetAxis("Vertical") > 0.0f)
        {
            //�˂������O�i���鏈��
            moveDirection.z = Input.GetAxis("Vertical") * speed;
        }
        else
        {
            moveDirection.z = 0.0f;
        }

        //Horizontal(���E����)������΁A�˂�������]������
        transform.Rotate(0, Input.GetAxis("Horizontal") * 3f, 0);

        //�L�����N�^�[���d�͂ŗ������鏈��
        moveDirection.y = moveDirection.y - gravityPower * Time.deltaTime;

       

        //�ړ��ʂ�Transform�ɕϊ�����
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        //Controller�Ɉړ��ʂ��ڂ�
        controller.Move(globalDirection�@* Time.deltaTime);
        //�˂����̃A�j���[�V�������ŐV����
        animator.SetBool("run", moveDirection.z > 0f);



    }
}
