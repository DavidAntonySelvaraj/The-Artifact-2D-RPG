using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactHealthUI : MonoBehaviour
{
    [SerializeField] private Slider artifactHealthSlider;

    [SerializeField] private ArtifactScript artifactScript;

    private void Start()
    {
        artifactHealthSlider.maxValue = artifactScript.maxHealth;
        artifactHealthSlider.value = artifactScript.maxHealth;
    }

    private void Update()
    {
        artifactHealthSlider.value = artifactScript.health;
    }














}//class



















