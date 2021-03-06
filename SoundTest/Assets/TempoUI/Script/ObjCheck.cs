﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//最も近い"GameObject"（タグ）の情報を取得する

public class ObjCheck : MonoBehaviour
{
    public static GameObject nearObj;         //最も近いオブジェクト
    public GameObject obj;

    // Use this for initialization
    void Start()
    {
        //最も近かったオブジェクトを取得
        nearObj = new GameObject();

    }
    // Update is called once per frame
    void Update()
    {

        obj = serchTag(gameObject, "NotesLeft");

    }

    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;            //距離用一時変数
        float nearDis = 0;           //最も近いオブジェクトの距離
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }
        }
        //最も近かったオブジェクトを返す
        return targetObj;
    }
}
