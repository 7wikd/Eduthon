﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour{
    public GameObject contextClue;
        public void OnEnable(){
            contextClue.SetActive(true);
        }
        public void Disable(){
            contextClue.SetActive(false);
        }
}
