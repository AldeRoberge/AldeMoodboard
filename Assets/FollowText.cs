using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FollowText : MonoBehaviour
{
    public TMP_Text nameLabel;

    public void SetLabel(TMP_Text label)
    {
        this.nameLabel = label;
    }

    void Update()
    {
        Vector3 namePose = Camera.main.WorldToScreenPoint(this.transform.position);
        nameLabel.transform.position = new Vector3(namePose.x, namePose.y + 90f, namePose.z);
    }

    public void SetText(string title)
    {
        nameLabel.text = title;
    }
}