using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour,ITimer
{
    IStateChanger stateChanger;
    public bool IsPlaying { get; private set; }
    public float playTime { get; private set; }
    TextMeshProUGUI text;
    private float currentStartTime;
    public float startTime { get; private set; } = 10f;
    public float endTime { get; private set; } = 0f;
    public bool IsCounting { get; private set; }
    /// <summary>
    /// �J�E���g�_�E���^�C�}�[
    /// </summary>
    public float timer { get; private set; }
    /// <summary>
    /// �J�E���g�_�E���̏����ݒ肷��
    /// </summary>
    public void SetTimer(float upperlimitTime)
    {
        startTime = upperlimitTime;
    }
    /// <summary>
    /// �J�E���g�_�E�������Z�b�g����
    /// </summary>
    public void ResetTimer()
    {
        if (IsCounting)
        {
            currentStartTime = startTime;
            timer = currentStartTime;
        }
      
    }
    /// <summary>
    /// �J�E���g�_�E�����n�߂�
    /// </summary>
    public void StartTimer()
    {
        if (!IsCounting)
        {
            IsCounting = true;
        }
    }
    /// <summary>
    /// �J�E���g�_�E�����~�߂�
    /// </summary>
    public void StopTimer()
    {
        if (IsCounting)
        {
            IsCounting = false;

        }
    }

    /// <summary>
    /// �Q�[���̌o�ߎ��Ԃ��v������
    /// </summary>
    public void StartPlay()
    {
        IsPlaying = true;
        ResetPlayTime();
        SetTimer(10f);
        StartTimer();
        ResetTimer();
    }
    /// <summary>
    /// �Q�[���̌o�ߎ��Ԃ��~����
    /// </summary>
    public void StopPlay()
    {
        IsPlaying = false;
        StopTimer();
    }
    /// <summary>
    ///  �Q�[���̌o�ߎ��Ԃ�����������
    /// </summary>
    public void ResetPlayTime()
    {
        playTime = 0f;
        ResetTimer();
        text.text = $"{0.0:f1}";
        DecreaseImage(1.0f , 1);
    }


    void Start()
    {
        Canvas canvas = GetComponentInChildren<Canvas>();
        canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        text = transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        stateChanger= GameObject.FindGameObjectWithTag("GameController").GetComponent<IStateChanger>();
    }
    private void FixedUpdate()
    {
        if (IsPlaying)
        {
            playTime += Time.deltaTime;
            if (IsCounting)
            {
                timer = Mathf.Clamp(timer - Time.deltaTime, endTime, currentStartTime);
                text.text = $"{timer:f1}";
                DecreaseImage(timer, (int)startTime);
                if (timer == 0)
                {
                    stateChanger.ChangeState(IStateChanger.GameState.Result);
                }
            }

        }
    }

    private void DecreaseImage(float current, int max)
    {
        //Image�R���|�[�l���g��fillAmount���擾���đ��삷��
        transform.GetChild(0).GetChild(2).GetComponent<Image>().fillAmount = current / max;
    }

}
