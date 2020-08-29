using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectorHandler : MonoBehaviour {
    public Button[] levels;
    public Text[] level_texts;
    public Button back_button;
    protected int offset;
}
