using UnityEngine;



public class Moveing : ITutorialTask
{
    public string GetTitle()
    {
        return "��{����";
    }
    public string GetText()
    {
        return "WASD�őO�i��ލ��E�ւ̈ړ����ł��܂�";
    }
    public void OnTaskSetting()
    {
    }
    public bool checkTask()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (hor > 0 || ver > 0) { return true; }
        return false;
    }
    public float GetTransitionTime()
    {
        return 0.1f;
    }
}
public class launch : ITutorialTask
{
    public string GetTitle()
    {
        return "�N��";
    }
    public string GetText()
    {
        return "�Ԃ����ɋ߂Â��ƐF�ɂȂ�\n" +
            "���삪�ł���悤�ɂȂ�܂�";
    }
    public void OnTaskSetting()
    {
    }
    public bool checkTask()
    {
        if (Rotation.rotatable_share is true) { return true; }
        return false;
    }
    public float GetTransitionTime()
    {
        return 0.1f;
    }
}
public class Rotation_direction : ITutorialTask
{
    public string GetTitle()
    {
        return "��]����";
    }
    public string GetText()
    {
        return "Q�L�[�ō���]\n" +
            "E�L�[�ŉE�ɉ�]���܂�";
    }
    public void OnTaskSetting()
    {
    }
    public bool checkTask()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)) { return true; }
        return false;
    }
    public float GetTransitionTime()
    {
        return 1f;
    }
}
public class gimmick : ITutorialTask
{
    public string GetTitle()
    {
        return "�M�~�b�N�B";
    }
    public string GetText()
    {
        return "�M�~�b�N�ɂ̓��[�U�[�A�{�^���A���̂R���\n" +
            "���̂ق��ɂ������œ������u���b�N�Ȃǂ���܂�\n";
    }
    public void OnTaskSetting()
    {
    }
    public bool checkTask()
    {
        return false;
    }
    public float GetTransitionTime()
    {
        return 2f;
    }
}
public class bridge : ITutorialTask
{
    public string GetTitle()
    {
        return "��";
    }
    public string GetText()
    {
        return "���������̕����Ɍ������\n" +
            "���ꂪ�L�тė��܂�";
    }
    public void OnTaskSetting()
    {
    }
    public bool checkTask()
    {
        return true;
    }
    public float GetTransitionTime()
    {
        return 5f;
    }
}
public class laser_ : ITutorialTask
{
    public string GetTitle()
    {
        return "���[�U�[";
    }
    public string GetText()
    {
        return "���[�U�[�Ƀu���b�N�𓖂Ă܂�\n" +
            "����ɐG��Ă����v�ł�";
    }
    public void OnTaskSetting()
    {
    }
    public bool checkTask()
    {
        if (tutorialmanager.laser_hit is true) { return true; }
        return false;
    }
    public float GetTransitionTime()
    {
        return 1f;
    }
}
public class button_selfblock : ITutorialTask
{
    public string GetTitle()
    {
        return "�{�^���Ǝ����œ������u���b�N";
    }
    public string GetText()
    {
        return "�Ԃ������̏�Ƀu���b�N���悹�܂�\n" +
            "�����K�ȊO�̃u���b�N�͎����œ������܂�";
    }
    public void OnTaskSetting()
    {
    }
    public bool checkTask()
    {
        if (tutorialmanager.button_hit is true) { return true; }
        return false;
    }
    public float GetTransitionTime()
    {
        return 1f;
    }
}
public class dontstop : ITutorialTask
{
    public string GetTitle()
    {
        return "��]����2";
    }
    public string GetText()
    {
        return "��{�I����͓����ł���\n" +
            "�����Ă���Ԃ�����]���܂���";
    }
    public void OnTaskSetting()
    {
    }
    public bool checkTask()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)) { return true; }
        return false;
    }
    public float GetTransitionTime()
    {
        return 1f;
    }
}
public class end : ITutorialTask
{
    public string GetTitle()
    {
        return "�S�[��";
    }
    public string GetText()
    {
        return "���̕ǂɐG���ƃS�[���ł�\n" +
            "������{�Ԃ̃X�e�[�W���n�܂�܂�";
    }
    public void OnTaskSetting()
    {
    }
    public bool checkTask()
    {
        return false;
    }
    public float GetTransitionTime()
    {
        return 1f;
    }
}
