/*
Copyright (c) 2012-2015, Coherent Labs AD
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this
  list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

* Neither the name of Coherent UI nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#if COHERENT_PLATFORM_IOS || COHERENT_PLATFORM_ANDROID

using Coherent.UI.Mobile.Binding;

namespace Coherent.UI.Binding
{
	internal class DictionaryReader
	{
		public DictionaryReader(System.Type type, System.Type[] typeArguments)
		{
			m_Type = type;
			m_Key = typeArguments[0];
			m_Value = typeArguments[1];
		}
		
		public object Read(Importer importer)
		{
			if (!importer.IsNull())
			{
				var result = System.Activator.CreateInstance(m_Type);
				var dict = (System.Collections.IDictionary)result;
				var size = importer.Reader.BeginSequence(ValueType.Object);
				for (var i = 0UL; i < size; ++i)
				{
					var key = importer.Read(m_Key);
					var value = importer.Read(m_Value);
					dict.Add(key, value);
				}
				return result;
			}
			importer.SkipValue();
			return null;
		}
		
		private System.Type m_Type;
		private System.Type m_Key;
		private System.Type m_Value;
	}
}

#endif
