using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public Test test;    // Testクラスを持っているゲームオブジェクトをインスペクターでアサインするのを忘れないように
    
    public void OnClickResetBtn() {
        // TestクラスのResetRotateメソッドを呼び出す。
        // 引数が必要ないので直接呼び出してよい。
        test.ResetRotate();
    }
}
