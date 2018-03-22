﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParentOnTriggerEnter : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.transform.parent.gameObject);
    }
}
