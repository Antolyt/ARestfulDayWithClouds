using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamePlayKeyControl : MonoBehaviour {

    public UnityEvent actionOnSubmit;
	public UnityEvent actionOnCancel;

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Submit"))
        {
            if (actionOnSubmit != null) actionOnSubmit.Invoke();
            return;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (actionOnCancel != null) actionOnCancel.Invoke();
            return;
        }
    }
}
