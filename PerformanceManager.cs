using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceManager : MonoBehaviour, IPerformanceManager
{
    ILevelState levelState;
    //���݂̃R���{���
    public IPerformanceManager.ComboState currentComboState { get; private set; }
    /// <summary>
    /// �R���{��Ԃ��ς��Ƃ��̃R�[���o�b�N�@OnChangeState.Invoke()�ŌĂяo��
    /// </summary>
    public event System.Action OnChangeState;
    public void ChangeState(IPerformanceManager.ComboState nextState)
    {
        currentComboState = nextState;
        OnChangeState.Invoke();
    }
    public void  ComboPerformance(int combo)
    {
        if (combo > 10)
        {
            ChangeState(IPerformanceManager.ComboState.ComboMax);
        }
        else if (combo >= 5)
        {
            ChangeState(IPerformanceManager.ComboState.ComboMid);
        }
        else
        {
            ChangeState(IPerformanceManager.ComboState.ComboLow);
        }
    }
    //�Q�[���I�[�o�[�ɂȂ����Ƃ��̏���
    public void GameOver()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        levelState = GetComponent<ILevelState>();

    }

}
