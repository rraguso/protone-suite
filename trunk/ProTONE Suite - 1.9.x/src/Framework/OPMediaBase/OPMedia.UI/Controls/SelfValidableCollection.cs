
#region Using directives
using System;
using System.Collections;
#endregion

namespace OPMedia.UI.Controls
{
	/// <summary>
	/// Implements a typed collection for ISelfValidable objects.
	/// </summary>
	public class SelfValidableCollection : CollectionBase
	{
		#region Properties
		/// <summary>
		/// Gets a flag indicating whether all collection items are valid.
		/// </summary>
		public bool IsValid
		{
			get
			{
				bool isValid = true;
				foreach (ISelfValidable item in base.List)
				{
					if (!item.IsValid)
					{
						isValid = false;
						break;
					}
				}

				return isValid;
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Adds a new ISelfValidable object to the collection.
		/// </summary>
		/// <param name="item">The instance to add.</param>
		public void Add(ISelfValidable item)
		{
			base.InnerList.Add(item);
		}

		/// <summary>
		/// Removes an item from the collection.
		/// </summary>
		/// <param name="item">The item to remove.</param>
		public void Remove(ISelfValidable item)
		{
			base.InnerList.Remove(item);
		}
		#endregion

		#region Construction
		/// <summary>
		/// Initializes an empty collection.
		/// </summary>
		public SelfValidableCollection()
		{
		}
		#endregion
	}
}

