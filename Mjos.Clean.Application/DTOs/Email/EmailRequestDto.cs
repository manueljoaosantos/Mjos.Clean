﻿
namespace Mjos.Clean.Application.DTOs.Email
{
    public class EmailRequestDto
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
    }
}
