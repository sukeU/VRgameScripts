using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GunManagerTest : MonoBehaviour,IGunManager�@
{
    [SerializeField] GameObject LGun, RGun;
    [SerializeField] Transform LGun_trans, LGun_trajectory, LGun_Trigger;//���̏e�̈ʒu�E�O���ʒu�E�g���K�[
    [SerializeField] Transform RGun_trans, RGun_trajectory, RGun_Trigger;//�E�̏e�̈ʒu�E�O���ʒu�E�g���K�[
    LineRenderer lineRenderer_L, lineRenderer_R;//���C�U�[�|�C���^�[���E
    [SerializeField] float StartWidth, EndWidth;//���C�U�[�|�C���^�[���E�@����
    [SerializeField] Text textbullet_countL, textbullet_countR;//���̎c�e��UI���E
    int bullet_countL, bullet_countR;//���E���ꂼ��̎c�e��
    [SerializeField]GameObject GameManager;
    void Start()
    {
        lineRenderer_L = LGun.GetComponent<LineRenderer>();
        lineRenderer_R = RGun.GetComponent<LineRenderer>();
        bullet_countL = 1;
        bullet_countR = 1;
        lineRenderer_L.startWidth = StartWidth;
        lineRenderer_L.endWidth = EndWidth;
        lineRenderer_R.startWidth = StartWidth;
        lineRenderer_R.endWidth = EndWidth;
    }

    // Update is called once per frame
    void Update()
    {
        textbullet_countL.text = bullet_countL.ToString();
        textbullet_countR.text = bullet_countR.ToString();
        lineRenderer_L.SetPosition(0, LGun_trans.position);
        lineRenderer_L.SetPosition(1, LGun_trajectory.position);
        lineRenderer_R.SetPosition(0, RGun_trans.position);
        lineRenderer_R.SetPosition(1, RGun_trajectory.position);
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))//���g���K�[���������Ƃ�
        {
            bullet_countL = 0;
            LGun_Trigger.transform.localRotation = Quaternion.Euler(-27f, 0, 0);
        }
        if (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger))//���g���K�[��߂����Ƃ�
        {
            LGun_Trigger.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))//�E�g���K�[���������Ƃ�
        {
            bullet_countR = 0;
            RGun_Trigger.transform.localRotation = Quaternion.Euler(-27f, 0, 0);
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))//�E�g���K�[��߂����Ƃ�
        {
            RGun_Trigger.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        ////���������I�̎�ނ��m�F����p�̃X�N���v�g
        //Ray ray = new Ray(LGun_trans.position, LGun_trans.position - LGun_trajectory.position);
        //RaycastHit hit;
        //if(Physics.Raycast(ray,out hit, 10f))
        //{
        //    if (hit.collider.name == "Target")
        //    {
        //        Ob.SetActive(true);
        //        Debug.Log("UI���m�F");
        //    }
        //    else Ob.SetActive(false);
        //    Debug.Log(hit.collider.gameObject.name);
        //}
        //Debug.DrawRay(LGun_trans.position, LGun_trajectory.position- LGun_trans.position, Color.red );


        //�I�ɖ��������ۂ̃����[�h�@�\�@����X�{�^���ō��q�b�g�@A�{�^���ŉE�q�b�g�����ɂ����Ă���
        if (OVRInput.GetDown(OVRInput.RawButton.X)) Reload();//�����������ꍇ

        if (bullet_countL == 0 && bullet_countR == 0) { GameOver(); }


    }
    public void Reload()//�����[�h����Ɨ����̏e�e���񕜂���V�X�e���Ȃ̂ō��E����͕s�v�@�������������񕜂��Ȃ�������Е��������Ǝg���Ȃ��Ȃ邩��(sukeU)
    {
        bullet_countL = 1;
        bullet_countR = 1;
    }

    public void GameOver() //�C���^�[�t�F�[�X���p�������GameOver�������K�v�ɂȂ邽�߂����ɋL�ڂ��Ă�(sukeU)
    {
        GameManager.GetComponent<IStateChanger>().GameOver();

    }
    
     public void PowerUp() //�C���^�[�t�F�[�X���p������ƃp���[�A�b�v�������K�v�ɂȂ邽�߂����ɋL�ڂ��Ă�(sukeU)
    {
        bullet_countL = 10;
        bullet_countR = 10;
    }
    public void PowerDown() //�C���^�[�t�F�[�X���p������ƃp���[�_�E���������K�v�ɂȂ邽�߂����ɋL�ڂ��Ă�(sukeU)
    {

    }


}

