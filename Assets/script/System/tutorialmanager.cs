using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �Q�[����̃`���[�g���A�����Ǘ�����}�l�[�W���[
/// </summary>
public class tutorialmanager : MonoBehaviour
{
    //�`���[�g���A���pUI
    protected RectTransform tutorialTextArea;
    protected Text TutorialTitle;
    protected Text TutorialText;

    //�`���[�g���A���^�X�N
    protected ITutorialTask currentTask;
    protected List<ITutorialTask> tutorialTask;

    //�`���[�g���A���\���t���O
    bool isEnabled;

    //�`���[�g���A���^�X�N�̏����𖞂������ۂ̑J��
    bool task_executed = false;

    //�`���[�g���A���\������UI�ړ�����
    [Header("UI�ړ�����")]
    [SerializeField] float fade_pos_x;

    public laser laserlaserlaser;
    public static bool laser_hit = false;
    public Button button;
    public static bool button_hit = false;

    private void Start()
    {
        //�`���[�g���A������pbool������
        laser_hit = false;
        button_hit = false;
        // �`���[�g���A���\���pUI�̃C���X�^���X�擾
        tutorialTextArea = GameObject.Find("tutorial_area").GetComponent<RectTransform>();
        TutorialTitle = tutorialTextArea.Find("Title").GetComponent<Text>();
        TutorialText = tutorialTextArea.Find("Text").GetComponent<Text>();

        //�`���[�g���A���̈ꗗ
        tutorialTask = new List<ITutorialTask>()
        {
            new Moveing(),
            new launch(),
            new Rotation_direction(),
            new bridge(),
            new laser_(),
            new button_selfblock(),
            new dontstop(),
            new end(),
        };

        //�ŏ��̃`���[�g���A����ݒ�
        StartCoroutine(SetCurrentTask(tutorialTask.First()));

        isEnabled = true;
    }

    private void Update()
    {
        if (laserlaserlaser != null)
        {
            if (laserlaserlaser.hit_check is true) { laser_hit = true; }
        }
        if (button != null)
        {
            if (button.hit_check is true) { button_hit = true; }
        }
        //�`���[�g���A�������݂����s����Ă��Ȃ��ꍇ�ɏ���
        if (currentTask != null && !task_executed)
        {
            if (currentTask.checkTask())
            {
                task_executed = true;

                DOVirtual.DelayedCall(currentTask.GetTransitionTime(), () =>
                {
                    iTween.MoveTo(tutorialTextArea.gameObject, iTween.Hash(
                        "position", tutorialTextArea.transform.position + new Vector3(fade_pos_x, 0, 0),
                        "time", 1f
                        ));

                    tutorialTask.RemoveAt(0);

                    var nextTask = tutorialTask.FirstOrDefault();
                    if (nextTask != null)
                    {
                        StartCoroutine(SetCurrentTask(nextTask, 1f));
                    }
                });
            }
        }

    }

    /// <summary>
    /// �V�����`���[�g���A���^�X�N��ݒ肷��
    /// </summary>
    /// <param name="task"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    protected IEnumerator SetCurrentTask(ITutorialTask task, float time = 0)
    {
        //time���ݒ肳��Ă���ꍇ�͑ҋ@
        yield return new WaitForSeconds(time);

        currentTask = task;
        task_executed = false;

        //UI�Ƀ^�C�g���Ɛ�������ݒ�
        TutorialTitle.text = task.GetTitle();
        TutorialText.text = task.GetText();

        //�`���[�g���A���^�X�N�ݒ莞�p�̊֐������s
        task.OnTaskSetting();

        iTween.MoveTo(tutorialTextArea.gameObject, iTween.Hash(
            "position", tutorialTextArea.transform.position - new Vector3(fade_pos_x, 0, 0),
            "time", 0.1f
            ));
    }
}
