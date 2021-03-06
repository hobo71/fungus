/**
 * This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
 * It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)
 */

using UnityEngine;
using System.Collections;

namespace Fungus
{
	[VariableInfo("Other", "Texture")]
	[AddComponentMenu("")]
    [System.Serializable]
	public class TextureVariable : VariableBase<Texture>
	{}

	[System.Serializable]
	public struct TextureData
	{
		[SerializeField]
		[VariableProperty("<Value>", typeof(TextureVariable))]
		public TextureVariable textureRef;
		
		[SerializeField]
		public Texture textureVal;

		public TextureData(Texture v)
		{
			textureVal = v;
			textureRef = null;
		}
		
		public static implicit operator Texture(TextureData textureData)
		{
			return textureData.Value;
		}

		public Texture Value
		{
			get { return (textureRef == null) ? textureVal : textureRef.value; }
			set { if (textureRef == null) { textureVal = value; } else { textureRef.value = value; } }
		}

		public string GetDescription()
		{
			if (textureRef == null)
			{
				return textureVal.ToString();
			}
			else
			{
				return textureRef.key;
			}
		}
	}

}