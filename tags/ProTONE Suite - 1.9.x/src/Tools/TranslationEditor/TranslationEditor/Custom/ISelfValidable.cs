#region Copyright © 2006 NEC Corporation
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.

// File: 	ISelfValidable.cs
#endregion

#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TranslationEditor
{
	#region Event Args
	/// <summary>
	/// Specifies event args to be send with a validation event.
	/// </summary>
	public class ValidationEventArgs : EventArgs
	{
		#region Members
		/// <summary>
		/// Flag indicating the new value of the Valid property of the sender.
		/// </summary>
		private bool isValid = false;
		/// <summary>
		/// Represent an event args with no data.
		/// </summary>
		public new static readonly ValidationEventArgs Empty = new ValidationEventArgs(false);
		#endregion

		#region Properties
		/// <summary>
		/// Gets the new value of the IsValid property of the sender.
		/// </summary>
		public bool IsValid
		{
			get
			{
				return isValid;
			}
		}

		/// <summary>
		/// Standard constructor.
		/// </summary>
		/// <param name="isSenderValid">Whether the sender is now valid or not.</param>
		public ValidationEventArgs(bool isSenderValid)
		{
			isValid = isSenderValid;
		}
		#endregion
	}
	#endregion

	/// <summary>
	/// Defines an interface of validable entities.
	/// </summary>
	public interface ISelfValidable
	{
		#region Members
		/// <summary>
		/// Event that gets fired whenever the IsValid property is changed.
		/// </summary>
		event EventHandler<ValidationEventArgs> IsValidChanged;
		#endregion

		#region Properties
		/// <summary>
		/// Gets whether the object is valid or not.
		/// </summary>
		bool IsValid
		{
			get;
		}

		/// <summary>
		/// Gets or sets the custom validator for this entity.
		/// </summary>
		IValidator Validator
		{
			get;
			set;
		}
		#endregion
	}
}

#region ChangeLog
#region Date: 17.04.2007			Author: Ghitza Puscasu
// Added Empty property for the ValidationEventArgs.
#endregion
#region Date: 28.03.2006			Author: Ghitza Puscasu
// File created.
#endregion
#endregion