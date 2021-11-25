﻿/* 
  Copyright (C) 2018 tiesky.com / Alex Solovyov
  It's a free software for those, who think that it should be free.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DBreeze.Utils;

namespace Raft
{
    /// <summary>
    /// Comes from the Follower to Leader in time of state log synchronization
    /// </summary>    
    internal class StateLogEntryRequest : Biser.IEncoder
    {
        public StateLogEntryRequest()
        {

        }

        /// <summary>
        /// Id of the State log, which Leader must send to the Follower
        /// </summary>        
        public ulong StateLogEntryId { get; set; }
        ///// <summary>
        ///// Id of the State log, which Leader must send to the Follower
        ///// </summary>        
        //public ulong StateLogEntryTerm { get; set; }

        public Biser.Encoder BiserEncoder(Biser.Encoder existingEncoder = null)
        {
            Biser.Encoder enc = new Biser.Encoder(existingEncoder);

            enc
            .Add(StateLogEntryId)
            //.Add(StateLogEntryTerm)
            ;
            return enc;
        }

        public static StateLogEntryRequest BiserDecode(byte[] enc = null, Biser.Decoder extDecoder = null) //!!!!!!!!!!!!!! change return type
        {
            Biser.Decoder decoder = null;
            if (extDecoder == null)
            {
                if (enc == null || enc.Length == 0)
                    return null;
                decoder = new Biser.Decoder(enc);
                if (decoder.CheckNull())
                    return null;
            }
            else
            {
                if (extDecoder.CheckNull())
                    return null;
                else
                    decoder = extDecoder;
            }

            StateLogEntryRequest m = new StateLogEntryRequest();  //!!!!!!!!!!!!!! change return type

            m.StateLogEntryId = decoder.GetULong();
            //m.StateLogEntryTerm = decoder.GetULong();

            return m;
        }
    }
}
