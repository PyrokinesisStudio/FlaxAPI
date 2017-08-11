﻿////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using FlaxEditor.Utilities;

namespace FlaxEditor.History
{
    [Serializable]
    public class UndoActionObject : IHistoryAction
    {
        public UndoActionObject(List<MemberComparison> diff, string actionString, object targetInstance)
        {
            Diff = diff;
            ActionString = actionString;
            TargetInstance = targetInstance;
            Id = Guid.NewGuid();
        }

        public UndoActionObject(List<MemberComparison> diff, string actionString, Guid id, object targetInstance)
        {
            Diff = diff;
            ActionString = actionString;
            Id = id;
            TargetInstance = targetInstance;
        }

        public Guid Id { get; }
        public string ActionString { get; }
        public List<MemberComparison> Diff { get; }
        public object TargetInstance { get; }
    }
}
