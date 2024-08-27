﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Restaurant.Models;

public partial class MasterSlider : BaseEntity
{
    public int MasterSliderId { get; set; }

    public string? MasterSliderTitle { get; set; }

    public string? MasterSliderBreef { get; set; }

    public string? MasterSliderDesc { get; set; }

    public string? MasterSliderUrl { get; set; }
    public string? MasterSliderUrl2 { get; set; }
}
