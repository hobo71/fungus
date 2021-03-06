/**
 * This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
 * It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)
 */

using UnityEngine;
using UnityEngine.Serialization;
using System;
using System.Collections;

namespace Fungus
{
	[CommandInfo("Animation", 
	             "Set Anim Integer", 
	             "Sets an integer parameter on an Animator component to control a Unity animation")]
	[AddComponentMenu("")]
	[ExecuteInEditMode]
	public class SetAnimInteger : Command
	{
		[Tooltip("Reference to an Animator component in a game object")]
		public AnimatorData _animator;

		[Tooltip("Name of the integer Animator parameter that will have its value changed")]
		public StringData _parameterName;

		[Tooltip("The integer value to set the parameter to")]
		public IntegerData value;

		public override void OnEnter()
		{
			if (_animator.Value != null)
			{
				_animator.Value.SetInteger(_parameterName.Value, value.Value);
			}

			Continue();
		}

		public override string GetSummary()
		{
			if (_animator.Value == null)
			{
				return "Error: No animator selected";
			}

			return _animator.Value.name + " (" + _parameterName.Value + ")";
		}

		public override Color GetButtonColor()
		{
			return new Color32(170, 204, 169, 255);
		}

		#region Backwards compatibility

		[HideInInspector] [FormerlySerializedAs("animator")] public Animator animatorOLD;
		[HideInInspector] [FormerlySerializedAs("parameterName")] public string parameterNameOLD = "";

		protected virtual void OnEnable()
		{
			if (animatorOLD != null)
			{
				_animator.Value = animatorOLD;
				animatorOLD = null;
			}

			if (parameterNameOLD != "")
			{
				_parameterName.Value = parameterNameOLD;
				parameterNameOLD = "";
			}
		}

		#endregion
	}

}