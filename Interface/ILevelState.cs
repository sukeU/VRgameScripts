public interface ILevelState
{
    /// <summary>
    /// �ő�X�R�A
    /// </summary>
    int scoreSum { get;}
    /// <summary>
    /// ���݂̃��x��
    /// </summary>
    int currentLevel { get; }
    /// <summary>
    /// �ő�X�R�A�̃A�b�v�f�[�g
    /// </summary>
    /// <param name="addScore"></param>
    void ScoreUpdate(int addScore);

    void ChangeLevel(int num);

}
