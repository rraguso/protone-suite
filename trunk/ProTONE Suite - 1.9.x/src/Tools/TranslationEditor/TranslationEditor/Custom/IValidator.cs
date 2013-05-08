#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TranslationEditor
{
	/// <summary>
	/// Provides a common interface for the Number/TextValidator instances.
	/// </summary>
	public interface IValidator
	{
		#region Properties
		/// <summary>
		/// Gets the minimum length of the text accepted by the validator.
		/// </summary>
		int MinLength
		{
			get;
		}

		/// <summary>
		/// Gets the maximum length of the text accepted by the validator.
		/// </summary>
		int MaxLength
		{
			get;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Checks the specified text against this validator.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <returns>True if text valid, false otherwise.</returns>
		bool Check(string text);
		#endregion
	}
}

#region ChangeLog
#region Date: 12.05.2006			Author: Ghitza Puscasu
// Added MinLength/MaxLength properties.
#endregion
#region Date: 25.03.2006			Author: Ghitza Puscasu
// File created.
#endregion
#endregion