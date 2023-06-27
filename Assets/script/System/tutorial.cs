using UnityEngine;



public class Moveing : ITutorialTask
{
    public string GetTitle()
    {
        return "基本操作";
    }
    public string GetText()
    {
        return "WASDで前進後退左右への移動ができます";
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
        return "起動";
    }
    public string GetText()
    {
        return "赤い柱に近づくと青色になり\n" +
            "操作ができるようになります";
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
        return "回転操作";
    }
    public string GetText()
    {
        return "Qキーで左回転\n" +
            "Eキーで右に回転します";
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
        return "ギミック達";
    }
    public string GetText()
    {
        return "ギミックにはレーザー、ボタン、橋の３種類\n" +
            "そのほかにも自分で動かすブロックなどあります\n";
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
        return "橋";
    }
    public string GetText()
    {
        return "部屋を特定の方向に向けると\n" +
            "足場が伸びて来ます";
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
        return "レーザー";
    }
    public string GetText()
    {
        return "レーザーにブロックを当てます\n" +
            "これに触れても大丈夫です";
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
        return "ボタンと自分で動かすブロック";
    }
    public string GetText()
    {
        return "赤い半球の上にブロックを乗せます\n" +
            "レンガ以外のブロックは自分で動かせます";
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
        return "回転操作2";
    }
    public string GetText()
    {
        return "基本的操作は同じですが\n" +
            "押している間しか回転しません";
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
        return "ゴール";
    }
    public string GetText()
    {
        return "奥の壁に触れるとゴールです\n" +
            "次から本番のステージが始まります";
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
