#region COPYRIGHT (c) 2004 by Brian Weeres
/* Copyright (c) 2004 by Brian Weeres
 * 
 * Email: bweeres@protegra.com; bweeres@hotmail.com
 * 
 * Permission to use, copy, modify, and distribute this software for any
 * purpose is hereby granted, provided that the above
 * copyright notice and this permission notice appear in all copies.
 *
 * If you modify it then please indicate so. 
 *
 * The software is provided "AS IS" and there are no warranties or implied warranties.
 * In no event shall Brian Weeres and/or Protegra Technology Group be liable for any special, 
 * direct, indirect, or consequential damages or any damages whatsoever resulting for any reason 
 * out of the use or performance of this software
 * 
 */
#endregion
using System;
using OPMedia.Core.Utilities;
using System.Runtime.Serialization;

namespace OPMedia.Runtime.ProTONE.Rendering.Cdda.Freedb
{
	/// <summary>
	/// Summary description for Track.
	/// </summary>
    [DataContract]
    public class Track
	{
        [DataMember(Order = 0)]
        public string Artist { get; set; }

        [DataMember(Order = 1)]
        public string Title { get; set; }

        [DataMember(Order = 2)]
        public string Album { get; set; }

        [DataMember(Order = 3)]
        public string Year { get; set; }

        [DataMember(Order = 4)]
        public string Genre { get; set; }

        [DataMember(Order = 5)]
        public string ExtendedData { get; set; }
		
		/// <summary>
		/// Create an instance of a Track 
		/// </summary>
		/// <param name="title"></param>
		public Track()
		{
		}

        internal void Merge(Track slave)
        {
            if (slave != null)
            {
                Artist = StringUtils.TakeValid(Artist, slave.Artist);
                Title = StringUtils.TakeValid(Title, slave.Title);
                Album = StringUtils.TakeValid(Title, slave.Album);
                Year = StringUtils.TakeValid(Year, slave.Year);
                Genre = StringUtils.TakeValid(Genre, slave.Genre);
                ExtendedData = StringUtils.TakeValid(ExtendedData, slave.ExtendedData);
            }
        }
    }
}
