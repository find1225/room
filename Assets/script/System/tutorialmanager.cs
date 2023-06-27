using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲーム上のチュートリアルを管理するマネージャー
/// </summary>
public class tutorialmanager : MonoBehaviour
{
    //チュートリアル用UI
    protected RectTransform tutorialTextArea;
    protected Text TutorialTitle;
    protected Text TutorialText;

    //チュートリアルタスク
    protected ITutorialTask currentTask;
    protected List<ITutorialTask> tutorialTask;

    //チュートリアル表示フラグ
    bool isEnabled;

    //チュートリアルタスクの条件を満たした際の遷移
    bool task_executed = false;

    //チュートリアル表示時のUI移動距離
    [Header("UI移動距離")]
    [SerializeField] float fade_pos_x;

    public laser laserlaserlaser;
    public static bool laser_hit = false;
    public Button button;
    public static bool button_hit = false;

    private void Start()
    {
        //チュートリアル判定用bool初期化
        laser_hit = false;
        button_hit = false;
        // チュートリアル表示用UIのインスタンス取得
        tutorialTextArea = GameObject.Find("tutorial_area").GetComponent<RectTransform>();
        TutorialTitle = tutorialTextArea.Find("Title").GetComponent<Text>();
        TutorialText = tutorialTextArea.Find("Text").GetComponent<Text>();

        //チュートリアルの一覧
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

        //最初のチュートリアルを設定
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
        //チュートリアルが存在し実行されていない場合に処理
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
    /// 新しいチュートリアルタスクを設定する
    /// </summary>
    /// <param name="task"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    protected IEnumerator SetCurrentTask(ITutorialTask task, float time = 0)
    {
        //timeが設定されている場合は待機
        yield return new WaitForSeconds(time);

        currentTask = task;
        task_executed = false;

        //UIにタイトルと説明文を設定
        TutorialTitle.text = task.GetTitle();
        TutorialText.text = task.GetText();

        //チュートリアルタスク設定時用の関数を実行
        task.OnTaskSetting();

        iTween.MoveTo(tutorialTextArea.gameObject, iTween.Hash(
            "position", tutorialTextArea.transform.position - new Vector3(fade_pos_x, 0, 0),
            "time", 0.1f
            ));
    }
}
