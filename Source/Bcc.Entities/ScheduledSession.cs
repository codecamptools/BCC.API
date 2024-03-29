﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Bcc.Entities
{
    public class ScheduledSession : DbEntity
    {

        public int Id { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }

        [MaxLength(30)]
        public string RoomId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int ConferenceId { get; set; }
        public Conference Conference { get; set; }
    }
}