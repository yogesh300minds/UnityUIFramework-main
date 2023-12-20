﻿using UnityEngine;
namespace UISystem
{
	public class Rotate : Animatable
	{
		public float targetRotation;
		public float finalRotation;
		public override void OnAnimationStarted()
		{
			base.OnAnimationStarted();
			rectTransform.localRotation = Quaternion.Euler(Vector3.forward * finalRotation);
		}
		public override void OnAnimationRunning(float animPerc)
		{
			base.OnAnimationRunning(animPerc);
			rectTransform.localRotation = Quaternion.Euler(Vector3.forward * (targetRotation * animPerc));
		}
		public override void OnAnimationEnded()
		{
			base.OnAnimationEnded();
			rectTransform.localRotation = Quaternion.Euler(Vector3.forward * finalRotation);
		}
	}
}

