using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ITutorialTask
{
    /// <summary>
    /// �`���[�g���A���̃^�C�g�����擾
    /// </summary>
    /// <returns></returns>
    string GetTitle();
    /// <summary>
    /// ���������擾
    /// </summary>
    /// <returns></returns>
    string GetText();
    /// <summary>
    /// �`���[�g���A���^�X�N���ݒ肳�ꂽ�ꍇ���s
    /// </summary>
    void OnTaskSetting();
    /// <summary>
    /// �`���[�g���A���^�X�N���B�����ꂽ���ǂ����̔��f
    /// </summary>
    /// <returns></returns>
    bool checkTask();
    /// <summary>
    /// �B����Ɏ��^�X�N�ւ̑J�ڎ���
    /// </summary>
    /// <returns></returns>
    float GetTransitionTime();
}
