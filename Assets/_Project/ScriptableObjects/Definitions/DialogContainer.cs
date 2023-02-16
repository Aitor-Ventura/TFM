using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Dialogue/DialogContainer")]
public class DialogContainer : ScriptableObject
{
    public Actor actor;
    public List<string> dialog;
}
