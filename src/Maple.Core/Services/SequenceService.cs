﻿using System;
using System.Collections.Generic;
using System.Linq;
using Maple.Interfaces;
using Maple.Localization.Properties;

namespace Maple.Core
{
    public class SequenceService : ISequenceService
    {
        private readonly ILoggingService _log;

        public SequenceService(ILoggingService log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log), $"{nameof(log)} {Resources.IsRequired}");
        }

        public int Get(IList<ISequence> items)
        {
            var result = 0;

            if (items.Count > 0)
            {
                while (items.Any(p => p.Sequence == result))
                {
                    if (result == int.MaxValue)
                    {
                        _log.Error(Resources.MaxPlaylistCountReachedException);
                        break;
                    }

                    result++;
                }
            }

            return result;
        }
    }
}
