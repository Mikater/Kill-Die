﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string targetSceneName;

    public void OnMouseDown()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}