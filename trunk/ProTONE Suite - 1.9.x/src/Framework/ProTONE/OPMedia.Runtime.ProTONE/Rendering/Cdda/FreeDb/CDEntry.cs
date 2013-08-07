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
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.Generic;
using OPMedia.Core.Utilities;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using OPMedia.Core;

namespace OPMedia.Runtime.ProTONE.Rendering.Cdda.Freedb
{
	/// <summary>
	/// Summary description for CDEntry.
	/// </summary>
    [DataContract]
    public class CDEntry
	{
		#region Public Member Variables
		/// <summary>
		/// Property Discid (string)
		/// </summary>
        [DataMember(Order = 0)]
        public string Discid { get; set; }

		/// <summary>
		/// Property Artist (string)
		/// </summary>
        [DataMember(Order = 1)]
        public string Artist { get; set; }
		
		/// <summary>
		/// Property Title (string)
		/// </summary>
        [DataMember(Order = 2)]
        public string Title { get; set; }
		
		/// <summary>
		/// Property Year (string)
		/// </summary>
        [DataMember(Order = 3)]
        public string Year { get; set; }

		/// <summary>
		/// Property Genre (string)
		/// </summary>
        [DataMember(Order = 4)]
        public string Genre { get; set; }

		/// <summary>
		/// Property Tracks (StringCollection)
		/// </summary>
        [DataMember(Order = 5)]
        public List<Track> Tracks { get; set; }
		
		/// <summary>
		/// Property ExtendedData (string)
		/// </summary>
        [DataMember(Order = 6)]
        public string ExtendedData { get; set; }
		
		/// <summary>
		/// Property PlayOrder (string)
		/// </summary>
        [DataMember(Order = 7)]
        public string PlayOrder { get; set; }

		public int NumberOfTracks
		{
			get
			{
				return (Tracks != null) ? Tracks.Count : 0;
			}
		}

		#endregion

        public static CDEntry LoadPersistentDisc(string discId)
        {
            string xml = PersistenceProxy.ReadObject(discId, string.Empty);
            if (!string.IsNullOrEmpty(xml))
            {
                using (StringReader sr = new StringReader(xml))                
                using (XmlReader xr = XmlReader.Create(sr))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(CDEntry));
                    return xs.Deserialize(xr) as CDEntry;
                }
            }

