using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationButton : MonoBehaviour {

    public CubeController cubeController;

    /// <summary>
    /// 回転ボタンを押した際の処理
    /// </summary>
    public void OnClickRotationBtn() {
        // CubeControllerのRotateメソッドを呼び出す。
        // 直接TestクラスのRotateCubeメソッドを呼びたいが
        // このクラスはメソッドの引数へ入れる情報を持っていないクラスなので
        // 一度、情報を持っているCubeControllerクラスのRotateメソッドを呼び出している
        cubeController.Rotate();
    }
}
