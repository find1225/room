using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ITutorialTask
{
    /// <summary>
    /// チュートリアルのタイトルを取得
    /// </summary>
    /// <returns></returns>
    string GetTitle();
    /// <summary>
    /// 説明文を取得
    /// </summary>
    /// <returns></returns>
    string GetText();
    /// <summary>
    /// チュートリアルタスクが設定された場合実行
    /// </summary>
    void OnTaskSetting();
    /// <summary>
    /// チュートリアルタスクが達成されたかどうかの判断
    /// </summary>
    /// <returns></returns>
    bool checkTask();
    /// <summary>
    /// 達成後に次タスクへの遷移時間
    /// </summary>
    /// <returns></returns>
    float GetTransitionTime();
}
