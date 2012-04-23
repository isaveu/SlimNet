/*
 * SlimNet - Networking Middleware For Games
 * Copyright (C) 2011-2012 Fredrik Holmstr�m
 * 
 * This notice may not be removed or altered.
 * 
 * This software is provided 'as-is', without any expressed or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software. 
 * 
 * Attribution
 * The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. For any works using this 
 * software, reasonable acknowledgment is required.
 * 
 * Noncommercial
 * You may not use this software for commercial purposes.
 * 
 * Distribution
 * You are not allowed to distribute or make publicly available the software 
 * itself or its source code in original or modified form.
 */

using System.Collections;
using SlimNet;

public class ChatMessage : Event<Actor>
{
    public override int DataSize
    {
        get { return Message.GetNetworkByteCount(); }
    }

    public override byte EventId
    {
        get { return HeaderBytes.UserStart + 0; }
    }

    public override bool SynchronizeEvent
    {
        get { return false; }
    }

    public string Message
    {
        get;
        set;
    }

    public ChatMessage()
        : base(EventTargets.Owner | EventTargets.Remotes | EventTargets.Server, EventSources.Owner)
    {

    }

    public override void Pack(SlimNet.Network.ByteOutStream stream)
    {
        stream.WriteString(Message);
    }

    public override void Unpack(SlimNet.Network.ByteInStream stream)
    {
        Message = stream.ReadString();
    }
}