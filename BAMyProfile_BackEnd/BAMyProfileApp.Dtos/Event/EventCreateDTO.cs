﻿using BAMyProfileApp.Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Event;

public class EventCreateDTO
{
    public string Title { get; set; } = default!;
    public DateTime Date { get; set; }
    public IFormFile? File { get; set; }
    public string? Link { get; set; }
    public EventType EventType { get; set; }
}
