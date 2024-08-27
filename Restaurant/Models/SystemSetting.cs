using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Restaurant.Models;

public partial class SystemSetting : BaseEntity
{
    public int SystemSettingId { get; set; }
    [DisplayName("LImage1")]
    public string? SystemSettingLogoImageUrl { get; set; }
    [DisplayName("LImage2")]
    public string? SystemSettingLogoImageUrl2 { get; set; }
    [DisplayName("Copyright")]
    public string? SystemSettingCopyright { get; set; }
    [DisplayName("NoteTitle")]
    public string? SystemSettingWelcomeNoteTitle { get; set; }
    [DisplayName("WelcomeNoteBreef")]
    public string? SystemSettingWelcomeNoteBreef { get; set; }
    [DisplayName("WelcomeNoteDesc")]
    public string? SystemSettingWelcomeNoteDesc { get; set; }
    [DisplayName("WelcomeNoteUrl")]
    public string? SystemSettingWelcomeNoteUrl { get; set; }
    [DisplayName("NoteImage")]
    public string? SystemSettingWelcomeNoteImageUrl { get; set; }
    [DisplayName("MapLocation")]
    public string? SystemSettingMapLocation { get; set; }
    public string? Icon { get; set; }
}

