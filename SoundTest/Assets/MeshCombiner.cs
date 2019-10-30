﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//メッシュを合体させるやつ

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshCombiner : MonoBehaviour
{
    bool onStart = true;

    //適当なマテリアルをセットするようにしておく
    public Material targetMaterial;

    void Start()
    {
        
    }
    void Update()
    {
        if (onStart)
        {
            Component[] meshFilters = GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];

            int i = 0;
            while (i < meshFilters.Length)
            {
                combine[i].mesh = ((MeshFilter)meshFilters[i]).sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                meshFilters[i].gameObject.SetActive(false);
                i++;
            }

            print(combine.Length);

            transform.GetComponent<MeshFilter>().mesh = new Mesh();
            transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
            transform.gameObject.SetActive(true);

            //マテリアルを再設定
            transform.gameObject.GetComponent<Renderer>().material = targetMaterial;
            onStart = false;
        }
    }
}