using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterBar : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;

	public void SetMaxBar(float meter) {
		slider.maxValue = meter;
		slider.value = meter;
		gradient.Evaluate(1f);
	}

	public void SetMeter(float meter) {
		slider.value = meter;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
