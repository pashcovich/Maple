﻿using System;
using System.ComponentModel;

namespace Maple.Core
{
    public interface IMediaItem : IIsSelected, ISequence, INotifyPropertyChanged, IIdentifier, IValidatableTrackingObject
    {
        string Title { get; }
        string Location { get; }

        TimeSpan Duration { get; }

        PrivacyStatus PrivacyStatus { get; }
    }
}