            return null;
        }

        public void PersistDisc()
        {
            StringBuilder xml = new StringBuilder();
            using (XmlWriter xw = XmlWriter.Create(xml))
            {
                XmlSerializer xs = new XmlSerializer(typeof(CDEntry));
                xs.Serialize(xw, this);
            }

            PersistenceProxy.SaveObject(this.Discid, xml.ToString());
        }

        public CDEntry(string discId) : this()
        {
            Discid = discId;
        }

        protected CDEntry()
        {
            Tracks = new List<Track>();
        }

		public CDEntry(List<string> data) : this()
		{
			if (!Parse(data))
			{
				throw new Exception("Unable to Parse CDEntry.");
			}

            SyncTrackFields();
		}

        private void SyncTrackFields()
        {
            foreach (Track track in Tracks)
            {
                if (string.IsNullOrEmpty(track.Artist))
                {
                    track.Artist = this.Artist;
                }
                if (string.IsNullOrEmpty(track.Album))
                {
                    track.Album = this.Title;
                }
                if (string.IsNullOrEmpty(track.Genre))
                {
                    track.Genre = this.Genre;
                }
                if (string.IsNullOrEmpty(track.Year))
                {
                    track.Year = this.Year;
                }
            }
        }


        private bool Parse(List<string> data)
		{
			foreach (string line in data)
			{

				// check for comment

				if (line[0] == '#')
					continue;

				int index = line.IndexOf('=');
				if (index == -1) // couldn't find equal sign have no clue what the data is
					continue;
				string field = line.Substring(0,index);
				index++; // move it past the equal sign

				switch (field)
				{
					case "DISCID":
					{
						this.Discid = line.Substring(index);
						continue;
					}

					case "DTITLE": // artist / title
					{
						this.Artist += line.Substring(index);
						continue;
					}

					case "DYEAR":
					{
						this.Year = line.Substring(index);
						continue;
					}

					case "DGENRE":
					{
						this.Genre += line.Substring(index);
						continue;
					}

					case "EXTD":
					{
						// may be more than one - just concatenate them
						this.ExtendedData += line.Substring(index);
						continue;
					}

					case "PLAYORDER":
					{
						this.PlayOrder += line.Substring(index);
						continue;
					}

					
					default:

						//get track info or extended track info
						if (field.StartsWith("TTITLE"))
						{
							int trackNumber = -1;
							// Parse could throw an exception
							try
							{
								trackNumber = int.Parse(field.Substring("TTITLE".Length));
							}
							
							catch (Exception ex)
							{
								Debug.WriteLine("Failed to parse track Number. Reason: " + ex.Message);
								continue;
							}

							//may need to concatenate track info
							if (trackNumber < Tracks.Count )
								Tracks[trackNumber].Title += line.Substring(index);
							else
							{
								Track track = new Track { Title = line.Substring(index) };
								this.Tracks.Add(track);
							}
							continue;
						}
						else if (field.StartsWith("EXTT"))
						{
							int trackNumber = -1;
							// Parse could throw an exception
							try
							{
								trackNumber = int.Parse(field.Substring("EXTT".Length));
							}
							
							catch (Exception ex)
							{
								Debug.WriteLine("Failed to parse track Number. Reason: " + ex.Message);
								continue;
							}
							
							if (trackNumber < 0 || trackNumber >  Tracks.Count -1)
								continue;

							Tracks[trackNumber].ExtendedData += line.Substring(index);



						}




						continue;

				} //end of switch

			}


			//split the title and artist from DTITLE;
			// see if we have a slash
			int slash = this.Artist.IndexOf(" / ");
			if (slash == -1)
			{
				this.Title= Artist;
			}
			else
			{
				string titleArtist = Artist;
				this.Artist = titleArtist.Substring(0,slash);
				slash +=3; // move past " / "
				this.Title  = titleArtist.Substring(slash );
			}


			return true;


		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("Title: ");
			builder.Append(this.Title);
			builder.Append("\n");
			builder.Append("Artist: ");
			builder.Append(this.Artist);
			builder.Append("\n");
			builder.Append("Discid: ");
			builder.Append(this.Discid);
			builder.Append("\n");
			builder.Append("Genre: ");
			builder.Append(this.Genre);
			builder.Append("\n");
			builder.Append("Year: ");
			builder.Append(this.Year);
			builder.Append("\n");
			builder.Append("Tracks:");
			foreach (Track track in this.Tracks)
			{
				builder.Append("\n");
				builder.Append(track.Title);
			}

			return builder.ToString();

		}

        internal void Merge(CDEntry slave)
        {
            if (slave != null)
            {
                Artist = StringUtils.TakeValid(Artist, slave.Artist);
                ExtendedData = StringUtils.TakeValid(ExtendedData, slave.ExtendedData);
                Genre = StringUtils.TakeValid(Genre, slave.Genre);
                PlayOrder = StringUtils.TakeValid(PlayOrder, slave.PlayOrder);
                Title = StringUtils.TakeValid(Title, slave.Title);
                Year = StringUtils.TakeValid(Year, slave.Year);
                Tracks = MergeTracks(Tracks, slave.Tracks);
            }
        }

        private List<Track> MergeTracks(List<Track> master, List<Track> slave)
        {
            if (master != null && slave != null)
            {
                int max = Math.Min(master.Count, slave.Count);
                for (int i = 0; i < max; i++)
                {
                    Track tMaster = master[i];
                    Track tSlave = slave[i];
                    tMaster.Merge(tSlave);
                }
            }

            return master;
        }
    }
}
